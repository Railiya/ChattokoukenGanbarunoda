using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKG.Composer;

namespace CKG.Input
{
    public sealed class CapturingHandler : IDisposable
    {
        public static event Action<bool> OnInputToggleBefore = null;
        public static event Func<bool, bool, string> OnInputToggle = null;

        public event Action<ECapturingState> OnStateChanged = null;
        public event Action<EInputCharacter> OnInputCharacterChanged = null;

        public ECapturingState State { get; private set; } = ECapturingState.Disabled;
        public EInputCharacter InputCharacter { get; private set; } = EInputCharacter.Alphabet;
        public string BufferedText { get; private set; }

        private KeyInputObserver _keyObserver = null;
        private KeyMacroHandler _keyMacro = null;

        private CommonComposer _commonComposer = new CommonComposer();
        private AlphabetComposer _alphabetComposer = new AlphabetComposer();
        private HangulComposer _hangulComposer = new HangulComposer();
        private IImeComposer _currentComposer = null;

        private StringBuilder _buffer = new StringBuilder(128);
        private byte[] _keyboardState = new byte[256];

        private EInputMethod _inputMethod = EInputMethod.DirectInput;
        private IntPtr _cachedForegroundWindow = IntPtr.Zero;
        private bool _isDisposed = false;

        public CapturingHandler()
        {
            _currentComposer = _alphabetComposer;

            _keyObserver = new KeyInputObserver();
            _keyObserver.KeyDown += OnKeyDown;
            _keyMacro = new KeyMacroHandler();

            //Set default input mode
            SetInputMethod((EInputMethod)UserProfile.Current.InputMethodIndex);
            SwitchInputCharacter((EInputCharacter)UserProfile.Current.DefaultInputCharacterIndex);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _keyObserver.KeyDown -= OnKeyDown;
            _keyObserver.Dispose();
            _keyMacro.Dispose();

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        #region Public Functions

        public void SetTranslating()
        {
            if (State != ECapturingState.Buffered)
            {
                return;
            }

            SetState(ECapturingState.Translating);
        }

        public void SetTranslated()
        {
            if (State != ECapturingState.Translating)
            {
                return;
            }

            SetState(ECapturingState.Translated);
        }

        public void SetFailed()
        {
            if (State == ECapturingState.Disabled)
            {
                return;
            }

            SetState(ECapturingState.Failed);
        }

        public void SendMacroMessage()
        {
            string clipboard = Clipboard.GetText();

            if (string.IsNullOrEmpty(clipboard))
            {
                return;
            }

            switch ((EOutputMethod)UserProfile.Current.OutputMethodIndex)
            {
                case EOutputMethod.ClipboardPaste:
                    _keyMacro.SendClipboardPaste();
                    break;

                case EOutputMethod.InputSimulation:
                    _keyMacro.SendInputSimulation(clipboard);
                    break;
            }
        }

        public void SetInputMethod(EInputMethod method)
        {
            _inputMethod = method;

            if (State == ECapturingState.Disabled)
            {
                return;
            }

            ResetBffer();
            State = ECapturingState.Idle;

            OnStateChanged?.Invoke(State);
        }

        #endregion

        #region Private Key Handle Functions

        private void OnKeyDown(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.EnableCapturingKeySetting, key))
            {
                if (State == ECapturingState.Disabled)
                {
                    SetState(ECapturingState.Idle);
                }
                else
                {
                    SetState(ECapturingState.Disabled);
                    DeactivateInput();
                }

                return;
            }

            if (IsHotkeyPressed(UserProfile.Current.SendClipboardKeySetting, key) && 
                UserProfile.Current.AutoSendMessageOnTranslated == false)
            {
                SendMacroMessage();
                return;
            }

            if (_inputMethod == EInputMethod.DirectInput && (key == Keys.HangulMode || key == Keys.HanguelMode))
            {
                bool ctrl = (Control.ModifierKeys & Keys.Control) != 0;
                bool alt = (Control.ModifierKeys & Keys.Alt) != 0;
                bool shift = (Control.ModifierKeys & Keys.Shift) != 0;

                if (ctrl == false && alt == false && shift == false)
                {
                    SwitchInputCharacter(GetNextInputMode());
                }

                return;
            }

            if (State == ECapturingState.Disabled || _keyMacro.IsRunning)
            {
                //Cancel state switching if state is disabled or macro is running
                return;
            }

            switch (State)
            {
                case ECapturingState.Idle:
                    HandleIdleState(key);
                    break;

                case ECapturingState.Capturing:
                    HandleCapturingState(key);
                    break;

                case ECapturingState.Buffered:
                    HandleBufferedState(key);
                    break;

                case ECapturingState.Translated:
                    HandleTranslatedState(key);
                    break;

                case ECapturingState.Failed:
                    HandleFailedState(key);
                    break;
            }
        }

        private void HandleIdleState(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.CapturingToggleKeySetting, key))
            {
                ResetBffer();
                SetState(ECapturingState.Capturing);
                TryActiveOverlayInput();
            }
        }

        private void HandleCapturingState(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.CapturingToggleKeySetting, key))
            {
                switch (_inputMethod)
                {
                    case EInputMethod.DirectInput:
                        FlushComposerToBuffer();
                        BufferedText = _buffer.ToString();
                        break;

                    case EInputMethod.OverlayInput:
                        OnInputToggleBefore?.Invoke(false);
                        BufferedText = OnInputToggle?.Invoke(false, true);
                        DeactivateInput();
                        break;
                }

                if (string.IsNullOrEmpty(BufferedText))
                {
                    SetState(ECapturingState.Idle);
                }
                else
                {
                    SetState(ECapturingState.Buffered);
                }

                return;
            }

            if (_inputMethod == EInputMethod.DirectInput)
            {
                if (key == Keys.Back)
                {
                    HandleBackspace();
                    return;
                }

                if (TryUpdateKeyboardState() == false)
                {
                    return;
                }

                if (_commonComposer.TryGetChar(key, _keyboardState, out char common))
                {
                    FlushComposerToBuffer();
                    _buffer.Append(common);
                    return;
                }

                _currentComposer.Input(key, _keyboardState);
            }
        }

        private void HandleBufferedState(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.TranslateKeySetting, key) && 
                UserProfile.Current.StartTranslateOnBuffered == false)
            {
                SetState(ECapturingState.Translating);
                return;
            }

            if (IsHotkeyPressed(UserProfile.Current.CapturingToggleKeySetting, key))
            {
                ResetBffer();
                SetState(ECapturingState.Capturing);
                TryActiveOverlayInput();
                return;
            }
        }

        private void HandleTranslatedState(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.SendClipboardKeySetting, key))
            {
                SetState(ECapturingState.Idle);
                return;
            }

            if (IsHotkeyPressed(UserProfile.Current.CapturingToggleKeySetting, key))
            {
                ResetBffer();
                SetState(ECapturingState.Capturing);
                TryActiveOverlayInput();
                return;
            }
        }

        private void HandleFailedState(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.CapturingToggleKeySetting, key))
            {
                ResetBffer();
                SetState(ECapturingState.Capturing);
                TryActiveOverlayInput();
            }
        }

        private void HandleBackspace()
        {
            if (_currentComposer.Length > 0)
            {
                _currentComposer.Backspace();
                return;
            }

            if (_buffer.Length > 0)
            {
                _buffer.Remove(_buffer.Length - 1, 1);
            }
        }

        private bool IsHotkeyPressed(SKeySetting setting, Keys pressedKey)
        {
            if (pressedKey == Keys.None || setting.Key != pressedKey)
            {
                return false;
            }

            bool ctrl = (Control.ModifierKeys & Keys.Control) != 0;
            bool alt = (Control.ModifierKeys & Keys.Alt) != 0;
            bool shift = (Control.ModifierKeys & Keys.Shift) != 0;

            if (setting.Ctrl != ctrl)
            {
                return false;
            }

            if (setting.Alt != alt)
            {
                return false;
            }

            if (setting.Shift != shift)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Private Functions

        private void SetState(ECapturingState state)
        {
            if (State == state)
            {
                return;
            }

            State = state;
            OnStateChanged?.Invoke(State);
        }

        private void FlushComposerToBuffer()
        {
            if (_currentComposer.Length <= 0)
            {
                return;
            }

            _buffer.Append(_currentComposer.Commit());
        }

        private void SwitchInputCharacter(EInputCharacter inputCharacter)
        {
            FlushComposerToBuffer();

            InputCharacter = inputCharacter;
            _currentComposer = InputCharacter switch
            {
                EInputCharacter.Hangul => _hangulComposer,
                _ => _alphabetComposer,
            };

            OnInputCharacterChanged?.Invoke(InputCharacter);
        }

        private void ResetBffer()
        {
            _buffer.Clear();
            _hangulComposer.Reset();
            _alphabetComposer.Reset();
        }

        private bool TryUpdateKeyboardState()
        {
            if (GetKeyboardState(_keyboardState) == false)
            {
                return false;
            }

            _keyboardState[(int)Keys.ShiftKey] = (byte)(GetAsyncKeyState((int)Keys.ShiftKey) < 0 ? 0x80 : 0);
            _keyboardState[(int)Keys.Capital] = (byte)(GetKeyState((int)Keys.Capital) & 0x01);
            return true;
        }

        private EInputCharacter GetNextInputMode()
        {
            nint hkl = GetKeyboardLayout(0);
            ushort lcid = (ushort)((uint)hkl & 0xFFFF);

            return lcid switch
            {
                0x0412 => InputCharacter == EInputCharacter.Hangul ? EInputCharacter.Alphabet : EInputCharacter.Hangul,
                _ => EInputCharacter.Alphabet,
            };
        }

        private async void TryActiveOverlayInput()
        {
            if (_inputMethod != EInputMethod.OverlayInput)
            {
                return;
            }

            OnInputToggleBefore?.Invoke(true);

            await ActivateInput(CKG.Forms.OverlayForm.HandlePtr);

            OnInputToggle?.Invoke(true, false);
        }

        private async Task ActivateInput(IntPtr overlayHandle)
        {
            _cachedForegroundWindow = GetForegroundWindow();
            uint foregroundThread = GetWindowThreadProcessId(_cachedForegroundWindow, out _);
            uint currentThread = GetCurrentThreadId();

            //This function is remains for stability
            AllowSetForegroundWindow((uint)Process.GetCurrentProcess().Id);

            AttachThreadInput(currentThread, foregroundThread, true);
            SetForegroundWindow(overlayHandle);
            AttachThreadInput(currentThread, foregroundThread, false);

            await Task.Delay(100);
        }

        private void DeactivateInput()
        {
            if (_cachedForegroundWindow == IntPtr.Zero)
            {
                return;
            }

            SetForegroundWindow(_cachedForegroundWindow);
            _cachedForegroundWindow = IntPtr.Zero;
        }

        #endregion

        #region Win32

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        private static extern nint GetKeyboardLayout(uint idThread);

        /* Used For Overlay Input */

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool AllowSetForegroundWindow(uint dwProcessId);

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        #endregion
    }
}
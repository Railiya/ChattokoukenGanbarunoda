using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using CKG.Composer;

namespace CKG.Input
{
    public sealed class CapturingHandler : IDisposable
    {
        public event Action<ECapturingState> OnStateChanged = null;
        public event Action<EInputMode> OnInputModeChanged = null;

        public ECapturingState State { get; private set; } = ECapturingState.Disabled;
        public EInputMode InputMode { get; private set; } = EInputMode.Alphabet;
        public string BufferedText { get; private set; }

        private KeyInputObserver _keyObserver = null;
        private KeyMacroHandler _keyMacro = null;

        private CommonComposer _commonComposer = new CommonComposer();
        private AlphabetComposer _alphabetComposer = new AlphabetComposer();
        private HangulComposer _hangulComposer = new HangulComposer();
        private IImeComposer _currentComposer = null;

        private StringBuilder _buffer = new StringBuilder(128);
        private byte[] _keyboardState = new byte[256];
        private bool _isDisposed = false;

        public CapturingHandler()
        {
            _currentComposer = _alphabetComposer;

            _keyObserver = new KeyInputObserver();
            _keyObserver.KeyDown += OnKeyDown;
            _keyMacro = new KeyMacroHandler();

            //Set default input mode
            SwitchInputMode((EInputMode)UserProfile.Current.DefaultInputModeIndex);
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
                }

                return;
            }

            if (IsHotkeyPressed(UserProfile.Current.SendClipboardKeySetting, key) && 
                UserProfile.Current.AutoSendMessageOnTranslated == false)
            {
                SendMacroMessage();
                return;
            }

            if (key == Keys.HangulMode || key == Keys.HanguelMode)
            {
                bool ctrl = (Control.ModifierKeys & Keys.Control) != 0;
                bool alt = (Control.ModifierKeys & Keys.Alt) != 0;
                bool shift = (Control.ModifierKeys & Keys.Shift) != 0;

                if (ctrl == false && alt == false && shift == false)
                {
                    SwitchInputMode(GetNextInputMode());
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
            }
        }

        private void HandleCapturingState(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.CapturingToggleKeySetting, key))
            {
                FlushComposerToBuffer();
                BufferedText = _buffer.ToString();

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
                return;
            }
        }

        private void HandleFailedState(Keys key)
        {
            if (IsHotkeyPressed(UserProfile.Current.CapturingToggleKeySetting, key))
            {
                ResetBffer();
                SetState(ECapturingState.Capturing);
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

        private void SwitchInputMode(EInputMode inputMode)
        {
            FlushComposerToBuffer();

            InputMode = inputMode;
            _currentComposer = InputMode switch
            {
                EInputMode.Hangul => _hangulComposer,
                _ => _alphabetComposer,
            };

            OnInputModeChanged?.Invoke(InputMode);
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

        private EInputMode GetNextInputMode()
        {
            nint hkl = GetKeyboardLayout(0);
            ushort lcid = (ushort)((uint)hkl & 0xFFFF);

            return lcid switch
            {
                0x0412 => InputMode == EInputMode.Hangul ? EInputMode.Alphabet : EInputMode.Hangul,
                _ => EInputMode.Alphabet,
            };
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

        #endregion
    }
}
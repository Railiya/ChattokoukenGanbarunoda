using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CKG.Input
{
    public sealed class KeyMacroHandler : IDisposable
    {
        private struct SMacroInput
        {
            public readonly bool IsChar;
            public readonly Keys Key;
            public readonly char Char;

            public SMacroInput(Keys key)
            {
                IsChar = false;
                Key = key;
                Char = '\0';
            }

            public SMacroInput(char c)
            {
                IsChar = true;
                Key = Keys.None;
                Char = c;
            }
        }

        public int IntervalMs { get; set; } = 10;
        public bool IsRunning { get; private set; }

        private INPUT[] _charInputs = new INPUT[2];
        private ConcurrentQueue<SMacroInput> _keyQueue = null;
        private ManualResetEventSlim _resetSignal = null;
        private CancellationTokenSource _cancelTokenSource = null;
        private Thread _worker = null;

        private bool _isDisposed = false;

        public KeyMacroHandler()
        {
            _keyQueue = new ConcurrentQueue<SMacroInput>();
            _resetSignal = new ManualResetEventSlim(false);
            _cancelTokenSource = new CancellationTokenSource();
            _worker = new Thread(WorkerLoop) { IsBackground = true };
            _worker.Start();
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _cancelTokenSource.Cancel();
            _resetSignal.Set();
            _worker.Join();
            _cancelTokenSource.Dispose();
            _resetSignal.Dispose();

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        #region Public Functions

        public void SendClipboardPaste()
        {
            EnqueueKey(Keys.Enter);
            EnqueueKey(Keys.Control | Keys.V);
            EnqueueKey(Keys.Enter);
        }

        public void SendInputSimulation(string text)
        {
            EnqueueKey(Keys.Enter);

            foreach (char c in text)
            {
                EnqueueChar(c);
            }

            EnqueueKey(Keys.Enter);
        }

        #endregion

        #region Private Functions

        private void WorkerLoop()
        {
            while (_cancelTokenSource.IsCancellationRequested == false)
            {
                try
                {
                    _resetSignal.Wait(_cancelTokenSource.Token);
                    _resetSignal.Reset();

                    SetRunningState(true);

                    while (_keyQueue.TryDequeue(out SMacroInput input))
                    {
                        if (input.IsChar)
                        {
                            SendChar(input.Char);
                        }
                        else
                        {
                            SendKey(input.Key);
                        }

                        Thread.Sleep(IntervalMs);
                    }
                }
                catch (OperationCanceledException) { } //This exception is normal
                finally
                {
                    SetRunningState(false);
                }
            }
        }

        private void SendKey(Keys key)
        {
            bool ctrl = key.HasFlag(Keys.Control);
            bool shift = key.HasFlag(Keys.Shift);
            bool alt = key.HasFlag(Keys.Alt);

            Keys baseKey = key & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;

            if (ctrl)
            { 
                keybd_event((byte)Keys.ControlKey, 0, 0, 0);
            }

            if (shift)
            { 
                keybd_event((byte)Keys.ShiftKey, 0, 0, 0); 
            }

            if (alt)
            { 
                keybd_event((byte)Keys.Menu, 0, 0, 0); 
            }

            keybd_event((byte)baseKey, 0, 0, 0);
            keybd_event((byte)baseKey, 0, KEYEVENTF_KEYUP, 0);

            if (alt)
            { 
                keybd_event((byte)Keys.Menu, 0, KEYEVENTF_KEYUP, 0); 
            }

            if (shift)
            { 
                keybd_event((byte)Keys.ShiftKey, 0, KEYEVENTF_KEYUP, 0);
            }

            if (ctrl)
            { 
                keybd_event((byte)Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0); 
            }
        }

        private void EnqueueKey(Keys key)
        {
            _keyQueue.Enqueue(new SMacroInput(key));

            if (_resetSignal.IsSet == false)
            {
                _resetSignal.Set();
            }
        }

        private void EnqueueChar(char c)
        {
            _keyQueue.Enqueue(new SMacroInput(c));

            if (_resetSignal.IsSet == false)
            {
                _resetSignal.Set();
            }
        }

        private void SetRunningState(bool active)
        {
            IsRunning = active;
            BlockInput(active);
        }

        private void SendChar(char c)
        {
            _charInputs[0].type = INPUT_KEYBOARD;
            _charInputs[0].ki.wVk = 0;
            _charInputs[0].ki.wScan = c;
            _charInputs[0].ki.dwFlags = KEYEVENTF_UNICODE;
            _charInputs[0].ki.time = 0;
            _charInputs[0].ki.dwExtraInfo = 0;

            _charInputs[1].type = INPUT_KEYBOARD;
            _charInputs[1].ki.wVk = 0;
            _charInputs[1].ki.wScan = c;
            _charInputs[1].ki.dwFlags = KEYEVENTF_UNICODE | KEYEVENTF_KEYUP;
            _charInputs[1].ki.time = 0;
            _charInputs[1].ki.dwExtraInfo = 0;

            SendInput(2, _charInputs, Marshal.SizeOf<INPUT>());
        }

        #endregion

        #region Win32

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public nuint dwExtraInfo;
            public uint padding;      // 40바이트 맞추기
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public KEYBDINPUT ki;
        }

        private const uint INPUT_KEYBOARD = 1;
        private const uint KEYEVENTF_UNICODE = 0x0004;
        private const uint KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, nuint dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool fBlockIt);

        #endregion
    }
}

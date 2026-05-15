using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CKG.Input
{
    public sealed class KeyInputObserver : IDisposable
    {
        public event Action<Keys> KeyDown = null;
        public event Action<Keys> KeyUp = null;

        private HookProc _hookProc = null;
        private nint _hookHandle = nint.Zero;
        private bool _isDisposed = false;

        public KeyInputObserver()
        {
            _hookProc = HookCallback;

            using Process process = Process.GetCurrentProcess();
            using ProcessModule module = process.MainModule;

            nint moduleHandle = GetModuleHandle(module.ModuleName);
            _hookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, moduleHandle, 0);

            if (_hookHandle == nint.Zero)
            {
                throw new InvalidOperationException("Failed to install keyboard hook.");
            }
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_hookHandle != nint.Zero)
            {
                UnhookWindowsHookEx(_hookHandle);
                _hookHandle = nint.Zero;
            }

            KeyDown = null;
            KeyUp = null;

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        private nint HookCallback(int nCode, nint wParam, nint lParam)
        {
            if (nCode >= 0 && _isDisposed == false)
            {
                int message = wParam.ToInt32();

                unsafe
                {
                    KBDLLHOOKSTRUCT* data = (KBDLLHOOKSTRUCT*)lParam;
                    Keys key = (Keys)data->vkCode;

                    switch (message)
                    {
                        case WM_KEYDOWN:
                        case WM_SYSKEYDOWN:
                            KeyDown?.Invoke(key);
                            break;

                        case WM_KEYUP:
                        case WM_SYSKEYUP:
                            KeyUp?.Invoke(key);
                            break;
                    }
                }
            }

            return CallNextHookEx(_hookHandle, nCode, wParam, lParam);
        }

        #region Win32

        private delegate nint HookProc(int nCode, nint wParam, nint lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public nint dwExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern nint SetWindowsHookEx(int idHook, HookProc lpfn, nint hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(nint hhk);

        [DllImport("user32.dll")]
        private static extern nint CallNextHookEx(nint hhk, int nCode, nint wParam, nint lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern nint GetModuleHandle(string lpModuleName);

        #endregion
    }
}

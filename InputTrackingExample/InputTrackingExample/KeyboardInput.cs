using System;
using System.Runtime.InteropServices;

namespace InputTrackingExample
{
    public class KeyboardInput : IDisposable
    {
        private const Int32 WH_KEYBOARD_LL = 13;
        private WindowsHookHelper.HookDelegate keyBoardDelegate;
        private IntPtr keyBoardHandle;

        public KeyboardInput(IntPtr id)
        {
            keyBoardDelegate = this.KeyboardHookDelegate;
            keyBoardHandle = WindowsHookHelper.SetWindowsHookEx(WH_KEYBOARD_LL, keyBoardDelegate, id, 0);
        }

        public event EventHandler<CharArgs> KeyBoardKeyPressed;

        public void Dispose()
        {
            if (keyBoardHandle != IntPtr.Zero && WindowsHookHelper.UnhookWindowsHookEx(keyBoardHandle))
            {
                keyBoardHandle = IntPtr.Zero;
            }
        }

        private IntPtr KeyboardHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                KeyBoardKeyPressed?.Invoke(this, new CharArgs()
                {
                    Key = (VirtualKeys)vkCode,
                    Event = (KeyEvents)wParam
                });
            }

            return WindowsHookHelper.CallNextHookEx(keyBoardHandle, Code, wParam, lParam);
        }
    }
}
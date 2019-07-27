using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class KeyboardInput : IDisposable
    {
        private const Int32 WH_KEYBOARD_LL = 13;
        private bool disposed;
        private IntPtr keyBoardHandle;

        public KeyboardInput()
        {
            keyBoardHandle = WindowsHookHelper.SetWindowsHookEx(
                WH_KEYBOARD_LL, this.KeyboardHookDelegate, IntPtr.Zero, 0);
        }

        ~KeyboardInput()
        {
            Dispose(false);
        }

        public event EventHandler<EventArgs> KeyBoardKeyPressed;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (keyBoardHandle != IntPtr.Zero)
                {
                    WindowsHookHelper.UnhookWindowsHookEx(
                        keyBoardHandle);
                }

                disposed = true;
            }
        }

        private IntPtr KeyboardHookDelegate(
                            Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code < 0)
            {
                return WindowsHookHelper.CallNextHookEx(
                    keyBoardHandle, Code, wParam, lParam);
            }

            if (KeyBoardKeyPressed != null)
                KeyBoardKeyPressed(this, new EventArgs());

            return WindowsHookHelper.CallNextHookEx(
                keyBoardHandle, Code, wParam, lParam);
        }
    }
}
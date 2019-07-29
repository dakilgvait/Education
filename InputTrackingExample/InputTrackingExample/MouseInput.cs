using System;

namespace InputTrackingExample
{
    public class MouseInput : IDisposable
    {
        private const Int32 WH_MOUSE_LL = 14;

        private bool disposed;

        private WindowsHookHelper.HookDelegate mouseDelegate;

        private IntPtr mouseHandle;

        public MouseInput()
        {
            mouseDelegate = MouseHookDelegate;
            mouseHandle = WindowsHookHelper.SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, IntPtr.Zero, 0);
        }

        ~MouseInput()
        {
            Dispose(false);
        }

        public event EventHandler<EventArgs> MouseMoved;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (mouseHandle != IntPtr.Zero)
                    WindowsHookHelper.UnhookWindowsHookEx(mouseHandle);

                disposed = true;
            }
        }

        private IntPtr MouseHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code < 0)
                return WindowsHookHelper.CallNextHookEx(mouseHandle, Code, wParam, lParam);

            if (MouseMoved != null)
                MouseMoved(this, new EventArgs());

            return WindowsHookHelper.CallNextHookEx(mouseHandle, Code, wParam, lParam);
        }
    }
}
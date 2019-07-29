using System;
using System.Runtime.InteropServices;

namespace InputTrackingExample
{
    public class WindowsHookHelper
    {
        public delegate IntPtr HookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, Int32 nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr HWnd, IntPtr cmd);

        [DllImport("User32.dll")]
        public static extern IntPtr SetWindowsHookEx(Int32 idHook, HookDelegate lpfn, IntPtr hmod, Int32 dwThreadId);

        [DllImport("User32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);
    }
}
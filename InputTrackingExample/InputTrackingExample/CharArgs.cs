using System;

namespace InputTrackingExample
{
    public class CharArgs : EventArgs
    {
        public KeyEvents Event { get; set; }
        public VirtualKeys Key { get; set; }
    }
}
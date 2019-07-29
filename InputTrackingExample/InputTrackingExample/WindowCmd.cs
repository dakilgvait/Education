using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputTrackingExample
{
    public enum WindowCmd
    {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,
        GW_ENABLEDPOPUP = 6,
        WM_GETTEXT = 0x000D,
        WM_SETTEXT = 0x000C
    }
}
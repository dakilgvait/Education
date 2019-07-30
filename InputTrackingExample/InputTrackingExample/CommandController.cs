using System;

namespace InputTrackingExample
{
    public class CommandController : IDisposable
    {
        private char[] command = new char[70];
        private int index = 0;

        private VirtualKeys previousKey;

        public event MessageAction MessageAction;

        public void AddKey(VirtualKeys key)
        {
            if (this.previousKey == VirtualKeys.LeftShift && key == VirtualKeys.OEM1)
            {
                index = 0;
                command[index++] = ':';
            }
            if (index > 0)
            {
                this.PutKey(key);
            }
            previousKey = key;
        }

        public void Dispose()
        {
            this.MessageAction = null;
        }

        private void PutKey(VirtualKeys key)
        {
            if (this.index == this.command.Length)
            {
                this.index = 0;
            }
            else if (this.index == 4 && key == VirtualKeys.Space)
            {
                string str = new string(this.command, 0, 4);
                if (str != ":CMD")
                {
                    this.index = 0;
                }
                else
                {
                    command[index++] = ' ';
                }
            }
            else
            {
                switch (key)
                {
                    case VirtualKeys k when k >= VirtualKeys.A && k <= VirtualKeys.Z:
                        command[index++] = k.ToString()[0];
                        break;

                    case VirtualKeys k when k >= VirtualKeys.N0 && k <= VirtualKeys.N9:
                        command[index++] = k.ToString()[1];
                        break;

                    case VirtualKeys.Back:
                        index--;
                        break;

                    case VirtualKeys.Space:
                        command[index++] = ' ';
                        break;

                    case VirtualKeys k when this.previousKey != VirtualKeys.LeftShift && k == VirtualKeys.OEM1:
                        command[index++] = ';';
                        break;

                    case VirtualKeys.OEMPlus:
                        command[index++] = '=';
                        break;

                    case VirtualKeys.OEM5:
                        command[index++] = '\\';
                        break;

                    case VirtualKeys.OEMMinus:
                        command[index++] = '-';
                        break;

                    case VirtualKeys.OEMPeriod:
                        command[index++] = '.';
                        break;

                    case VirtualKeys.Return:
                        this.MessageAction?.Invoke(new string(this.command, 0, this.index));
                        index = 0;
                        break;

                    default: break;
                }
            }
        }
    }
}
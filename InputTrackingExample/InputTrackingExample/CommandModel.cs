using System;
using System.Linq;

namespace InputTrackingExample
{
    public class CommandModel
    {
        public string Action { get; set; }
        public string Group { get; set; }
        public bool IsHelp { get; set; }
        public bool IsInitialize { get; set; }
        public bool IsValid { get; set; }
        public string Registration { get; set; }
        public string Target { get; set; }
        public string Text { get; set; }

        public static CommandModel Parse(string cmd)
        {
            var result = new CommandModel();
            var arr = cmd.Split('-').Select(s => s.Trim()).Where(s => s.Length > 0).Select(s => s).ToArray();

            if (arr.Length > 1 && arr[0] == ":CMD")
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    var prp = arr[i].Split('=').Select(s => s.Trim()).Where(s => s.Length > 0).Select(s => s).ToArray();
                    switch (prp[0])
                    {
                        case "REG":
                            if (prp.Length > 1)
                            {
                                result.Registration = prp[1];
                            }

                            break;

                        case "INI":
                            result.IsInitialize = true;
                            break;

                        case "T":
                            result.Target = prp[1];
                            break;

                        case "TXT":
                            result.Text = prp[1];
                            break;

                        default: break;
                    }
                }
            }

            return result;
        }

        public string GetText()
        {
            return this.Text;
        }
    }
}
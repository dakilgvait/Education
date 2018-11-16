namespace Novice.Example_1 {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LINQ {
        public static string IterateText(string text) {
            string sdf = "$GPZDA, 172809, 12, 07, 1996, 00, 00*45";
            string template = "letter:{0}; count:{1}";
            IEnumerable<string> letterList = from el in text
                                             group el by el into grp
                                             select string.Format(template, grp.Key, grp.Count());
            return string.Join(Environment.NewLine, letterList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jint;
using Jint.Native;

namespace JintLibrary {
    public class Class1 {
        public Class1() {
            int x1 = 1;
            int x2 = 3;
            Engine jsEngine = new Engine();
            jsEngine.SetValue("val1", x1);
            jsEngine.SetValue("val2", x2);
            jsEngine.Execute("function test() { return val1+val2; }");
            var qaz = jsEngine.Execute("(function test() { return val1*val2; })()").GetCompletionValue().AsNumber();
            JsValue fnVal = jsEngine.GetValue("test");
            JsValue result = fnVal.Invoke();
            Double obj = result.AsNumber();
        }
    }
}

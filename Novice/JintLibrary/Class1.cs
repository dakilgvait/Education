using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jint;
using Jint.Native;
using Jint.Native.Object;

namespace JintLibrary {
    public class Data {
        public int Val1 { get; set; }
        public string Val2 { get; set; }

    }

    public class Class1 {
        public Class1() {
            int x1 = 1;
            int x2 = 3;
            Engine jsEngine = new Engine();
            jsEngine.SetValue("val1", x1);
            jsEngine.SetValue("val2", x2);
            jsEngine.Execute("function test() { return val1+val2; }");
            var qaz = jsEngine.Execute("(function test() { return val1*val2; })()").GetCompletionValue().AsNumber();
            var qaz2 = jsEngine.Execute("(function test() { return {Val1:2,Val2:\"df\"}; })()").GetCompletionValue()
                .TryCast<Data>();
            JsValue fnVal = jsEngine.GetValue("test");
            JsValue result = fnVal.Invoke();
            Double obj = result.AsNumber();
        }
    }
}

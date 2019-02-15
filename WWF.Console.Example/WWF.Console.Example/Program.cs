using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace WWF.Console.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Activity workflow1 = new TestMessage();
            WorkflowInvoker.Invoke(workflow1);
            System.Console.ReadKey();
        }
    }
}
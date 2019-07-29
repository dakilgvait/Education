using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InputTrackingExample
{
    public delegate void MessageAction(string message);

    public class ActionController : IDisposable
    {
        private CommandController commandController;
        private Dictionary<int, KeyboardInput> keyboards;
        private ProcessController processController;

        public ActionController()
        {
            this.processController = new ProcessController();
            this.commandController = new CommandController();
            var keyboardList = new Dictionary<int, KeyboardInput>(1);
            KeyboardInput ki = new KeyboardInput(IntPtr.Zero);
            ki.KeyBoardKeyPressed += this.Keyboard_KeyBoardKeyPressed;
            keyboardList.Add(0, ki);
            this.keyboards = keyboardList;
            this.commandController.MessageAction += this.CommandController_MessageAction;
        }

        public event MessageAction MessageAction;

        public void Dispose()
        {
            this.MessageAction = null;
            foreach (var k in this.keyboards)
            {
                k.Value.Dispose();
            }
        }

        private void CommandController_MessageAction(string message)
        {
            Task.Run(() =>
            {
                this.processController.ParseCommand(message);
            });
            this.MessageAction?.Invoke(message + Environment.NewLine);
        }

        private void Keyboard_KeyBoardKeyPressed(object sender, CharArgs e)
        {
            if (e.Event == KeyEvents.KeyDown)
            {
                this.commandController.AddKey(e.Key);
            }
        }
    }
}
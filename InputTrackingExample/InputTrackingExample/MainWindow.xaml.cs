using System;
using System.Windows;

namespace InputTrackingExample
{
    public partial class MainWindow : Window
    {
        private ActionController actionController;

        public MainWindow()
        {
            this.InitializeComponent();
            this.actionController = new ActionController();
            this.actionController.MessageAction += this.ActionController_MessageAction;
        }

        protected sealed override void OnClosed(EventArgs e)
        {
            this.actionController.Dispose();
            base.OnClosed(e);
        }

        private void ActionController_MessageAction(string message)
        {
            this.richTextBox.AppendText(message);
        }
    }
}
using System;
using System.Windows.Forms;

namespace NetTelebot.Commands.TestApplication
{
    public partial class frmMain : Form
    {
        private readonly CalculatorBot bot = new CalculatorBot("");
        public frmMain()
        {
            InitializeComponent();
            bot.MessageReceived += Bot_MessageReceived;
        }

        private void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<object, MessageEventArgs>(Bot_MessageReceived), sender, e);
            }
            else
            {
                txtLog.Text += $"{e.Message.From.FirstName} : {e.Message.Text}\r\n";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bot.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bot.Stop();
        }
    }
}

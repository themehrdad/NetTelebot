using System;
using System.Windows.Forms;
using NetTelebot.Commands.TestApplication.Properties;
using NetTelebot.CommonUtils;


namespace NetTelebot.Commands.TestApplication
{
    public partial class FormMain : Form
    {
        private const string mBotName = "NetTelebotBot";

        private readonly CalculatorBot mBot;

        public FormMain()
        {
            var token = WindowsCredential.GetTelegramCredential(mBotName).Token;

            mBot = new CalculatorBot(token);
            mBot.MessageReceived += Bot_MessageReceived;

            InitializeComponent();
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
            mBot.Start();
            txtLog.Text += Resources.BotStart;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mBot.Stop();
            txtLog.Text += Resources.BotStop;
        }
    }
}

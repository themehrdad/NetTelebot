using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetTelebot.Commands.TestApplication
{
    public partial class frmMain : Form
    {
        private CalculatorBot bot = new CalculatorBot("118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0");
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
                txtLog.Text += string.Format("{0} : {1}\r\n", e.Message.From.FirstName, e.Message.Text);
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

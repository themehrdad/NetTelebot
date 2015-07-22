using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(MessageInfo message)
        {
            Message = message;
        }
        public MessageInfo Message { get; private set; }
    }
}

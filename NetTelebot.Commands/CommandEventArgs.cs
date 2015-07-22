using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands
{
    public class CommandEventArgs : EventArgs
    {
        public CommandEventArgs(MessageInfo message, CommandInfo command)
        {
            Message = message;
            Command = command;
        }
        public MessageInfo Message { get; private set; }
        public CommandInfo Command { get; private set; }
    }
}

using System;
using NetTelebot.Type;

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

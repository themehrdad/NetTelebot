using System;

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

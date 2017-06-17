using System.Collections.Generic;

namespace NetTelebot.Commands
{
    public class BotConfiguration
    {
        public BotConfiguration()
        {
            Commands = new List<CommandInfo>();
        }
        public List<CommandInfo> Commands { get; private set; }
        public string StaticUnknownCommandMessage { get; set; }
    }
}

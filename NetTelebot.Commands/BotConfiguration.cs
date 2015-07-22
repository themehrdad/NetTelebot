using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

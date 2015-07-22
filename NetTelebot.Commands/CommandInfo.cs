using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands
{
    public class CommandInfo
    {
        public CommandInfo(string text)
        {
            Text = text;
            Parameters = new List<ParameterInfo>();
        }
        public string Text { get; private set; }
        public string StaticAcceptMessage { get; set; }
        public List<ParameterInfo> Parameters { get; private set; }
    }
}

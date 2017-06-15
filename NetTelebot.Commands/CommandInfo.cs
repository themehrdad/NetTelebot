using System.Collections.Generic;

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

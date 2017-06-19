using System.Collections.Generic;

namespace NetTelebot.Commands
{
    internal class CommandState
    {
        public CommandState()
        {
            Parameters = new List<object>();
        }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string CommandText { get; set; }
        public List<object> Parameters { get; private set; }
    }
}

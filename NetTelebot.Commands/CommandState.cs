using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands
{
    internal class CommandState
    {
        public CommandState()
        {
            Parameters = new List<object>();
        }
        public int chatId { get; set; }
        public int userId { get; set; }
        public string commandText { get; set; }
        public List<object> Parameters { get; private set; }
    }
}

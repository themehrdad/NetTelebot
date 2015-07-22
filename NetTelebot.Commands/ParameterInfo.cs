using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands
{
    public class ParameterInfo
    {
        public string Name { get; set; }
        public ParameterTypes Type { get; set; }
        public string StaticPrompt { get; set; }
        public bool Optional { get; set; }
        public string EmptyValue { get; set; }

    }
}

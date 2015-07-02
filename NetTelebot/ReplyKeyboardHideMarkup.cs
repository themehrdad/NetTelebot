using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class ReplyKeyboardHideMarkup : IReplyMarkup
    {
        public bool HideKeyboard { get; private set; } = true;
        public bool? Selective { get; set; }

        public string GetJson()
        {
            var builder = new StringBuilder();
            builder.Append("{ \"hide_keyboard\" : true ");
            if(Selective.HasValue)
            {
                builder.AppendFormat(", \"selective\" : {0} ", Selective.Value.ToString().ToLower());
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}

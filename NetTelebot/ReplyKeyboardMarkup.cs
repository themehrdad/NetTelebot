using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        public string[][] Keyboard { get; set; }
        public bool? ResizeKeyboard { get; set; }
        public bool? OneTimeKeyboard { get; set; }
        public bool? Selective { get; set; }

        public string GetJson()
        {
            var builder = new StringBuilder();
            var keyboard = GetKeyboardJson();
            builder.AppendFormat("{{ \"keyboard\" : [{0}] ",keyboard);
            if (ResizeKeyboard.HasValue)
                builder.AppendFormat(", \"resize_keyboard\" : {0} ", ResizeKeyboard.Value.ToString().ToLower());
            if (OneTimeKeyboard.HasValue)
                builder.AppendFormat(", \"one_time_keyboard\" : {0} ", OneTimeKeyboard.Value.ToString().ToLower());
            if (Selective.HasValue)
                builder.AppendFormat(", \"selective\" : {0} ", Selective.Value.ToString().ToLower());
            builder.Append("}");
            return builder.ToString();
        }

        private string GetKeyboardJson()
        {
            return string.Join(",", Keyboard.Select(line =>
                string.Format("[{0}]",
                    string.Join(",",
                        line.Select(item => string.Format("\"{0}\"", item)).ToArray()))).ToArray());
        }
    }
}

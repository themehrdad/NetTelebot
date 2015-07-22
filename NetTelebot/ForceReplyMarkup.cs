using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user (act as if the user has selected the bot‘s message and tapped ’Reply'). 
    /// </summary>
    public class ForceReplyMarkup : IReplyMarkup
    {
        public ForceReplyMarkup()
        {
            ForceReply = true;
        }
        /// <summary>
        /// Shows reply interface to the user, as if they manually selected the bot‘s message and tapped ’Reply'
        /// </summary>
        public bool ForceReply { get; private set; }
        /// <summary>
        /// Optional. Use this parameter if you want to force reply from specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        public bool? Selective { get; set; }

        public string GetJson()
        {
            var builder = new StringBuilder();
            builder.Append("{ \"force_reply\" : true ");
            if (Selective.HasValue)
            {
                builder.AppendFormat(", \"selective\" : {0} ", Selective.Value.ToString().ToLower());
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}

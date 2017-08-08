using NetTelebot.Interface;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Keyboard
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user 
    /// (act as if the user has selected the bot‘s message and tapped ’Reply'). This can be extremely useful if you want to create user-friendly step-by-step
    /// interfaces without having to sacrifice privacy mode.
    /// See <see href="https://core.telegram.org/bots/api#forcereply">API</see>
    /// Since the value "force_reply: false" does not make sense, the field of the class of this value is missing
    /// </summary>
    public class ForceReplyMarkup : IReplyMarkup
    {
        /// <summary>
        /// Gets the string json object ForceReplyMarkup.
        /// </summary>
        public string GetJson()
        {
            dynamic forceReply = new JObject();
            
            forceReply.force_reply = true;

            if (Selective.HasValue)
                forceReply.selective = Selective;
            
            return forceReply.ToString();
        }

        /// <summary>
        /// Optional. Use this parameter if you want to force reply from specific users only. 
        /// Targets: 
        /// 1) users that are @mentioned in the text of the Message object; 
        /// 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        public bool? Selective { get; set; }
    }
}

using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents an incoming callback query from a callback button in an inline keyboard. 
    /// If the button that originated the query was attached to a message sent by the bot, the field message will be present. 
    /// If the button was attached to a message sent via the bot (in inline mode), the field inline_message_id will be present. 
    /// Exactly one of the fields data or game_short_name will be present.
    /// </summary>
    public class CallbackQueryInfo
    {
        internal CallbackQueryInfo()
        {
        }

        internal CallbackQueryInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<string>();
            From = new UserInfo(jsonObject["from"].Value<JObject>());

            if (jsonObject["message"] != null)
                Message = new MessageInfo(jsonObject["message"].Value<JObject>());
            if (jsonObject["inline_message_id"] != null)
                InlineMessageId = jsonObject["inline_message_id"].Value<string>();

            ChatInstance = jsonObject["chat_instance"].Value<string>();

            if (jsonObject["data"] != null)
                Data = jsonObject["data"].Value<string>();
            if (jsonObject["game_short_name"] != null)
                GameShortName = jsonObject["game_short_name"].Value<string>();
        }

        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Sender
        /// </summary>
        public UserInfo From { get; private set; }

        /// <summary>
        /// Optional. 
        /// Message with the callback button that originated the query. 
        /// Note that message content and message date will not be available if the message is too old
        /// </summary>
        public MessageInfo Message { get; private set; }

        /// <summary>
        /// Optional. 
        /// Identifier of the message sent via the bot in inline mode, that originated the query.
        /// </summary>
        public string InlineMessageId { get; private set; }

        /// <summary>
        /// Global identifier, uniquely corresponding to the chat to which the message with the callback button was sent. 
        /// Useful for high scores in games.
        /// </summary>
        public string ChatInstance { get; private set;  }

        /// <summary>
        /// Optional. 
        /// Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field.
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// Optional. Short name of a Game to be returned, serves as the unique identifier for the game
        /// </summary>
        public string GameShortName { get; private set; }
    }
}

using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.InlineMode
{
    /// <summary>
    /// Represents a result of an inline query that was chosen by the user and sent to their chat partner.
    /// Note: 
    /// It is necessary to enable inline feednack via @Botfather in order to receive these objects in updates.
    /// See <see href="https://core.telegram.org/bots/api#choseninlineresult">API</see> 
    /// </summary>
    public class ChosenInlineResultInfo
    {
        internal ChosenInlineResultInfo()
        {
        }

        internal ChosenInlineResultInfo(JObject jsonObject)
        {
            ResultId = jsonObject["result_id"].Value<string>();
            From = new UserInfo(jsonObject["from"].Value<JObject>());

            if (jsonObject["location"] != null)
                Location = new LocationInfo(jsonObject["location"].Value<JObject>());
            if (jsonObject["inline_message_id"] != null)
                InlineMessageId = jsonObject["inline_message_id"].Value<string>();
            if (jsonObject["query"] != null)
                Query = jsonObject["query"].Value<string>();
        }

        /// <summary>
        /// The unique identifier for the result that was chosen
        /// </summary>
        public string ResultId { get; private set; }

        /// <summary>
        /// The user that chose the result
        /// </summary>
        public UserInfo From { get; internal set; }

        /// <summary>
        /// Optional. Sender location, only for bots that require user location
        /// </summary>
        public LocationInfo Location { get; internal set; }

        /// <summary>
        /// Optional. 
        /// Identifier of the sent inline message. Available only if there is an inline keyboard attached to the message. 
        /// Will be also received in callback queries and can be used to edit the message.
        /// </summary>
        public string InlineMessageId { get; private set; }

        /// <summary>
        /// The query that was used to obtain the result
        /// </summary>
        public string Query { get; private set; }
    }
}

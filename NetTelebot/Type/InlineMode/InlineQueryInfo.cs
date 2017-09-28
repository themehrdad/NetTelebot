using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.InlineMode
{
    /// <summary>
    /// This object represents an incoming inline query. 
    /// When the user sends an empty query, your bot could return some default or trending results.
    /// See <see href="https://core.telegram.org/bots/api#choseninlineresult">API</see> 
    /// </summary>
    public class InlineQueryInfo
    {
        internal InlineQueryInfo()
        {
        }

        internal InlineQueryInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<string>();
            From = new UserInfo(jsonObject["from"].Value<JObject>());

            if (jsonObject["location"] != null)
                Location = new LocationInfo(jsonObject["location"].Value<JObject>());
            
            Query = jsonObject["query"].Value<string>();
            Offset= jsonObject["offset"].Value<string>();
        }

        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Sender
        /// </summary>
        public UserInfo From { get; internal set; }

        /// <summary>
        /// Optional. 
        /// Sender location, only for bots that request user location
        /// </summary>
        public LocationInfo Location { get; internal set; }

        /// <summary>
        /// Text of the query (up to 512 characters)
        /// </summary>
        public string Query { get; private set; }

        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot
        /// </summary>
        public string Offset { get; private set; }
    }
}

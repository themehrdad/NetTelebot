using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
    /// See <see href="https://core.telegram.org/bots/api#messageentity">API</see>
    /// </summary>
    public class MessageEntityInfo
    {
        internal MessageEntityInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Type = jsonObject["type"].Value<string>();
            Offset = jsonObject["offset"].Value<int>();
            Length = jsonObject["length"].Value<int>();

            if (jsonObject["url"] != null)
                Url = jsonObject["url"].Value<string>();
            if (jsonObject["user"] != null)
                User = new UserInfo(jsonObject["user"].Value<JObject>());
        }

        /// <summary>
        /// Type of the entity. Can be mention (@username), hashtag, bot_command, url, email, bold (bold text),
        /// italic (italic text), code (monowidth string), pre (monowidth block), text_link (for clickable text URLs),
        /// text_mention (for users without usernames)
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Offset in UTF-16 code units to the start of the entity
        /// </summary>
        public int Offset { get; private set;  }

        /// <summary>
        /// Length of the entity in UTF-16 code units
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Optional. For “text_link” only, url that will be opened after user taps on the text
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Optional. For “text_mention” only, the mentioned user
        /// </summary>
        public UserInfo User { get; internal set;  }

        internal static MessageEntityInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new MessageEntityInfo(jobject)).ToArray();
        }


    }
}

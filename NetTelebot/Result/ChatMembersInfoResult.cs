using NetTelebot.Type;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Result
{
    /// <summary>
    /// When calling method returned array of <see cref="ChatMemberInfo"/> in result field on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class ChatMembersInfoResult
    {
        internal ChatMembersInfoResult(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = ChatMemberInfo.ParseArray(jsonObject["result"].Value<JArray>());
        }

        /// <summary>
        /// Result request
        /// </summary>
        /// <value>
        ///   <c>true</c> if ok; otherwise, <c>false</c>.
        /// </value>
        public bool Ok { get; private set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public ChatMemberInfo[] Result { get; private set; }
    }
}

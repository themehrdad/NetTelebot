
using NetTelebot.Type;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Result
{
    /// <summary>
    /// When calling method returned <see cref="ChatInfo"/> in result field on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class ChatInfoResult
    {
        internal ChatInfoResult(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = new ChatInfo(jsonObject["result"].Value<JObject>());
        }

        /// <summary>
        /// Result request.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ok; otherwise, <c>false</c>.
        /// </value>
        public bool Ok { get; private set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result is instance of the <see cref="MessageInfo"/> class
        /// </value>
        public ChatInfo Result { get; private set; }
    }
}

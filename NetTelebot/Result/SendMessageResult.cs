
using NetTelebot.Type;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Result
{
    /// <summary>
    /// When calling method returned <see cref="MessageInfo"/> in result field on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class SendMessageResult
    {
        internal SendMessageResult(string jsonText)
        {
            Parse(jsonText);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = new MessageInfo(jsonObject["result"].Value<JObject>());
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
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
        public MessageInfo Result { get; private set; }
    }
}

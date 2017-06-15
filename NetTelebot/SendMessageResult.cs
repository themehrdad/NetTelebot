using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#pragma warning disable 1591

namespace NetTelebot
{
    /// <summary>
    /// When calling SendMessage method on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class SendMessageResult
    {
        internal SendMessageResult(string jsonText)
        {
            Parse(jsonText);
        }

        internal SendMessageResult(JObject jsonObject)
        {
            Parse(jsonObject);
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

        public bool Ok { get; private set; }
        public MessageInfo Result { get; private set; }
    }
}

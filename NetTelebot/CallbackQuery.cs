using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot
{
    public class CallbackQuery
    {
        public ulong ID { get; private set; }
        public UserInfo From { get; private set; }
        public MessageInfo Message { get; private set; }
        public int InlineMessageId { get; private set; }
        public string Data { get; private set; }

        internal CallbackQuery(string jsonText)
        {
            Parse(jsonText);
        }

        internal CallbackQuery(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            ID = jsonObject["id"].Value<ulong>();
            if (jsonObject["from"] != null)
                From = new UserInfo(jsonObject["from"].Value<JObject>());
            if (jsonObject["message"] != null)
                Message = new MessageInfo(jsonObject["message"].Value<JObject>());
            if (jsonObject["data"] != null)
                Data = jsonObject["data"].Value<string>();
            if (jsonObject["inline_message_id"] != null)
                InlineMessageId = jsonObject["inline_message_id"].Value<int>();
        }
    }
}
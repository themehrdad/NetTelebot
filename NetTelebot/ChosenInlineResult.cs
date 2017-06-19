using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot
{
    public class ChosenInlineResult
    {
        public ulong ResultID { get; private set; }
        public UserInfo From { get; private set; }
        public LocationInfo Location { get; private set; }
        public int InlineMessageId { get; private set; }
        public string Query { get; private set; }

        internal ChosenInlineResult(string jsonText)
        {
            Parse(jsonText);
        }

        public ChosenInlineResult(JObject jsonObject)
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
            ResultID = jsonObject["id"].Value<ulong>();
            if (jsonObject["from"] != null)
                From = new UserInfo(jsonObject["from"].Value<JObject>());
            if (jsonObject["location"] != null)
                Location = new LocationInfo(jsonObject["location"].Value<JObject>());
            if (jsonObject["query"] != null)
                Query = jsonObject["query"].Value<string>();
            if (jsonObject["inline_message_id"] != null)
                InlineMessageId = jsonObject["inline_message_id"].Value<int>();
        }
    }
}
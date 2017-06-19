using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot
{
    public class InlineQuery
    {
        public ulong ID { get; private set; }
        public UserInfo From { get; private set; }
        public LocationInfo Location { get; private set; }
        public string Query { get; private set; }
        public string Offset { get; private set; }

        internal InlineQuery(string jsonText)
        {
            Parse(jsonText);
        }

        internal InlineQuery(JObject jsonObject)
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
            if (jsonObject["location"] != null)
                Location = new LocationInfo(jsonObject["location"].Value<JObject>());
            if (jsonObject["query"] != null)
                Query = jsonObject["query"].Value<string>();
            if (jsonObject["offset"] != null)
                Offset = jsonObject["offset"].Value<string>();
        }
    }
}
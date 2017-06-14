using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot
{
    /// <summary>
    /// When calling GetUpdates method on TelegramBotClient, this object will be returned.
    /// </summary>
    public class GetUpdatesResult
    {
        internal GetUpdatesResult(string jsonText)
        {
            Parse(jsonText);
        }

        internal GetUpdatesResult(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = UpdateInfo.ParseArray(jsonObject["result"].Value<JArray>());
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        public bool Ok { get; private set; }
        public UpdateInfo[] Result { get; private set; }
    }
}

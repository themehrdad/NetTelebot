using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    /// <summary>
    /// Represents an incoming message to your bot.
    /// </summary>
    public class UpdateInfo
    {
        internal UpdateInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal UpdateInfo(JObject jsonObject)
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
            UpdateId = jsonObject["update_id"].Value<int>();
            if (jsonObject["message"] != null)
                Message = new MessageInfo(jsonObject["message"].Value<JObject>());
        }

        public int UpdateId { get; private set; }
        public MessageInfo Message { get; private set; }

        public static UpdateInfo[] ParseArray(string jsonText)
        {
            var jsonArray = (JArray)JsonConvert.DeserializeObject(jsonText);
            return ParseArray(jsonArray);
        }

        public static UpdateInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new UpdateInfo(jobject)).ToArray();
        }
    }
}

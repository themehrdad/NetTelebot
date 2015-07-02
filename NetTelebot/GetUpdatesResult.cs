using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class GetUpdatesResult
    {
        public GetUpdatesResult(string jsonText)
        {
            Parse(jsonText);
        }

        public GetUpdatesResult(JObject jsonObject)
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

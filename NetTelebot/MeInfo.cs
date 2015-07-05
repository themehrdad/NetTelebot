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
    /// When caling GetMe method on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class MeInfo
    {
        internal MeInfo(string jsonText)
        {
            try
            {
                Parse(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JSON parse error", ex);
            }
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Id = jsonObject["result"]["id"].Value<string>();
            FirstName = jsonObject["result"]["first_name"].Value<string>();
            UserName = jsonObject["result"]["username"].Value<string>();
        }

        public bool Ok { get; private set; }
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string UserName { get; private set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class GetUserProfilePhotosResult
    {
        public GetUserProfilePhotosResult(string jsonText)
        {
            Parse(jsonText);
        }
        public GetUserProfilePhotosResult(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = new UserProfilePhotosInfo(jsonObject["result"].Value<JObject>());
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        public bool Ok { get; private set; }
        public UserProfilePhotosInfo Result { get; private set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class UserProfilePhotosInfo
    {
        public UserProfilePhotosInfo(string jsonText)
        {
            Parse(jsonText);
        }

        public UserProfilePhotosInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            TotalCount = jsonObject["total_count"].Value<int>();
            var arrayOfArrays = jsonObject["photos"].Value<JArray>();
            Photos =
                arrayOfArrays.Cast<JArray>().Select(array => PhotoSizeInfo.ParseArray(array)).ToArray();
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        public int TotalCount { get; set; }
        public PhotoSizeInfo[][] Photos { get; set; }
    }
}

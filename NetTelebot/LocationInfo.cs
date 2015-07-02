using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class LocationInfo
    {
        public LocationInfo(string jsonText)
        {
            Parse(jsonText);
        }
        public LocationInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Longitude = jsonObject["longitude"].Value<float>();
            Latitude = jsonObject["latitude"].Value<float>();
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}

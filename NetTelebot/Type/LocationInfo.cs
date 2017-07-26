using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a point on the map.
    /// </summary>
    public class LocationInfo
    {
        internal LocationInfo()
        {
        }

        internal LocationInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal LocationInfo(JObject jsonObject)
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

        /// <summary>
        /// Longitude as defined by sender
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Latitude as defined by sender
        /// </summary>
        public float Latitude { get; set; }
    }
}

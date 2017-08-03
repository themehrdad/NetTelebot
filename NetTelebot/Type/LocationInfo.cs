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

        internal LocationInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Longitude = jsonObject["longitude"].Value<float>();
            Latitude = jsonObject["latitude"].Value<float>();
        }

        /// <summary>
        /// Longitude as defined by sender
        /// </summary>
        public float Longitude { get; private set; }

        /// <summary>
        /// Latitude as defined by sender
        /// </summary>
        public float Latitude { get; private set; }
    }
}

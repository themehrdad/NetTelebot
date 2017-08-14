using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class LocationInfoObject
    {
        /// <summary>
        /// This object represents a point on the map. 
        /// See <see href="https://core.telegram.org/bots/api#location">API</see>
        /// </summary>
        /// <param name="longitude">Longitude as defined by sender</param>
        /// <param name="latitude">Latitude as defined by sender</param>
        /// <returns><see cref="Type.LocationInfo"/></returns>
        internal static JObject GetObject(float longitude, float latitude)
        {
            dynamic locationInfo = new JObject();

            locationInfo.longitude = longitude;
            locationInfo.latitude = latitude;
            
            return locationInfo;
        }
    }
}
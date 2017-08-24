using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class VenueInfoObject
    {

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <param name="location">Venue location</param>
        /// <param name="title">Name of the venue</param>
        /// <param name="address">Address of the venue</param>
        /// <param name="foursquareId">Optional. Foursquare identifier of the venue</param>
        /// <returns></returns>
        internal static JObject GetObject(JObject location, string title, 
            string address, string foursquareId = null)
        {
            dynamic venueInfo = new JObject();

            venueInfo.location = location;
            venueInfo.title = title;
            venueInfo.address = address;
            if (foursquareId != null)
                venueInfo.foursquare_id = foursquareId;
            
            return venueInfo;
        }
    }
}

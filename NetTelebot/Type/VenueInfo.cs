using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a venue.
    /// </summary>
    public class VenueInfo
    {
        internal VenueInfo()
        {
        }

        internal VenueInfo(JObject jsonObject)
        {
            Location = new LocationInfo(jsonObject["location"].Value<JObject>());
            Title= jsonObject["title"].Value<string>();
            Address = jsonObject["address"].Value<string>();
            if (jsonObject["foursquare_id"] != null)
                FoursquareId = jsonObject["foursquare_id"].Value<string>();
        }

        /// <summary>
        /// Venue location
        /// </summary>
        public LocationInfo Location { get; internal set; }

        /// <summary>
        /// Name of the venue
        /// </summary>
        public string Title {get; private set; }

        /// <summary>
        /// Address of the venue
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Optional. 
        /// Foursquare identifier of the venue
        /// </summary>
        public string FoursquareId { get; private set; }
    }
}

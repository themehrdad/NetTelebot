using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using NetTelebot.Type;

namespace NetTelebot
{
    /// <summary>
    /// This object represent a user's profile pictures.
    /// </summary>
    public class UserProfilePhotosInfo
    {
        internal UserProfilePhotosInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal UserProfilePhotosInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            TotalCount = jsonObject["total_count"].Value<int>();
            JArray arrayOfArrays = jsonObject["photos"].Value<JArray>();
            Photos = arrayOfArrays.Cast<JArray>().Select(PhotoSizeInfo.ParseArray).ToArray();
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        /// <summary>
        /// Total number of profile pictures the target user has
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Requested profile pictures (in up to 4 sizes each)
        /// </summary>
        public PhotoSizeInfo[][] Photos { get; set; }
    }
}

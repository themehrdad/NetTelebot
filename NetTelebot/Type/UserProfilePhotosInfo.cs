using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represent a user's profile pictures.
    /// </summary>
    public class UserProfilePhotosInfo
    {

        internal UserProfilePhotosInfo(JObject jsonObject)
        {
            TotalCount = jsonObject["total_count"].Value<int>();
            JArray arrayOfArrays = jsonObject["photos"].Value<JArray>();
            Photos = arrayOfArrays.Cast<JArray>().Select(PhotoSizeInfo.ParseArray).ToArray();
        }

        /// <summary>
        /// Total number of profile pictures the target user has
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Requested profile pictures (in up to 4 sizes each)
        /// </summary>
        public PhotoSizeInfo[][] Photos { get; private set; }
    }
}

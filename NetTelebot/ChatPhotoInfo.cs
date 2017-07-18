using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot
{
    /// <summary>
    /// This object represents a chat photo.
    /// </summary>
    public class ChatPhotoInfo
    {
        internal ChatPhotoInfo()
        {
        }

        internal ChatPhotoInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal ChatPhotoInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject) JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            if (jsonObject["small_file_id"] != null)
                SmallFileId = jsonObject["small_file_id"].Value<string>();
            if (jsonObject["big_file_id"] != null)
                BigFileId = jsonObject["big_file_id"].Value<string>();
        }

        /// <summary>
        /// Unique file identifier of small (160x160) chat photo. This file_id can be used only for photo download.
        /// </summary>
        public string SmallFileId { get; private set; }

        /// <summary>
        /// Unique file identifier of big (640x640) chat photo. This file_id can be used only for photo download.
        /// </summary>
        public string BigFileId { get; private set; }
    }
}

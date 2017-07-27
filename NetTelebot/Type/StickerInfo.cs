using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    public class StickerInfo
    {
        internal StickerInfo()
        {
        }

        internal StickerInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal StickerInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Width = jsonObject["width"].Value<int>();
            Height = jsonObject["height"].Value<int>();
            if (jsonObject["thumb"] != null)
                Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["emoji"] != null)
                Emoji = jsonObject["emoji"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Sticker width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Sticker height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Optional. Sticker thumbnail in .webp or .jpg format
        /// </summary>
        public PhotoSizeInfo Thumb { get; set; }

        /// <summary>
        /// Optional. Emoji associated with the sticker
        /// </summary>
        public string Emoji { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; set; }
    }
}

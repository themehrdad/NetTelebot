using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Sticker
{
    /// <summary>
    /// This object represents a sticker.
    /// See <see href="https://core.telegram.org/bots/api#sticker">API</see>
    /// </summary>
    public class StickerInfo
    {
        internal StickerInfo()
        {
        }
        
        internal StickerInfo(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Width = jsonObject["width"].Value<int>();
            Height = jsonObject["height"].Value<int>();
            if (jsonObject["thumb"] != null)
                Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["emoji"] != null)
                Emoji = jsonObject["emoji"].Value<string>();
            if (jsonObject["set_name"] != null)
                SetName = jsonObject["set_name"].Value<string>();
            if (jsonObject["mask_position"] != null)
                MaskPosition = new MaskPositionInfo(jsonObject["mask_position"].Value<JObject>());
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; private set; }

        /// <summary>
        /// Sticker width
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Sticker height
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Optional. Sticker thumbnail in .webp or .jpg format
        /// </summary>
        public PhotoSizeInfo Thumb { get; internal set; }

        /// <summary>
        /// Optional. Emoji associated with the sticker
        /// </summary>
        public string Emoji { get; set; }

        /// <summary>
        /// Optional. Name of the sticker set to which the sticker belongs
        /// </summary>
        public string SetName { get; private set; }

        /// <summary>
        /// Optional. For mask stickers, the position where the mask should be placed
        /// </summary>
        public MaskPositionInfo MaskPosition { get; private set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; set; }

        internal static StickerInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new StickerInfo(jobject)).ToArray();
        }
    }
}

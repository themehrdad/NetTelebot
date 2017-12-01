using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Sticker
{
    /// <summary>
    /// This object represents a sticker set
    /// </summary>
    public class StickerSetInfo
    {
        internal StickerSetInfo(JObject jsonObject)
        {
            //todo add result object for this ans test
            Name = jsonObject["name"].Value<string>();
            Title = jsonObject["title"].Value<string>();
            ContainsMask = jsonObject["contains_masks"].Value<bool>();
            Stickers = StickerInfo.ParseArray(jsonObject["stickers"].Value<JArray>());
        }

        /// <summary>
        /// Sticker set name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Sticker set title
        /// </summary>
        public string Title { get; private set;  }

        /// <summary>
        /// True, if the sticker set contains masks
        /// </summary>
        public bool ContainsMask { get; private set; }

        /// <summary>
        /// List of all set stickers
        /// </summary>
        public StickerInfo[] Stickers { get; private set; }
    }
}

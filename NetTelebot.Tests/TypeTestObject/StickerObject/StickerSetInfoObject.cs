using NetTelebot.Result;
using NetTelebot.Type.Sticker;
using Newtonsoft.Json;

namespace NetTelebot.Tests.TypeTestObject.StickerObject
{
    internal class StickerSetInfoObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("contains_masks")]
        public bool ContainsMask { get; set; }

        [JsonProperty("stickers")]
        public StickerInfoObject[] Stickers { get; set; }
    }
}

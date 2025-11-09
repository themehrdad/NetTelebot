using Newtonsoft.Json;

namespace NetTelebot.Type
{
    /// <summary>
    /// Describes the options used for link preview generation.
    /// See <see href="https://core.telegram.org/bots/api#linkpreviewoptions">API</see>
    /// </summary>
    public class LinkPreviewOptions
    {
        /// <summary>
        /// Optional. True, if the link preview is disabled
        /// </summary>
        [JsonProperty("is_disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDisabled { get; set; }

        /// <summary>
        /// Optional. URL to use for the link preview. If empty, then the first URL found in the message text will be used
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Optional. True, if the media in the link preview is supposed to be shrunk; ignored if the URL isn't explicitly specified or media size change isn't supported for the preview
        /// </summary>
        [JsonProperty("prefer_small_media", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PreferSmallMedia { get; set; }

        /// <summary>
        /// Optional. True, if the media in the link preview is supposed to be enlarged; ignored if the URL isn't explicitly specified or media size change isn't supported for the preview
        /// </summary>
        [JsonProperty("prefer_large_media", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PreferLargeMedia { get; set; }

        /// <summary>
        /// Optional. True, if the link preview must be shown above the message text; otherwise, the link preview will be shown below the message text
        /// </summary>
        [JsonProperty("show_above_text", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowAboveText { get; set; }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

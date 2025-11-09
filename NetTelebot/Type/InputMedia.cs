using NetTelebot.BotEnum;
using NetTelebot.Interface;
using Newtonsoft.Json;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents the content of a media message to be sent. It should be one of
    /// InputMediaAnimation, InputMediaDocument, InputMediaAudio, InputMediaPhoto, InputMediaVideo
    /// See <see href="https://core.telegram.org/bots/api#inputmedia">API</see>
    /// </summary>
    public abstract class InputMedia
    {
        /// <summary>
        /// Type of the result
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public abstract string Type { get; }

        /// <summary>
        /// File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL for Telegram to get a file from the Internet, or pass "attach://<file_attach_name>"
        /// to upload a new one using multipart/form-data under <file_attach_name> name.
        /// </summary>
        [JsonProperty("media", Required = Required.Always)]
        public string Media { get; set; }

        /// <summary>
        /// Optional. Caption of the media to be sent, 0-1024 characters after entities parsing
        /// </summary>
        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }

        /// <summary>
        /// Optional. Mode for parsing entities in the media caption
        /// </summary>
        [JsonProperty("parse_mode", NullValueHandling = NullValueHandling.Ignore)]
        public ParseMode? ParseMode { get; set; }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// Represents a photo to be sent.
    /// See <see href="https://core.telegram.org/bots/api#inputmediaphoto">API</see>
    /// </summary>
    public class InputMediaPhoto : InputMedia
    {
        public override string Type => "photo";

        /// <summary>
        /// Optional. Pass True if the photo needs to be covered with a spoiler animation
        /// </summary>
        [JsonProperty("has_spoiler", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasSpoiler { get; set; }
    }

    /// <summary>
    /// Represents a video to be sent.
    /// See <see href="https://core.telegram.org/bots/api#inputmediavideo">API</see>
    /// </summary>
    public class InputMediaVideo : InputMedia
    {
        public override string Type => "video";

        /// <summary>
        /// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side
        /// </summary>
        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Optional. Video width
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        /// <summary>
        /// Optional. Video height
        /// </summary>
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        /// <summary>
        /// Optional. Video duration in seconds
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get; set; }

        /// <summary>
        /// Optional. Pass True if the uploaded video is suitable for streaming
        /// </summary>
        [JsonProperty("supports_streaming", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SupportsStreaming { get; set; }

        /// <summary>
        /// Optional. Pass True if the video needs to be covered with a spoiler animation
        /// </summary>
        [JsonProperty("has_spoiler", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasSpoiler { get; set; }
    }

    /// <summary>
    /// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound) to be sent.
    /// See <see href="https://core.telegram.org/bots/api#inputmediaanimation">API</see>
    /// </summary>
    public class InputMediaAnimation : InputMedia
    {
        public override string Type => "animation";

        /// <summary>
        /// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side
        /// </summary>
        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Optional. Animation width
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        /// <summary>
        /// Optional. Animation height
        /// </summary>
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        /// <summary>
        /// Optional. Animation duration in seconds
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get; set; }

        /// <summary>
        /// Optional. Pass True if the animation needs to be covered with a spoiler animation
        /// </summary>
        [JsonProperty("has_spoiler", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasSpoiler { get; set; }
    }

    /// <summary>
    /// Represents an audio file to be treated as music to be sent.
    /// See <see href="https://core.telegram.org/bots/api#inputmediaaudio">API</see>
    /// </summary>
    public class InputMediaAudio : InputMedia
    {
        public override string Type => "audio";

        /// <summary>
        /// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side
        /// </summary>
        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Optional. Duration of the audio in seconds
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get; set; }

        /// <summary>
        /// Optional. Performer of the audio
        /// </summary>
        [JsonProperty("performer", NullValueHandling = NullValueHandling.Ignore)]
        public string Performer { get; set; }

        /// <summary>
        /// Optional. Title of the audio
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }

    /// <summary>
    /// Represents a general file to be sent.
    /// See <see href="https://core.telegram.org/bots/api#inputmediadocument">API</see>
    /// </summary>
    public class InputMediaDocument : InputMedia
    {
        public override string Type => "document";

        /// <summary>
        /// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side
        /// </summary>
        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Optional. Disables automatic server-side content type detection for files uploaded using multipart/form-data.
        /// Always True, if the document is sent as part of an album.
        /// </summary>
        [JsonProperty("disable_content_type_detection", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisableContentTypeDetection { get; set; }
    }
}

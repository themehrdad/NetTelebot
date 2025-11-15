using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Games
{
    /// <summary>
    /// You can provide an animation for your <see href="https://core.telegram.org/bots/api#game">game</see> 
    /// so that it looks stylish in chats (check out <see href="https://t.me/gamebot">Lumberjack</see> for an example). 
    /// This object represents an animation file to be displayed in the message containing a <see href="https://core.telegram.org/bots/api#games">game</see>.
    /// See <see href="https://core.telegram.org/bots/api#animation">API</see>
    /// </summary>
    public class AnimationInfo
    {
        internal AnimationInfo()
        {  
        }

        internal AnimationInfo(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            if (jsonObject["file_unique_id"] != null)
                FileUniqueId = jsonObject["file_unique_id"].Value<string>();
            if (jsonObject["width"] != null)
                Width = jsonObject["width"].Value<int>();
            if (jsonObject["height"] != null)
                Height = jsonObject["height"].Value<int>();
            if (jsonObject["duration"] != null)
                Duration = jsonObject["duration"].Value<int>();
            if (jsonObject["thumb"] != null)
                Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["thumbnail"] != null)
                Thumbnail = new PhotoSizeInfo(jsonObject["thumbnail"].Value<JObject>());
            if (jsonObject["file_name"] != null)
                FileName = jsonObject["file_name"].Value<string>();
            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<long>();
        }

        /// <summary>
        /// Unique file identifier
        /// </summary>
        public string FileId { get; private set; }

        /// <summary>
        /// Unique identifier for this file, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
        /// </summary>
        public string FileUniqueId { get; private set; }

        /// <summary>
        /// Video width as defined by sender
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Video height as defined by sender
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// Optional. Animation thumbnail as defined by sender (deprecated, use Thumbnail)
        /// </summary>
        public PhotoSizeInfo Thumb { get; internal set; }

        /// <summary>
        /// Optional. Animation thumbnail as defined by sender
        /// </summary>
        public PhotoSizeInfo Thumbnail { get; internal set; }

        /// <summary>
        /// Optional. Original animation filename as defined by sender
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        public string MimeType { get; private set; }

        /// <summary>
        /// Optional. File size in bytes
        /// </summary>
        public long FileSize { get; private set; }
    }
}

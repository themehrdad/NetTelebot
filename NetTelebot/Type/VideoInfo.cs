using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    public class VideoInfo
    {

        internal VideoInfo()
        {
        }

        internal VideoInfo(JObject jsonObject)

        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Width = jsonObject["width"].Value<int>();
            Height = jsonObject["height"].Value<int>();
            Duration = jsonObject["duration"].Value<int>();
            if (jsonObject["thumb"] != null)
                Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Video width as defined by sender
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Video height as defined by sender
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Optional. Video thumbnail
        /// </summary>
        public PhotoSizeInfo Thumb { get; set; }

        /// <summary>
        /// Optional. Mime type of a file as defined by sender
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; set; }
    }
}

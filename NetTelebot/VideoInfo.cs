using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    public class VideoInfo
    {
        internal VideoInfo(string jsonText)
        {
            Parse(jsonText);
        }
        internal VideoInfo(JObject jsonObject)
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
            Duration = jsonObject["duration"].Value<int>();
            Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
            if (jsonObject["caption"] != null)
                Caption = jsonObject["caption"].Value<string>();
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
        /// Video thumbnail
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
        /// <summary>
        /// Optional. Text description of the video (usually empty)
        /// </summary>
        public string Caption { get; set; }
    }
}

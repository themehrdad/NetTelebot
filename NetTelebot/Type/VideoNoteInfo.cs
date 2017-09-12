using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a video message (available in Telegram apps as of v.4.0).
    /// </summary>
    public class VideoNoteInfo
    {
        internal VideoNoteInfo()
        {
        }

        internal VideoNoteInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Length = jsonObject["length"].Value<int>();
            Duration = jsonObject["duration"].Value<int>();

            if (jsonObject["thumb"] != null)
                Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; private set; }

        /// <summary>
        /// Video width and height as defined by sender
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// Optional. Video thumbnail
        /// </summary>
        public PhotoSizeInfo Thumb { get; internal set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; private set; }

        

        

        

        
    }
}

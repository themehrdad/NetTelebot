using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a general file (as opposed to photos and audio files).
    /// See <see href="https://core.telegram.org/bots/api#document">API</see>
    /// </summary>
    public class DocumentInfo
    {
        internal DocumentInfo()
        {
        }

        internal DocumentInfo(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            if (jsonObject["thumb"] != null)
                Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["file_name"] != null)
                FileName = jsonObject["file_name"].Value<string>();
            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }
        
        /// <summary>
        /// Unique file identifier
        /// </summary>
        public string FileId { get; private set; }

        /// <summary>
        /// Optional. Document thumbnail as defined by sender
        /// </summary>
        public PhotoSizeInfo Thumb { get; internal set; }

        /// <summary>
        /// Optional. Original filename as defined by sender
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        public string MimeType { get; private set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; private set; }
    }
}

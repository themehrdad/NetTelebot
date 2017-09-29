using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a voice note.
    /// </summary>
    public class VoiceInfo
    {
        internal VoiceInfo()
        {
        }

        internal VoiceInfo(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Duration = jsonObject["duration"].Value<int>();

            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; private set;  }

        /// <summary>
        /// Duration of the audio in seconds as defined by sender
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        public string MimeType { get; private set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; private set;  }
    }
}

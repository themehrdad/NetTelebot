using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents an audio file (voice note).
    /// See <see href="https://core.telegram.org/bots/api#audio">API</see>
    /// </summary>
    public class AudioInfo
    {
        internal AudioInfo()
        {
        }

        internal AudioInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Duration = jsonObject["duration"].Value<int>();
            if (jsonObject["performer"] != null)
                Performer = jsonObject["performer"].Value<string>();
            if (jsonObject["title"] != null)
                Title = jsonObject["title"].Value<string>();
            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; private set; }

        /// <summary>
        /// Duration of the audio in seconds as defined by sender
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// Optional. Performer of the audio as defined by sender or by audio tags
        /// </summary>
        public string Performer { get; private set; }

        /// <summary>
        /// Optional. Title of the audio as defined by sender or by audio tags
        /// </summary>
        public string Title { get; private set; }

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

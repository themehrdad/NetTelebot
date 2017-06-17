using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace NetTelebot
{
    /// <summary>
    /// This object represents an audio file (voice note).
    /// </summary>
    public class AudioInfo
    {
        internal AudioInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        internal AudioInfo(string jsonText)
        {
            Parse(jsonText);
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Duration = jsonObject["duration"].Value<int>();
            if (jsonObject["performer"] != null)
                Performer = jsonObject["performer"].Value<string>();
            if (jsonObject["title"] != null)
                Performer = jsonObject["title"].Value<string>();
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
        /// Duration of the audio in seconds as defined by sender
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Optional. Performer of the audio as defined by sender or by audio tags
        /// </summary>
        public string Performer { get; set; }
        /// <summary>
        /// Optional. Title of the audio as defined by sender or by audio tags
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; set; }
    }
}

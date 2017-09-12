using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a file ready to be downloaded. 
    /// The file can be downloaded via the link https://api.telegram.org/file/botToken/file_path. 
    /// It is guaranteed that the link will be valid for at least 1 hour. When the link expires, a new one can be requested by calling getFile.
    /// </summary>
    public class FileInfo
    {
        internal FileInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
            if (jsonObject["file_path"] != null)
                FilePath = jsonObject["file_path"].Value<string>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Optional. File size, if known
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// Optional. File path. Use https://api.telegram.org/file/botToken/file_path to get the file
        /// </summary>
        public string FilePath { get; set; }
    }
}

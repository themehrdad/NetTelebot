using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    /// <summary>
    /// This object represents a general file (as opposed to photos and audio files).
    /// </summary>
    public class DocumentInfo
    {
        internal DocumentInfo(string jsonText)
        {
            Parse(jsonText);
        }
        internal DocumentInfo(JObject jsonObject)
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
        public string FileId { get; set; }
        /// <summary>
        /// Document thumbnail as defined by sender
        /// </summary>
        public PhotoSizeInfo Thumb { get; set; }
        /// <summary>
        /// Optional. Original filename as defined by sender
        /// </summary>
        public string FileName { get; set; }
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

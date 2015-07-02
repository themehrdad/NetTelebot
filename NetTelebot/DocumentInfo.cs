using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class DocumentInfo
    {
        public DocumentInfo(string jsonText)
        {
            Parse(jsonText);
        }
        public DocumentInfo(JObject jsonObject)
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
            Thumb = new PhotoSizeInfo(jsonObject["thumb"].Value<JObject>());
            if (jsonObject["file_name"] != null)
                FileName = jsonObject["file_name"].Value<string>();
            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        public string FileId { get; set; }
        public PhotoSizeInfo Thumb { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int FileSize { get; set; }
    }
}

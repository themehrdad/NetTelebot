using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace NetTelebot
{
    public class AudioInfo
    {
        private JObject jObject;

        public AudioInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        public AudioInfo(string jsonText)
        {
            Parse(jsonText);
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Duration = jsonObject["duration"].Value<int>();
            if (jsonObject["mime_type"] != null)
                MimeType = jsonObject["mime_type"].Value<string>();
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        public string FileId { get; set; }
        public int Duration { get; set; }
        public string MimeType { get; set; }
        public int FileSize { get; set; }
    }
}

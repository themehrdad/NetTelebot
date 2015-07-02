using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class VideoInfo
    {
        public VideoInfo(string jsonText)
        {
            Parse(jsonText);
        }
        public VideoInfo(JObject jsonObject)
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
        public string FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Duration { get; set; }
        public PhotoSizeInfo Thumb { get; set; }
        public string MimeType { get; set; }
        public int FileSize { get; set; }
        public string Caption { get; set; }
    }
}

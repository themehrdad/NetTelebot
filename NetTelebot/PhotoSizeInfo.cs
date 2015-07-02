using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class PhotoSizeInfo
    {
        public PhotoSizeInfo(string jsonText)
        {
            Parse(jsonText);
        }

        public PhotoSizeInfo(JObject jsonObject)
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
            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }
        public string FileId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int FileSize { get; set; }

        public static PhotoSizeInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new PhotoSizeInfo(jobject)).ToArray();
        }
    }
}

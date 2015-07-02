using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class GroupChatInfo :IConversationSource
    {
        public GroupChatInfo(string jsonText)
        {
            Parse(jsonText);
        }

        public GroupChatInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<int>();
            Title = jsonObject["title"].Value<string>();
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}

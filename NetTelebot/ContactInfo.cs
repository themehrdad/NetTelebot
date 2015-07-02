using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class ContactInfo
    {
        public ContactInfo(string jsonText)
        {
            Parse(jsonText);
        }
        public ContactInfo(JObject jsonObject)
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
            PhoneNumber = jsonObject["phone_number"].Value<string>();
            FirstName = jsonObject["first_name"].Value<string>();
            if (jsonObject["last_name"] != null)
                LastName = jsonObject["last_name"].Value<string>();
            if (jsonObject["user_id"] != null)
                UserId = jsonObject["user_id"].Value<string>();
        }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
    }
}

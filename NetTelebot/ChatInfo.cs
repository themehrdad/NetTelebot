using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot 
{ 
    /// <summary>
    /// This object represents a chat. See <see href="https://core.telegram.org/bots/api#chat">API</see>
    /// </summary>
    public class ChatInfo : IConversationSource 
    {
        internal ChatInfo()
        {
        }

        internal ChatInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal ChatInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject) JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<int>();
            Type = jsonObject["type"].Value<ChatType>();

            if (jsonObject["title"] != null)
                Title = jsonObject["title"].Value<string>();
            if (jsonObject["username"] != null)
                Username = jsonObject["username"].Value<string>();
            if (jsonObject["first_name"] != null)
                FirstName = jsonObject["first_name"].Value<string>();
            if (jsonObject["last_name"] != null)
                LastName = jsonObject["last_name"].Value<string>();
            if (jsonObject["all_members_are_administrators"] != null)
                AllMembersAreAdministrators = jsonObject["all_members_are_administrators"].Value<bool>();
            if (jsonObject["photo"] != null)
                Photo = jsonObject["photo"].Value<ChatPhotoInfo>();
            if (jsonObject["description"] != null)
                Description = jsonObject["description"].Value<string>();
            if (jsonObject["invite_link"] != null)
                InviteLink = jsonObject["invite_link"].Value<string>();
        }

        /// <summary>
        /// Unique identifier for this chat. This number may be greater than 32 bits and some programming languages may have 
        /// difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of chat, can be either “private”, “group”, “supergroup” or “channel”
        /// </summary>
        public ChatType Type { get; private set; }

        /// <summary>
        /// Optional. Title, for supergroups, channels and group chats
        /// </summary>
        public string Title { get; private set;  }

        /// <summary>
        /// Optional. Username, for private chats, supergroups and channels if available
        /// </summary>
        public string Username { get; private set;  }

        /// <summary>
        /// Optional. First name of the other party in a private chat
        /// </summary>
        public string FirstName { get; private set;  }

        /// <summary>
        /// Optional. Last name of the other party in a private chat
        /// </summary>
        public string LastName { get; private set;  }

        /// <summary>
        /// Optional. True if a group has ‘All Members Are Admins’ enabled.
        /// </summary>
        public bool AllMembersAreAdministrators { get; private set; }

        /// <summary>
        /// Optional. Chat photo. Returned only in getChat.
        /// </summary>
        public ChatPhotoInfo Photo { get; private set; }

        /// <summary>
        /// Optional. Description, for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Optional. Chat invite link, for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string InviteLink { get; private set;  }
    }
}

using NetTelebot.BotEnum;
using NetTelebot.Extension;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type 
{ 
    /// <summary>
    /// This object represents a chat. 
    /// See <see href="https://core.telegram.org/bots/api#chat">API</see>
    /// </summary>
    public class ChatInfo
    {
        internal ChatInfo()
        {
        }

        internal ChatInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<long>();
            Type = jsonObject["type"].Value<string>().ToEnum<ChatType>();

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
                Photo = new ChatPhotoInfo(jsonObject["photo"].Value<JObject>());
            if (jsonObject["description"] != null)
                Description = jsonObject["description"].Value<string>();
            if (jsonObject["invite_link"] != null)
                InviteLink = jsonObject["invite_link"].Value<string>();
            if (jsonObject["is_forum"] != null)
                IsForum = jsonObject["is_forum"].Value<bool>();
            if (jsonObject["emoji_status_custom_emoji_id"] != null)
                EmojiStatusCustomEmojiId = jsonObject["emoji_status_custom_emoji_id"].Value<string>();
            if (jsonObject["has_private_forwards"] != null)
                HasPrivateForwards = jsonObject["has_private_forwards"].Value<bool>();
            if (jsonObject["has_restricted_voice_and_video_messages"] != null)
                HasRestrictedVoiceAndVideoMessages = jsonObject["has_restricted_voice_and_video_messages"].Value<bool>();
            if (jsonObject["join_to_send_messages"] != null)
                JoinToSendMessages = jsonObject["join_to_send_messages"].Value<bool>();
            if (jsonObject["join_by_request"] != null)
                JoinByRequest = jsonObject["join_by_request"].Value<bool>();
        }
        
        /// <summary>
        /// Unique identifier for this chat. This number may be greater than 32 bits and some programming languages may have 
        /// difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Type of chat, can be either “private”, “group”, “supergroup” or “channel”
        /// </summary>
        public ChatType? Type { get; private set; }

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
        public ChatPhotoInfo Photo { get; internal set; }

        /// <summary>
        /// Optional. Description, for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Optional. Chat invite link, for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        public string InviteLink { get; private set;  }

        /// <summary>
        /// Optional. True, if the supergroup chat is a forum (has topics enabled)
        /// </summary>
        public bool IsForum { get; private set; }

        /// <summary>
        /// Optional. Custom emoji identifier of emoji status of the other party in a private chat. Returned only in getChat.
        /// </summary>
        public string EmojiStatusCustomEmojiId { get; private set; }

        /// <summary>
        /// Optional. True, if privacy settings of the other party in the private chat allows to use tg://user?id=<user_id> links only in chats with the user. Returned only in getChat.
        /// </summary>
        public bool HasPrivateForwards { get; private set; }

        /// <summary>
        /// Optional. True, if the privacy settings of the other party restrict sending voice and video note messages in the private chat. Returned only in getChat.
        /// </summary>
        public bool HasRestrictedVoiceAndVideoMessages { get; private set; }

        /// <summary>
        /// Optional. True, if users need to join the supergroup before they can send messages. Returned only in getChat.
        /// </summary>
        public bool JoinToSendMessages { get; private set; }

        /// <summary>
        /// Optional. True, if all users directly joining the supergroup need to be approved by supergroup administrators. Returned only in getChat.
        /// </summary>
        public bool JoinByRequest { get; private set; }
    }
}

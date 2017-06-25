using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace NetTelebot
{
    /// <summary>
    /// This object represents a message. 
    /// API <link href="https://core.telegram.org/bots/api#message"></link>
    /// </summary>
    public class MessageInfo
    {
        internal MessageInfo()
        {
        }

        internal MessageInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal MessageInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        /// <summary>
        /// Parses the specified json object.
        /// </summary>
        /// <param name="jsonObject">The json object.</param>
        private void Parse(JObject jsonObject)
        {
            MessageId = jsonObject["message_id"].Value<int>();
            From = new UserInfo(jsonObject["from"].Value<JObject>());
            DateUnix = jsonObject["date"].Value<int>();
            Date = DateUnix.ToDateTime();
            Chat = ParseChat(jsonObject["chat"].Value<JObject>());
            if (jsonObject["forward_from"] != null)
                ForwardFrom = new UserInfo(jsonObject["forward_from"].Value<JObject>());
            if (jsonObject["forward_from_message_id"] != null)
                ForwardFromMessageId = jsonObject["forward_from_message_id"].Value<int>();
            if (jsonObject["forward_date"]!=null)
            {
                ForwardDateUnix = jsonObject["forward_date"].Value<int>();
                ForwardDate = ForwardDateUnix.ToDateTime();
            }
            if(jsonObject["reply_to_message"]!=null)
                ReplyToMessage = new MessageInfo(jsonObject["reply_to_message"].Value<JObject>());

            if (jsonObject["edit_date"] != null)
            {
                EditDateUnix = jsonObject["edit_date"].Value<int>();
                EditDate = EditDateUnix.ToDateTime();
            }
            if (jsonObject["text"] != null)
                Text = jsonObject["text"].Value<string>();

            Audio = jsonObject["audio"] != null 
                ? new AudioInfo(jsonObject["audio"].Value<JObject>()) 
                : new AudioInfo();

            Document = jsonObject["document"] != null
                ? new DocumentInfo(jsonObject["document"].Value<JObject>())
                : new DocumentInfo {Thumb = new PhotoSizeInfo()};

            Photo = jsonObject["photo"] != null
                ? PhotoSizeInfo.ParseArray(jsonObject["photo"].Value<JArray>())
                : new PhotoSizeInfo[0];

            Sticker = jsonObject["sticker"] != null
                ? new StickerInfo(jsonObject["sticker"].Value<JObject>())
                : new StickerInfo {Thumb = new PhotoSizeInfo()};

            Video = jsonObject["video"] != null
                ? new VideoInfo(jsonObject["video"].Value<JObject>())
                : new VideoInfo {Thumb = new PhotoSizeInfo()};

            Caption = jsonObject["caption"] != null 
                ? jsonObject["caption"].Value<string>() 
                : string.Empty;
            
            Contact = jsonObject["contact"] != null
                ? new ContactInfo(jsonObject["contact"].Value<JObject>())
                : new ContactInfo();

            Location = jsonObject["location"] != null
                ? new LocationInfo(jsonObject["location"].Value<JObject>())
                : new LocationInfo();

            NewChatMember = jsonObject["new_chat_member"] != null
                ? new UserInfo(jsonObject["new_chat_member"].Value<JObject>())
                : new UserInfo();

            LeftChatMember = jsonObject["left_chat_member"] != null
                ? new UserInfo(jsonObject["left_chat_member"].Value<JObject>())
                : new UserInfo();

            NewChatTitle = jsonObject["new_chat_title"] != null
                ? jsonObject["new_chat_title"].Value<string>()
                : string.Empty;
            
            NewChatPhoto = jsonObject["new_chat_photo"] != null
                ? PhotoSizeInfo.ParseArray(jsonObject["new_chat_photo"].Value<JArray>())
                : new PhotoSizeInfo[0];

            //todo For boolean value do this way
            //DeleteChatPhoto = jsonObject["delete_chat_photo"] != null
            //    ? DeleteChatPhoto = true
            //    : DeleteChatPhoto = false;

            if (jsonObject["delete_chat_photo"] != null)
                DeleteChatPhoto = true;

            if (jsonObject["group_chat_created"] != null)
                GroupChatCreated = true;

            if (jsonObject["supergroup_chat_created"] != null)
                SuperGroupChatCreated = true;

            if (jsonObject["channel_chat_created"] != null)
                ChannelChatCreated = true;

            if (jsonObject["migrate_to_chat_id"] != null)
                MigrateToChatId = jsonObject["migrate_to_chat_id"].Value<int>();

            if (jsonObject["migrate_from_chat_id"] != null)
                MigrateFromChatId = jsonObject["migrate_from_chat_id"].Value<int>();

            PinnedMessage = jsonObject["pinned_message"] != null
                ? new MessageInfo(jsonObject["pinned_message"].Value<JObject>())
                : new MessageInfo();

        }

        private static IConversationSource ParseChat(JObject jsonObject)
        {
            if (jsonObject["title"] != null)
                return new GroupChatInfo(jsonObject);

            return new UserInfo(jsonObject);
        }

        /// <summary>
        /// Unique message identifier
        /// </summary>
        public int MessageId { get; private set; }

        /// <summary>
        /// Sender
        /// </summary>
        public UserInfo From { get; private set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
        public int DateUnix { get; private set; }

        /// <summary>
        /// Date the message was sent
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Conversation the message belongs to — user in case of a private message, GroupChat in case of a group
        /// </summary>
        public IConversationSource Chat { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, sender of the original message
        /// </summary>
        public UserInfo ForwardFrom { get; private set; }

        //todo add (IConversationSource) ForwardFromChat

        /// <summary>
        /// Optional. For forwarded channel posts, identifier of the original message in the channel
        /// </summary>
        public int ForwardFromMessageId { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
        public int ForwardDateUnix { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
        public DateTime ForwardDate { get; private set; }

        /// <summary>
        /// Optional. For replies, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        public MessageInfo ReplyToMessage { get; private set; }

        /// <summary>
        /// Optional. Date the message was last edited in Unix time
        /// </summary>
        public int EditDateUnix { get; private set; }

        /// <summary>
        /// Optional. Date the message was last edited
        /// </summary>
        public DateTime EditDate { get; private set; }

        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message
        /// </summary>
        public string Text { get; private set; }

        //todo add (MessageEntity) Entities

        /// <summary>
        /// Optional. Message is an audio file, information about the file
        /// </summary>
        public AudioInfo Audio { get; private set; }

        /// <summary>
        /// Optional. Message is a general file, information about the file
        /// </summary>
        public DocumentInfo Document { get; private set; }

        //todo add (Game) Game

        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo
        /// </summary>
        public PhotoSizeInfo[] Photo { get; private set; }

        /// <summary>
        /// Optional. Message is a sticker, information about the sticker
        /// </summary>
        public StickerInfo Sticker { get; private set; }

        /// <summary>
        /// Optional. Message is a video, information about the video
        /// </summary>
        public VideoInfo Video { get; private set; }

        //todo add (Voice) Voice
        //todo add (VideoNote) VideoNote
        //todo add (Array of User) NewChatMembers


        /// <summary>
        /// Optional. Caption for the document, photo or video, 0-200 characters
        /// </summary>
        public string Caption { get; private set; }

        /// <summary>
        /// Optional. Message is a shared contact, information about the contact
        /// </summary>
        public ContactInfo Contact { get; private set; }

        /// <summary>
        /// Optional. Message is a shared location, information about the location
        /// </summary>
        public LocationInfo Location { get; private set; }

        //todo add (Venue) Venue

        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be bot itself)
        /// </summary>
        public UserInfo NewChatMember { get; private set; }

        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be bot itself)
        /// </summary>
        public UserInfo LeftChatMember { get; private set; }

        /// <summary>
        /// Optional. A group title was changed to this value
        /// </summary>
        public string NewChatTitle { get; private set; }

        /// <summary>
        /// Optional. A group photo was change to this value
        /// </summary>
        public PhotoSizeInfo[] NewChatPhoto { get; private set; }

        /// <summary>
        /// Optional. Informs that the group photo was deleted
        /// </summary>
        public bool DeleteChatPhoto { get; private set; }

        /// <summary>
        /// Optional. Informs that the group has been created
        /// </summary>
        public bool GroupChatCreated { get; private set; }

        /// <summary>
        /// Optional. Service message: the supergroup has been created. This field can‘t be received in a message coming through updates,
        /// because bot can’t be a member of a supergroup when it is created. It can only be found in reply_to_message if someone replies to a very
        /// first message in a directly created supergroup.
        /// </summary>
        public bool SuperGroupChatCreated { get; private set;  }

        /// <summary>
        /// Optional. Service message: the channel has been created. This field can‘t be received in a message coming through updates, 
        /// because bot can’t be a member of a channel when it is created. It can only be found in reply_to_message if someone replies to a very
        /// first message in a channel.
        /// </summary>
        public bool ChannelChatCreated { get; private set; }

        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier. This number may be greater than 32 bits and some
        /// programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier.
        /// </summary>
        public int MigrateToChatId { get; private set;  }

        /// <summary>
        /// Optional. The supergroup has been migrated from a group with the specified identifier. This number may be greater than 32 bits and some
        /// programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier.
        /// </summary>
        public int MigrateFromChatId { get; private set;  }

        /// <summary>
        /// Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
        /// </summary>
        public MessageInfo PinnedMessage { get; private set; }

        //todo (Invoice) Invoice
        //todo (SuccessfulPayment) SuccessfulPayment
    }
}

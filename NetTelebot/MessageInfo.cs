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
    /// This object represents a message.
    /// </summary>
    public class MessageInfo
    {
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

        private void Parse(JObject jsonObject)
        {
            MessageId = jsonObject["message_id"].Value<int>();
            From = new UserInfo(jsonObject["from"].Value<JObject>());
            DateUnix = jsonObject["date"].Value<int>();
            Date = DateUnix.ToDateTime();
            Chat = ParseChat(jsonObject["chat"].Value<JObject>());
            if (jsonObject["forward_from"] != null)
                ForwardFrom = new UserInfo(jsonObject["forward_from"].Value<JObject>());
            if(jsonObject["forward_date"]!=null)
            {
                ForwardDateUnix = jsonObject["forward_date"].Value<int>();
                ForwardDate = ForwardDateUnix.ToDateTime();
            }
            if(jsonObject["reply_to_message"]!=null)
            {
                ReplyToMessage = new MessageInfo(jsonObject["reply_to_message"].Value<JObject>());
            }
            if (jsonObject["text"] != null)
                Text = jsonObject["text"].Value<string>();
            if (jsonObject["audio"] != null)
                Audio = new AudioInfo(jsonObject["audio"].Value<JObject>());
            if (jsonObject["document"] != null)
                Document = new DocumentInfo(jsonObject["document"].Value<JObject>());
            if (jsonObject["photo"] != null)
                Photo = PhotoSizeInfo.ParseArray(jsonObject["photo"].Value<JArray>());
            if (jsonObject["sticker"] != null)
                Sticker = new StickerInfo(jsonObject["sticker"].Value<JObject>());
            if (jsonObject["video"] != null)
                Video = new VideoInfo(jsonObject["video"].Value<JObject>());
            if (jsonObject["contact"] != null)
                Contact = new ContactInfo(jsonObject["contact"].Value<JObject>());
            if (jsonObject["location"] != null)
                Location = new LocationInfo(jsonObject["location"].Value<JObject>());
            if (jsonObject["new_chat_participant"] != null)
                NewChatParticipant = new UserInfo(jsonObject["new_chat_participant"].Value<JObject>());
            if (jsonObject["left_chat_participant"] != null)
                LeftChatParticipant = new UserInfo(jsonObject["left_chat_participant"].Value<JObject>());
            if (jsonObject["new_chat_title"] != null)
                NewChatTitle = jsonObject["new_chat_title"].Value<string>();
            if (jsonObject["new_chat_photo"] != null)
                NewChatPhoto = PhotoSizeInfo.ParseArray(jsonObject["new_chat_photo"].Value<JArray>());
            if (jsonObject["delete_chat_photo"] != null)
                DeleteChatPhoto = true;
            if (jsonObject["group_chat_created"] != null)
                GroupChatCreated = true;
        }

        private IConversationSource ParseChat(JObject jsonObject)
        {
            if (jsonObject["title"] != null)
                return new GroupChatInfo(jsonObject);
            else
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
        /// Optional. For text messages, the actual UTF-8 text of the message
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// Optional. Message is an audio file, information about the file
        /// </summary>
        public AudioInfo Audio { get; private set; }
        /// <summary>
        /// Optional. Message is a general file, information about the file
        /// </summary>
        public DocumentInfo Document { get; private set; }
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
        /// <summary>
        /// Optional. Message is a shared contact, information about the contact
        /// </summary>
        public ContactInfo Contact { get; private set; }
        /// <summary>
        /// Optional. Message is a shared location, information about the location
        /// </summary>
        public LocationInfo Location { get; private set; }
        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be bot itself)
        /// </summary>
        public UserInfo NewChatParticipant { get; private set; }
        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be bot itself)
        /// </summary>
        public UserInfo LeftChatParticipant { get; private set; }
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
    }
}

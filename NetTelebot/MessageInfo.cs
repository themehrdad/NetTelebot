using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class MessageInfo
    {
        public MessageInfo(string jsonText)
        {
            Parse(jsonText);
        }

        public MessageInfo(JObject jsonObject)
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

        public int MessageId { get; private set; }
        public UserInfo From { get; private set; }
        public int DateUnix { get; private set; }
        public DateTime Date { get; private set; }
        public IConversationSource Chat { get; private set; }
        public UserInfo ForwardFrom { get; private set; }
        public int ForwardDateUnix { get; private set; }
        public DateTime ForwardDate { get; private set; }
        public MessageInfo ReplyToMessage { get; private set; }
        public string Text { get; private set; }
        public AudioInfo Audio { get; private set; }
        public DocumentInfo Document { get; private set; }
        public PhotoSizeInfo[] Photo { get; private set; }
        public StickerInfo Sticker { get; private set; }
        public VideoInfo Video { get; private set; }
        public ContactInfo Contact { get; private set; }
        public LocationInfo Location { get; private set; }
        public UserInfo NewChatParticipant { get; private set; }
        public UserInfo LeftChatParticipant { get; private set; }
        public string NewChatTitle { get; private set; }
        public PhotoSizeInfo[] NewChatPhoto { get; private set; }
        public bool DeleteChatPhoto { get; private set; }
        public bool GroupChatCreated { get; private set; }
    }
}

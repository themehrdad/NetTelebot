using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

#if DEBUG
[assembly: InternalsVisibleTo("NetTelebot.Tests")]
#endif

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

            // Test NetTelebot.Tests.MessageInfoParserTest.MessageInfoFromTest()
            From = jsonObject["from"] != null
                ? new UserInfo(jsonObject["from"].Value<JObject>())
                : new UserInfo();

            DateUnix = jsonObject["date"].Value<int>();
            Date = DateUnix.ToDateTime();

            Chat = ParseChat(jsonObject["chat"].Value<JObject>());

            // Test NetTelebot.Tests.MessageInfoParserTest.MessageInfoForwardFromTest()
            ForwardFrom = jsonObject["forward_from"] != null
                ? new UserInfo(jsonObject["forward_from"].Value<JObject>())
                : new UserInfo();

            if (jsonObject["forward_from_message_id"] != null)
                ForwardFromMessageId = jsonObject["forward_from_message_id"].Value<int>();

            if (jsonObject["forward_date"]!=null)
            {
                ForwardDateUnix = jsonObject["forward_date"].Value<int>();
                ForwardDate = ForwardDateUnix.ToDateTime();
            }
            
            ReplyToMessage = jsonObject["reply_to_message"] != null
                ? new MessageInfo(jsonObject["reply_to_message"].Value<JObject>())
                : new MessageInfo();

            if (jsonObject["edit_date"] != null)
            {
                EditDateUnix = jsonObject["edit_date"].Value<int>();
                EditDate = EditDateUnix.ToDateTime();
            }

            Text = jsonObject["text"] != null 
                ? jsonObject["text"].Value<string>() 
                : string.Empty;

            // Test NetTelebot.Tests.MessageInfoParserTest.MessageInfoAudioTest()
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
        /// Unique message identifier inside this chat
        /// </summary>
        public int MessageId { get; private set; }

        //todo need test with sent to @channels
        /// <summary>
        /// Optional. Sender, can be empty for messages sent to channel
        /// </summary>
        public UserInfo From { get; private set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
        public int DateUnix { get; private set; }

        /// <summary>
        /// Date the message was sent in <see cref="DateTime"/>
        /// </summary>
        /// <remarks>This extension, not the available API type <seealso cref="UtilityExtensions.ToDateTime"/> </remarks>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Conversation the message belongs to — user in case of a private message, GroupChat in case of a group
        /// </summary>
        public IConversationSource Chat { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, sender of the original message.
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyForwardFrom() </remarks>
        public UserInfo ForwardFrom { get; private set; }

        //todo add (IConversationSource) ForwardFromChat

        /// <summary>
        /// Optional. For forwarded channel posts, identifier of the original message in the channel 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyForwardFromMessageId() </remarks>
        public int ForwardFromMessageId { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToMigrateFromForwardDateUnix() </remarks>
        public int ForwardDateUnix { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in <see cref="DateTime"/>
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToMigrateFromForwardDate() </remarks>
        /// <remarks> This extension, not the available API type <seealso cref="UtilityExtensions.ToDateTime"/> </remarks>
        public DateTime ForwardDate { get; private set; }

        /// <summary>
        /// Optional. For replies, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToMigrateFromReplyToMessage() </remarks>
        public MessageInfo ReplyToMessage { get; private set; }

        /// <summary>
        /// Optional. Date the message was last edited in Unix time
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToMigrateFromEditDateUnix() </remarks>
        public int EditDateUnix { get; private set; }

        /// <summary>
        /// Optional. Date the message was last edited 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToMigrateFromEditDate() </remarks>
        /// <remarks> This extension, not the available API type <seealso cref="UtilityExtensions.ToDateTime"/> </remarks>
        public DateTime EditDate { get; private set; }

        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyText() </remarks>
        public string Text { get; private set; }

        //todo add (MessageEntity) Entities

        /// <summary>
        /// Optional. Message is an audio file, information about the file TestAppealToTheEmptyAudio()
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyAudio() </remarks>
        public AudioInfo Audio { get; private set; }

        /// <summary>
        /// Optional. Message is a general file, information about the file TestAppealToTheEmptyDocument()
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyDocument() </remarks>
        public DocumentInfo Document { get; private set; }

        //todo add (Game) Game

        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyPhoto() </remarks>
        public PhotoSizeInfo[] Photo { get; private set; }

        /// <summary>
        /// Optional. Message is a sticker, information about the sticker 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptySticker() </remarks>
        /// <remarks> Parser test: NetTelebot.Tests.MessageInfoParserTest.MessageInfoStickerTest() </remarks>
        public StickerInfo Sticker { get; private set; }

        /// <summary>
        /// Optional. Message is a video, information about the video 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyVideo() </remarks>
        public VideoInfo Video { get; private set; }

        //todo add (Voice) Voice
        //todo add (VideoNote) VideoNote
        //todo add (Array of User) NewChatMembers

        /// <summary>
        /// Optional. Caption for the document, photo or video, 0-200 characters 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyCaption() </remarks>
        public string Caption { get; private set; }

        /// <summary>
        /// Optional. Message is a shared contact, information about the contact TestAppealToTheEmptyContact()
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyContact() </remarks>
        public ContactInfo Contact { get; private set; }

        /// <summary>
        /// Optional. Message is a shared location, information about the location 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyLocation() </remarks>
        public LocationInfo Location { get; private set; }

        //todo add (Venue) Venue

        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be bot itself)  
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyNewChatMember() </remarks>
        public UserInfo NewChatMember { get; private set; }

        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be bot itself) 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyLeftChatMember() </remarks>
        public UserInfo LeftChatMember { get; private set; }

        /// <summary>
        /// Optional. A group title was changed to this value 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyNewChatTitle() </remarks>
        public string NewChatTitle { get; private set; }

        /// <summary>
        /// Optional. A group photo was change to this value TestAppealToTheEmptyNewChatPhoto()
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyNewChatPhoto() </remarks>
        public PhotoSizeInfo[] NewChatPhoto { get; private set; }

        /// <summary>
        /// Optional. Informs that the group photo was deleted TestAppealToTheEmptyDeleteChatPhoto()
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheEmptyDeleteChatPhoto() </remarks>
        public bool DeleteChatPhoto { get; private set; }

        /// <summary>
        /// Optional. Informs that the group has been created TestAppealToTheGroupChatCreated()
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToTheGroupChatCreated() </remarks>
        public bool GroupChatCreated { get; private set; }

        /// <summary>
        /// Optional. Service message: the supergroup has been created. This field can‘t be received in a message coming through updates,
        /// because bot can’t be a member of a supergroup when it is created. It can only be found in reply_to_message if someone replies to a very
        /// first message in a directly created supergroup. 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToSuperGroupChatCreated() </remarks>
        public bool SuperGroupChatCreated { get; private set;  }

        /// <summary>
        /// Optional. Service message: the channel has been created. This field can‘t be received in a message coming through updates, 
        /// because bot can’t be a member of a channel when it is created. It can only be found in reply_to_message if someone replies to a very
        /// first message in a channel. TestAppealToChannelChatCreated()
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToChannelChatCreated() </remarks>
        public bool ChannelChatCreated { get; private set; }

        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier. This number may be greater than 32 bits and some
        /// programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier. 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToMigrateToChatId() </remarks>
        public int MigrateToChatId { get; private set; }

        /// <summary>
        /// Optional. The supergroup has been migrated from a group with the specified identifier. This number may be greater than 32 bits and some
        /// programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier. 
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.TestAppealToMigrateFromChatId() </remarks>
        public int MigrateFromChatId { get; private set; }

        /// <summary>
        /// Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
        /// </summary>
        /// <remarks> Test NullReferenceException: NetTelebot.Tests.estAppealToMigrateFromPinnedMessage() </remarks>
        public MessageInfo PinnedMessage { get; private set; }

        //todo (Invoice) Invoice
        //todo (SuccessfulPayment) SuccessfulPayment
    }
}

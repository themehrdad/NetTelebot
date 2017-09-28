using System;
using NetTelebot.Extension;
using NetTelebot.Type.Games;
using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /* About tests
     * After adding the class field, you need to add the following tests:
     *  
     * 1) NetTelebot.Tests.ResponseTest.MessageInfoParserTest - this is a test for the correspondence of the received json object to the fields of the class
     * 2) NetTelebot.Tests.NullReferenceExceptionTest.[ClassName] - depending on the type of object added.
     */

    /// <summary>
    /// This object represents a message. 
    /// API <link href="https://core.telegram.org/bots/api#message"></link>
    /// </summary>
    public class MessageInfo
    {

        internal MessageInfo()
        {
        }
        
        /// <summary>
        /// Parses the specified json object.
        /// </summary>
        /// <param name="jsonObject">The json object.</param>
        internal MessageInfo(JObject jsonObject)
        {
            MessageId = jsonObject["message_id"].Value<int>();

            From = jsonObject["from"] != null
                ? new UserInfo(jsonObject["from"].Value<JObject>())
                : new UserInfo();

            DateUnix = jsonObject["date"].Value<long>();
            Date = DateUnix.ToDateTime();
            Chat = new ChatInfo(jsonObject["chat"].Value<JObject>());

            ForwardFrom = jsonObject["forward_from"] != null
                ? new UserInfo(jsonObject["forward_from"].Value<JObject>())
                : new UserInfo();

            ForwardFromChat = jsonObject["forward_from_chat"] != null
                ? new ChatInfo(jsonObject["forward_from_chat"].Value<JObject>())
                : new ChatInfo {Photo = new ChatPhotoInfo()};

            if (jsonObject["forward_from_message_id"] != null)
                ForwardFromMessageId = jsonObject["forward_from_message_id"].Value<int>();

            if (jsonObject["forward_date"]!=null)
            {
                ForwardDateUnix = jsonObject["forward_date"].Value<long>();
                ForwardDate = ForwardDateUnix.ToDateTime();
            }

            ReplyToMessage = jsonObject["reply_to_message"] != null
                ? new MessageInfo(jsonObject["reply_to_message"].Value<JObject>())
                : GetNewMessageInfo(GetNewMessageInfo(), GetNewMessageInfo());

            if (jsonObject["edit_date"] != null)
            {
                EditDateUnix = jsonObject["edit_date"].Value<long>();
                EditDate = EditDateUnix.ToDateTime();
            }

            Text = jsonObject["text"] != null 
                ? jsonObject["text"].Value<string>() 
                : string.Empty;

            Entities = jsonObject["entities"] != null
                ? MessageEntityInfo.ParseArray(jsonObject["entities"].Value<JArray>())
                : new MessageEntityInfo[0];

            Audio = jsonObject["audio"] != null 
                ? new AudioInfo(jsonObject["audio"].Value<JObject>()) 
                : new AudioInfo();

            Document = jsonObject["document"] != null
                ? new DocumentInfo(jsonObject["document"].Value<JObject>())
                : new DocumentInfo {Thumb = new PhotoSizeInfo()};

            Game = jsonObject["game"] != null
                ? new GameInfo(jsonObject["game"].Value<JObject>())
                : new GameInfo {Photo = new PhotoSizeInfo[0], Entities = new MessageEntityInfo[0],
                    Animation = new AnimationInfo {Thumb = new PhotoSizeInfo()} };

            Photo = jsonObject["photo"] != null
                ? PhotoSizeInfo.ParseArray(jsonObject["photo"].Value<JArray>())
                : new PhotoSizeInfo[0];

            Sticker = jsonObject["sticker"] != null
                ? new StickerInfo(jsonObject["sticker"].Value<JObject>())
                : new StickerInfo {Thumb = new PhotoSizeInfo()};

            Video = jsonObject["video"] != null
                ? new VideoInfo(jsonObject["video"].Value<JObject>())
                : new VideoInfo {Thumb = new PhotoSizeInfo()};

            Voice = jsonObject["voice"] != null
                ? new VoiceInfo(jsonObject["voice"].Value<JObject>())
                : new VoiceInfo();

            VideoNote = jsonObject["video_note"] != null
                ? new VideoNoteInfo(jsonObject["video_note"].Value<JObject>())
                : new VideoNoteInfo {Thumb = new PhotoSizeInfo()};

            NewChatMembers = jsonObject["new_chat_members"] != null
                ? UserInfo.ParseArray(jsonObject["new_chat_members"].Value<JArray>())
                : new UserInfo[0];

            Caption = jsonObject["caption"] != null 
                ? jsonObject["caption"].Value<string>() 
                : string.Empty;

            Contact = jsonObject["contact"] != null
                ? new ContactInfo(jsonObject["contact"].Value<JObject>())
                : new ContactInfo();

            Location = jsonObject["location"] != null
                ? new LocationInfo(jsonObject["location"].Value<JObject>())
                : new LocationInfo();

            Venue = jsonObject["venue"] != null
                ? new VenueInfo(jsonObject["venue"].Value<JObject>())
                : new VenueInfo {Location = new LocationInfo()};

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
                : GetNewMessageInfo(GetNewMessageInfo(), GetNewMessageInfo());

            Invoice = jsonObject["invoice"] != null
                ? new InvoceInfo(jsonObject["invoice"].Value<JObject>())
                : new InvoceInfo();

            SuccessfulPayment = jsonObject["successful_payment"] != null
                ? new SuccessfulPaymentInfo(jsonObject["successful_payment"].Value<JObject>())
                : new SuccessfulPaymentInfo {OrderInfo = new OrderInfo {ShippingAddress = new ShippingAddressInfo()} };
        }

        internal static MessageInfo GetNewMessageInfo(MessageInfo pinned = null, MessageInfo reply = null)
        {
            return new MessageInfo
            {
                From = new UserInfo(),
                Chat = new ChatInfo(),
                ForwardFrom = new UserInfo(),
                ForwardFromChat = new ChatInfo{Photo = new ChatPhotoInfo()},
                ReplyToMessage = reply,
                Entities = new MessageEntityInfo[0],
                Audio = new AudioInfo(),
                Document = new DocumentInfo {Thumb = new PhotoSizeInfo()},
                Game  = new GameInfo
                {
                    Photo = new PhotoSizeInfo[0],
                    Entities = new MessageEntityInfo[0],
                    Animation = new AnimationInfo
                    {
                        Thumb = new PhotoSizeInfo()
                    }
                },
                Photo = new PhotoSizeInfo[0],
                Sticker = new StickerInfo {Thumb = new PhotoSizeInfo()},
                Video = new VideoInfo {Thumb = new PhotoSizeInfo()},
                Voice = new VoiceInfo(),
                VideoNote = new VideoNoteInfo {Thumb = new PhotoSizeInfo()},
                NewChatMembers = new UserInfo[0],
                Contact = new ContactInfo(),
                Location = new LocationInfo(),
                Venue = new VenueInfo {Location = new LocationInfo()},
                NewChatMember = new UserInfo(),
                LeftChatMember = new UserInfo(),
                NewChatPhoto = new PhotoSizeInfo[0],
                PinnedMessage = pinned,
                Invoice = new InvoceInfo(),
                SuccessfulPayment = new SuccessfulPaymentInfo
                {
                    OrderInfo = new OrderInfo
                    {
                        ShippingAddress = new ShippingAddressInfo()
                    }
                }
               
            };
        }

        /// <summary>
        /// Unique message identifier inside this chat
        /// </summary>
        public int MessageId { get; private set; }

        /// <summary>
        /// Optional. Sender, can be empty for messages sent to channel
        /// </summary>
        public UserInfo From { get; private set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
        public long DateUnix { get; private set; }

        /// <summary>
        /// Date the message was sent in <see cref="DateTime"/>
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Conversation the message belongs to
        /// </summary>
        public ChatInfo Chat { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, sender of the original message.
        /// </summary>
        public UserInfo ForwardFrom { get; private set; }

        /// <summary>
        /// Optional. For messages forwarded from a channel, information about the original channel
        /// </summary>
        public ChatInfo ForwardFromChat { get; private set; }

        /// <summary>
        /// Optional. For forwarded channel posts, identifier of the original message in the channel 
        /// </summary>
        public int ForwardFromMessageId { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
        public long ForwardDateUnix { get; private set; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in <see cref="DateTime"/>
        /// </summary>
        /// <remarks> This extension, not the available API type <seealso cref="UtilityExtensions.ToDateTime"/> </remarks>
        public DateTime ForwardDate { get; private set; }

        /// <summary>
        /// Optional. For replies, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        public MessageInfo ReplyToMessage { get; private set; }

        /// <summary>
        /// Optional. Date the message was last edited in Unix time
        /// </summary>
        public long EditDateUnix { get; private set; }

        /// <summary>
        /// Optional. Date the message was last edited 
        /// </summary>
        /// <remarks> This extension, not the available API type <seealso cref="UtilityExtensions.ToDateTime"/> </remarks>
        public DateTime EditDate { get; private set; }

        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message 
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
        /// </summary>
        public MessageEntityInfo[] Entities { get; private set; }

        /// <summary>
        /// Optional. Message is an audio file, information about the file TestAppealToTheEmptyAudio()
        /// </summary>
        public AudioInfo Audio { get; private set; }

        /// <summary>
        /// Optional. Message is a general file, information about the file TestAppealToTheEmptyDocument()
        /// </summary>
        public DocumentInfo Document { get; private set; }

        /// <summary>
        /// This object represents a game. Use BotFather to create and edit games, their short names will act as unique identifiers.
        /// </summary>
        public GameInfo Game { get; private set;  }

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
        /// This object represents a voice note.
        /// </summary>
        public VoiceInfo Voice { get; private set;  }

        /// <summary>
        /// This object represents a video message (available in Telegram apps as of v.4.0).
        /// </summary>
        public VideoNoteInfo VideoNote { get; private set; }

        /// <summary>
        /// Optional. New members that were added to the group or supergroup and information about them (the bot itself may be one of these members)
        /// </summary>
        public UserInfo[] NewChatMembers { get; private set; }

        /// <summary>
        /// Optional. Caption for the document, photo or video, 0-200 characters 
        /// </summary>
        public string Caption { get; private set; }

        /// <summary>
        /// Optional. Message is a shared contact, information about the contact TestAppealToTheEmptyContact()
        /// </summary>
        public ContactInfo Contact { get; private set; }

        /// <summary>
        /// Optional. Message is a shared location, information about the location 
        /// </summary>
        public LocationInfo Location { get; private set; }

        /// <summary>
        /// Optional. This object represents a venue.
        /// </summary>
        public VenueInfo Venue { get; private set; }

        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be bot itself)  
        /// </summary>
        [Obsolete("See Introducing Bot API 3.0: " +
                  "Replaced the field new_chat_member in Message with new_chat_members " +
                  "(the old field will still be available for a while for compatibility purposes).")]
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
        /// Optional. A group photo was change to this value TestAppealToTheEmptyNewChatPhoto()
        /// </summary>
        public PhotoSizeInfo[] NewChatPhoto { get; private set; }

        /// <summary>
        /// Optional. Informs that the group photo was deleted TestAppealToTheEmptyDeleteChatPhoto()
        /// </summary>
        public bool DeleteChatPhoto { get; private set; }

        /// <summary>
        /// Optional. Informs that the group has been created TestAppealToTheGroupChatCreated()
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
        /// first message in a channel. TestAppealToChannelChatCreated()
        /// </summary>
        public bool ChannelChatCreated { get; private set; }

        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier. This number may be greater than 32 bits and some
        /// programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier. 
        /// </summary>
        public int MigrateToChatId { get; private set; }

        /// <summary>
        /// Optional. The supergroup has been migrated from a group with the specified identifier. This number may be greater than 32 bits and some
        /// programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision
        /// float type are safe for storing this identifier. 
        /// </summary>
        public int MigrateFromChatId { get; private set; }

        /// <summary>
        /// Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
        /// </summary>
        public MessageInfo PinnedMessage { get; private set; }

        /// <summary>
        /// Optional. Message is an <see href="https://core.telegram.org/bots/api#payments">invoice </see> for a payment, information about the invoice. 
        /// </summary>
        public InvoceInfo Invoice { get; private set; }

        /// <summary>
        /// Optional. Message is a service message about a successful payment, information about the payment.
        /// </summary>
        public SuccessfulPaymentInfo SuccessfulPayment { get; private set; }
    }
}

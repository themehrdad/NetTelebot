using System;
using NetTelebot.BotEnum;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    //todo refact

    [TestFixture]
    internal static class MessageInfoParserTest
    {
        private static readonly JObject mMandatoryFieldsMessageInfo =
            MessageInfoObject.GetMandatoryFieldsMessageInfo(-1147483648, 0,
                1049413668, ChatType.@group);

        /// <summary>
        /// Test for <see cref="MessageInfo.From"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoFromTest()
        {
            const int id = 1000;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.from = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.AreEqual(messageInfo.From.Id, id);
            Assert.AreEqual(messageInfo.From.FirstName, firstName);
            Assert.AreEqual(messageInfo.From.LastName, lastName);
            Assert.AreEqual(messageInfo.From.UserName, username);
            Assert.AreEqual(messageInfo.From.LanguageCode, languageCode);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFrom"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromTest()
        {
            const int id = 1000;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.forward_from = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.AreEqual(messageInfo.ForwardFrom.Id, id);
            Assert.AreEqual(messageInfo.ForwardFrom.FirstName, firstName);
            Assert.AreEqual(messageInfo.ForwardFrom.LastName, lastName);
            Assert.AreEqual(messageInfo.ForwardFrom.UserName, username);
            Assert.AreEqual(messageInfo.ForwardFrom.LanguageCode, languageCode);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFromChat"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromChatTest()
        {
            const int id = 1049413668;
            const string type = "channel";
            const string title = "TestTitle";
            const string username = "TestUsername";
            const string firstName = "TestFirstName";
            const string lastName = "TestLastName";
            const bool allMembersAreAdministrators = false;
            JObject photo = ChatPhotoInfoObject.GetObject("123456", "654321");
            const string description = "TestDescription";
            const string inviteLink = "TestLink";

            dynamic mandatoryMessageInfoFields = new JObject();

            mandatoryMessageInfoFields.message_id = -1147483648;
            mandatoryMessageInfoFields.date = 0;

            mandatoryMessageInfoFields.chat = ChatInfoObject.GetMinimalMandatoryObject(id, ChatType.channel);

            mandatoryMessageInfoFields.forward_from_chat = ChatInfoObject.GetObject(id, type,
                title, username, firstName, lastName, allMembersAreAdministrators,
                photo, description, inviteLink);

            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.ForwardFromChat.Id, id);
            Assert.AreEqual(messageInfo.ForwardFromChat.Type, ChatType.channel);
            Assert.AreEqual(messageInfo.ForwardFromChat.Title, title);
            Assert.AreEqual(messageInfo.ForwardFromChat.Username, username);
            Assert.AreEqual(messageInfo.ForwardFromChat.FirstName, firstName);
            Assert.AreEqual(messageInfo.ForwardFromChat.LastName, lastName);
            Assert.AreEqual(messageInfo.ForwardFromChat.AllMembersAreAdministrators, allMembersAreAdministrators);
            Assert.AreEqual(messageInfo.ForwardFromChat.Photo.SmallFileId, "123456");
            Assert.AreEqual(messageInfo.ForwardFromChat.Photo.BigFileId, "654321");
            Assert.AreEqual(messageInfo.ForwardFromChat.Description, description);
            Assert.AreEqual(messageInfo.ForwardFromChat.InviteLink, inviteLink);

            Console.WriteLine(mandatoryMessageInfoFields);

        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFromMessageId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromMessageIdTest()
        {
            //check MessageInfo witout field [forward_from_message_id]
            dynamic messageInfoForwardFromMessageId = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoForwardFromMessageId);
            Assert.AreEqual(messageInfo.ForwardFromMessageId, 0);

            //check MessageInfo with field [forward_from_message_id: 14881488] 
            messageInfoForwardFromMessageId.forward_from_message_id = 14881488;
            messageInfo = new MessageInfo(messageInfoForwardFromMessageId);
            Assert.AreEqual(messageInfo.ForwardFromMessageId, 14881488);

            Console.WriteLine(messageInfoForwardFromMessageId);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardDateUnix"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardDateUnixTest()
        {
            //check MessageInfo without field [forward_date]
            dynamic messageInfoForwardDateUnix = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoForwardDateUnix);
            Assert.AreEqual(messageInfo.ForwardDateUnix, 0);
            Assert.AreEqual(messageInfo.ForwardDate, DateTime.MinValue);

            //check MessageInfo with field [forward_date: 0] 
            messageInfoForwardDateUnix.forward_date = 0;
            Assert.AreEqual(messageInfo.DateUnix, 0);
            Assert.AreEqual(messageInfo.Date, new DateTime(1970, 1, 1).ToLocalTime());

            Console.WriteLine(messageInfoForwardDateUnix);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Chat"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoChatTest()
        {
            const int id = 1049413668;
            const string type = "channel";
            const string title = "TestTitle";
            const string username = "TestUsername";
            const string firstName = "TestFirstName";
            const string lastName = "TestLastName";
            const bool allMembersAreAdministrators = false;
            JObject photo = ChatPhotoInfoObject.GetObject("123456", "654321");
            const string description = "TestDescription";
            const string inviteLink = "TestLink";

            dynamic mandatoryMessageInfoFields = new JObject();

            mandatoryMessageInfoFields.message_id = -1147483648;
            mandatoryMessageInfoFields.date = 0;

            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, type,
                title, username, firstName, lastName, allMembersAreAdministrators, 
                photo, description, inviteLink);

            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.IsInstanceOf<long>(messageInfo.Chat.Id);

            Assert.AreEqual(messageInfo.Chat.Type, ChatType.channel);
            Assert.AreEqual(messageInfo.Chat.Title, title);
            Assert.AreEqual(messageInfo.Chat.Username, username);
            Assert.AreEqual(messageInfo.Chat.FirstName, firstName);
            Assert.AreEqual(messageInfo.Chat.LastName, lastName);
            Assert.AreEqual(messageInfo.Chat.AllMembersAreAdministrators, allMembersAreAdministrators);
            Assert.AreEqual(messageInfo.Chat.Photo.SmallFileId, "123456");
            Assert.AreEqual(messageInfo.Chat.Photo.BigFileId, "654321");
            Assert.AreEqual(messageInfo.Chat.Description, description);
            Assert.AreEqual(messageInfo.Chat.InviteLink, inviteLink);

            Console.WriteLine(mandatoryMessageInfoFields);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Chat"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoParseChatIdTest()
        {
            const int idIntMin = int.MinValue;
            const int idIntMax = int.MaxValue;

            const long idLongMin = long.MinValue;
            const long idLongMax = long.MaxValue;

            const string type = "channel";
            
            dynamic mandatoryMessageInfoFields = new JObject();

            mandatoryMessageInfoFields.message_id = -1147483648;
            mandatoryMessageInfoFields.date = 0;

            //min_int
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(idIntMin, type);
            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);
            Assert.IsInstanceOf<long>(messageInfo.Chat.Id);

            //max_int
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(idIntMax, type);
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);
            Assert.IsInstanceOf<long>(messageInfo.Chat.Id);

            //min_long
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(idLongMin, type);
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);
            Assert.IsInstanceOf<long>(messageInfo.Chat.Id);

            //max_long
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(idLongMax, type);
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);
            Assert.IsInstanceOf<long>(messageInfo.Chat.Id);
        }

        /// <summary>
        /// Test for parse <see cref="ChatType"/> in <see cref="MessageInfo.Chat"/> 
        /// </summary>
        [Test]
        public static void MessageInfoChatsTypeParserTest()
        {
            const int id = 1049413668;
            dynamic mandatoryMessageInfoFields = new JObject();

            mandatoryMessageInfoFields.message_id = -1147483648;
            mandatoryMessageInfoFields.date = 0;

            //private
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "private");
            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.AreEqual(messageInfo.Chat.Type, ChatType.@private);

            //channel
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "channel");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.AreEqual(messageInfo.Chat.Type, ChatType.channel);

            //group
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "group");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.AreEqual(messageInfo.Chat.Type, ChatType.@group);

            //supergroup
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "supergroup");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.AreEqual(messageInfo.Chat.Type, ChatType.supergroup);

            //null
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "grou");
            MessageInfo messageInfo2 = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo2.Chat.Id, id);
            Assert.AreEqual(messageInfo2.Chat.Type, null);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ReplyToMessage"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoReplyToMessageTest()
        {
            const int messageId = 1000;
            const int date = 0;
            const int chatId = 125421;

            dynamic messageInfoReplyToMessage = mMandatoryFieldsMessageInfo;

            messageInfoReplyToMessage.reply_to_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, ChatType.channel);

            MessageInfo messageInfo = new MessageInfo(messageInfoReplyToMessage);

            Assert.AreEqual(messageInfo.ReplyToMessage.MessageId, messageId);
            Assert.AreEqual(messageInfo.ReplyToMessage.DateUnix, date);
            Assert.AreEqual(messageInfo.ReplyToMessage.Chat.Id, chatId);

            Console.WriteLine(messageInfoReplyToMessage);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Entities"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoEntitiesTest()
        {
            const string type = "type";
            const int offset= 10;
            const int length = 12345;
            const string url = "url";

            const int id = 123;
            const string firstName = "name";
            const string lastName = "lastName";
            const string username = "username";
            const string languageCode = "code";

            JObject user = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            dynamic messageInfoEntities = mMandatoryFieldsMessageInfo;

            messageInfoEntities.entities = new JArray(MessageEntityInfoObject.GetObject(type, offset, length, url, user));

            MessageInfo messageInfo = new MessageInfo(messageInfoEntities);

            //test MessageInfo.Entities
            Assert.AreEqual(messageInfo.Entities[0].Type, type);
            Assert.AreEqual(messageInfo.Entities[0].Offset, offset);
            Assert.AreEqual(messageInfo.Entities[0].Length, length);
            Assert.AreEqual(messageInfo.Entities[0].Url, url);

            //test MessageInfo.Entities.User
            Assert.AreEqual(messageInfo.Entities[0].User.Id, id);
            Assert.AreEqual(messageInfo.Entities[0].User.FirstName, firstName);
            Assert.AreEqual(messageInfo.Entities[0].User.LastName, lastName);
            Assert.AreEqual(messageInfo.Entities[0].User.UserName, username);
            Assert.AreEqual(messageInfo.Entities[0].User.LanguageCode, languageCode);

            Console.WriteLine(messageInfoEntities);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.EditDate"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoEditDateTest()
        {
            //check MessageInfo without field [edit_date]
            dynamic messageInfoEditDate = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoEditDate);
            Assert.AreEqual(messageInfo.EditDateUnix, 0);
            Assert.AreEqual(messageInfo.EditDate, DateTime.MinValue);

            //check MessageInfo with field [edit_date: 0] 
            messageInfoEditDate.edit_date = 0;
            messageInfo = new MessageInfo(messageInfoEditDate);
            Assert.AreEqual(messageInfo.EditDateUnix, 0);
            Assert.AreEqual(messageInfo.EditDate, new DateTime(1970, 1, 1).ToLocalTime());

            Console.WriteLine(messageInfoEditDate);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Text"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoTextTest()
        {
            //check MessageInfo without field [text]
            dynamic messageInfoText = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoText);
            Assert.AreEqual(messageInfo.Text, string.Empty);

            //check MessageInfo with field [text: TestText] 
            messageInfoText.text = "TestText";
            messageInfo = new MessageInfo(messageInfoText);
            Assert.AreEqual(messageInfo.Text, "TestText");

            Console.WriteLine(messageInfoText);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Audio"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoAudioTest()
        {
            const string fileId = "100";
            const int duration = 100;
            const string performer = "performerTest";
            const string title = "AudioInfo";
            const string mimeType = "mimeTypeTest";
            const int fileSize = 10;

            dynamic messageInfoAudio = mMandatoryFieldsMessageInfo;

            messageInfoAudio.audio = AudioInfoObject.GetObject(fileId, duration, performer,
                title, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoAudio);

            //test MessageInfo.Audio
            Assert.AreEqual(messageInfo.Audio.FileId, fileId);
            Assert.AreEqual(messageInfo.Audio.Duration, duration);
            Assert.AreEqual(messageInfo.Audio.Performer, performer);
            Assert.AreEqual(messageInfo.Audio.Title, title);
            Assert.AreEqual(messageInfo.Audio.MimeType, mimeType);
            Assert.AreEqual(messageInfo.Audio.FileSize, fileSize);

            Console.WriteLine(messageInfoAudio);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Document"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoDocumentTest()
        {
            const string fileId = "100";
            const string mimeType = "mimeTypeTest";
            const string fileName = "testFleName";
            const int fileSize = 10;

            const int width = 100;
            const int height = 100;

            dynamic messageInfoDocument = mMandatoryFieldsMessageInfo;

            messageInfoDocument.document = DocumentInfoObject.GetObject(fileId,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), fileName, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoDocument);

            //test MessageInfo.Document
            Assert.AreEqual(messageInfo.Document.FileId, fileId);
            Assert.AreEqual(messageInfo.Document.FileName, fileName);
            Assert.AreEqual(messageInfo.Document.MimeType, mimeType);
            Assert.AreEqual(messageInfo.Document.FileSize, fileSize);

            //test MessageInfo.Document.Thumb
            Assert.AreEqual(messageInfo.Document.Thumb.FileId, fileId);
            Assert.AreEqual(messageInfo.Document.Thumb.Width, width);
            Assert.AreEqual(messageInfo.Document.Thumb.Height, height);
            Assert.AreEqual(messageInfo.Document.Thumb.FileSize, fileSize);


            Console.WriteLine(messageInfoDocument);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Photo"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoPhotoTest()
        {
            const string fileId = "100";
            const int width = 100;
            const int height = 100;
            const int fileSize = 10;
            
            dynamic messageInfoPhoto = mMandatoryFieldsMessageInfo;

            JArray photoArray = new JArray(PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize));

            messageInfoPhoto.photo = photoArray;

            MessageInfo messageInfo = new MessageInfo(messageInfoPhoto);

            //test MessageInfo.Photo
            Assert.AreEqual(messageInfo.Photo[0].FileId, fileId);
            Assert.AreEqual(messageInfo.Photo[0].Width, width);
            Assert.AreEqual(messageInfo.Photo[0].Height, height);
            Assert.AreEqual(messageInfo.Photo[0].FileSize, fileSize);

            Console.WriteLine(messageInfoPhoto);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Sticker"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoStickerTest()
        {
            const string fileId = "100";
            const int width = 100;
            const int height = 100;
            const string emoji = "emoji";
            const int fileSize = 10;

            dynamic messageInfoSticker = mMandatoryFieldsMessageInfo;

            messageInfoSticker.sticker = StickerInfoObject.GetObject(fileId, width, height,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), emoji, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoSticker);

            Assert.Multiple(() =>
            {
                //test MessageInfo.Sticker
                Assert.AreEqual(fileId, messageInfo.Sticker.FileId);
                Assert.AreEqual(width, messageInfo.Sticker.Width);
                Assert.AreEqual(height, messageInfo.Sticker.Height);
                Assert.AreEqual(emoji, messageInfo.Sticker.Emoji);
                Assert.AreEqual(fileSize, messageInfo.Sticker.FileSize);

                //test MessageInfo.Sticker.Thumb
                Assert.AreEqual(fileId, messageInfo.Sticker.Thumb.FileId);
                Assert.AreEqual(width, messageInfo.Sticker.Thumb.Width);
                Assert.AreEqual(height, messageInfo.Sticker.Thumb.Height);
                Assert.AreEqual(fileSize, messageInfo.Sticker.Thumb.FileSize);
            });

            Console.WriteLine(messageInfoSticker);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Video"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoVideoTest()
        {
            const string fileId = "100";
            const int width = 1000;
            const int height = 10000;
            const int duration = 1000;
            const string mimeType = "mimeType";
            const int fileSize = 100;

            dynamic messageInfoVideo = mMandatoryFieldsMessageInfo;

            messageInfoVideo.video = VideoInfoObject.GetObject(fileId, width, height, duration,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoVideo);

            Assert.Multiple(() =>
            {
                //test MessageInfo.Video
                Assert.AreEqual(fileId, messageInfo.Video.FileId);
                Assert.AreEqual(width, messageInfo.Video.Width);
                Assert.AreEqual(height, messageInfo.Video.Height);
                Assert.AreEqual(duration, messageInfo.Video.Duration);
                Assert.AreEqual(mimeType, messageInfo.Video.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Video.FileSize);

                //test MessageInfo.Video.Thumb
                Assert.AreEqual(fileId, messageInfo.Video.Thumb.FileId);
                Assert.AreEqual(width, messageInfo.Video.Thumb.Width);
                Assert.AreEqual(height, messageInfo.Video.Thumb.Height);
                Assert.AreEqual(fileSize, messageInfo.Video.Thumb.FileSize);
            });
         

            Console.WriteLine(messageInfoVideo);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Voice"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoVoiceTest()
        {
            const string fileId = "100";
            const int duration = 100;
            const string mimeType = "mimeTypeTest";
            const int fileSize = 10;

            dynamic messageInfoVoice = mMandatoryFieldsMessageInfo;

            messageInfoVoice.voice = VoiceInfoObject.GetObject(fileId, duration, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoVoice);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(fileId, messageInfo.Voice.FileId);
                Assert.AreEqual(duration, messageInfo.Voice.Duration);
                Assert.AreEqual(mimeType, messageInfo.Voice.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Voice.FileSize);
            });

            Console.WriteLine(messageInfoVoice);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Caption"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoCaptionTest()
        {
            //check MessageInfo without field [caption]
            dynamic messageInfoCaption = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoCaption);
            Assert.AreEqual(messageInfo.Caption, string.Empty);

            //check MessageInfo with field [caption: TestCaption] 
            messageInfoCaption.caption = "TestCaption";
            messageInfo = new MessageInfo(messageInfoCaption);

            Assert.AreEqual(messageInfo.Caption, "TestCaption");

            Console.WriteLine(messageInfoCaption);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Contact"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoContactTest()
        {
            const string phoneNumber = "8080808080";
            const string firstName = "Test Name";
            const string lastName = "Test Last Name";
            const string userId = "0545006540";

            dynamic messageInfoContact = mMandatoryFieldsMessageInfo;

            messageInfoContact.contact = ContactInfoObject.GetObject(phoneNumber, firstName, lastName,
                userId);

            MessageInfo messageInfo = new MessageInfo(messageInfoContact);


            Assert.Multiple(() =>
            {
                Assert.AreEqual(phoneNumber, messageInfo.Contact.PhoneNumber);
                Assert.AreEqual(firstName, messageInfo.Contact.FirstName);
                Assert.AreEqual(lastName, messageInfo.Contact.LastName);
                Assert.AreEqual(userId, messageInfo.Contact.UserId);

                Console.WriteLine(messageInfoContact);
            });
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Location"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoLocationTest()
        {
            const float longitude = 1000;
            const float latitude = 1000;

            dynamic messageInfoLocation = mMandatoryFieldsMessageInfo;

            messageInfoLocation.location = LocationInfoObject.GetObject(longitude, latitude);

            MessageInfo messageInfo = new MessageInfo(messageInfoLocation);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(latitude, messageInfo.Location.Latitude);
                Assert.AreEqual(longitude, messageInfo.Location.Longitude);
            });
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Venue"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoVenueTest()
        {
            const float longitude = 1000;
            const float latitude = 1000;
            JObject locationInfo = LocationInfoObject.GetObject(longitude, latitude);

            const string title = "TestTitle";
            const string address = "TestAddress";
            const string foursquareId = "TestfoursquareId";

            dynamic messageInfoVenue = mMandatoryFieldsMessageInfo;

            messageInfoVenue.venue = VenueInfoObject.GetObject(locationInfo, title, address, foursquareId);

            MessageInfo messageInfo = new MessageInfo(messageInfoVenue);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(longitude, messageInfo.Venue.Location.Latitude);
                Assert.AreEqual(latitude, messageInfo.Venue.Location.Latitude);
                Assert.AreEqual(title, messageInfo.Venue.Title);
                Assert.AreEqual(address, messageInfo.Venue.Address);
                Assert.AreEqual(foursquareId, messageInfo.Venue.FoursquareId);
            }); 
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatMember"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatMemberTest()
        {
            const int id = 1000;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.new_chat_member = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.NewChatMember.Id);
                Assert.AreEqual(firstName, messageInfo.NewChatMember.FirstName);
                Assert.AreEqual(lastName, messageInfo.NewChatMember.LastName);
                Assert.AreEqual(messageInfo.NewChatMember.UserName, username);
                Assert.AreEqual(messageInfo.NewChatMember.LanguageCode, languageCode);
            });
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.LeftChatMember"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoLeftChatMemberTest()
        {
            const int id = 1000;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.left_chat_member = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.LeftChatMember.Id);
                Assert.AreEqual(firstName, messageInfo.LeftChatMember.FirstName);
                Assert.AreEqual(lastName, messageInfo.LeftChatMember.LastName);
                Assert.AreEqual(username, messageInfo.LeftChatMember.UserName);
                Assert.AreEqual(languageCode, messageInfo.LeftChatMember.LanguageCode);
            });
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatTitle"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatTitleTest()
        {
            //check MessageInfo without field [new_chat_title]
            dynamic messageInfoNewChatTitle = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoNewChatTitle);
            Assert.AreEqual(messageInfo.NewChatTitle, string.Empty);

            //check MessageInfo with field [new_chat_title: TestTitle] 
            messageInfoNewChatTitle.new_chat_title = "TestTitle";
            messageInfo = new MessageInfo(messageInfoNewChatTitle);
            Assert.AreEqual(messageInfo.NewChatTitle, "TestTitle");

            Console.WriteLine(messageInfoNewChatTitle);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatPhoto"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatPhotoTest()
        {
            const string fileId = "100";
            const int width = 100;
            const int height = 100;
            const int fileSize = 10;

            dynamic messageInfoNewChatPhoto = mMandatoryFieldsMessageInfo;

            JArray photoArray = new JArray(PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize));

            messageInfoNewChatPhoto.new_chat_photo = photoArray;

            MessageInfo messageInfo = new MessageInfo(messageInfoNewChatPhoto);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(fileId, messageInfo.NewChatPhoto[0].FileId);
                Assert.AreEqual(width, messageInfo.NewChatPhoto[0].Width);
                Assert.AreEqual(height, messageInfo.NewChatPhoto[0].Height);
                Assert.AreEqual(fileSize, messageInfo.NewChatPhoto[0].FileSize);
            });

            Console.WriteLine(messageInfoNewChatPhoto);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.DeleteChatPhoto"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoDeleteChatPhotoTest()
        {
            //check MessageInfo without field [delete_chat_photo]
            dynamic deleteChatPhoto = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(deleteChatPhoto);
            Assert.False(messageInfo.DeleteChatPhoto);

            //check MessageInfo with field [delete_chat_photo: true] 
            deleteChatPhoto.delete_chat_photo = true;
            messageInfo = new MessageInfo(deleteChatPhoto);
            Assert.True(messageInfo.DeleteChatPhoto);

            Console.WriteLine(deleteChatPhoto);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.GroupChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoGroupChatCreatedTest()
        {
            //check MessageInfo without field [group_chat_created]
            dynamic groupChatCreated = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(groupChatCreated);
            Assert.False(messageInfo.GroupChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            groupChatCreated.group_chat_created = true;
            messageInfo = new MessageInfo(groupChatCreated);
            Assert.True(messageInfo.GroupChatCreated);

            Console.WriteLine(groupChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.SuperGroupChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoSuperGroupChatCreatedTest()
        {
            //check MessageInfo without field [supergroup_chat_created]
            dynamic superGroupChatCreated = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(superGroupChatCreated);
            Assert.False(messageInfo.SuperGroupChatCreated);

            //check MessageInfo with field [supergroup_chat_created: true] 
            superGroupChatCreated.supergroup_chat_created = true;
            messageInfo = new MessageInfo(superGroupChatCreated);
            Assert.True(messageInfo.SuperGroupChatCreated);

            Console.WriteLine(superGroupChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ChannelChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoChannelChatCreatedTest()
        {
            //check MessageInfo without field [group_chat_created]
            dynamic channelChatCreated = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(channelChatCreated);
            Assert.False(messageInfo.ChannelChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            channelChatCreated.channel_chat_created = true;
            messageInfo = new MessageInfo(channelChatCreated);
            Assert.True(messageInfo.ChannelChatCreated);

            Console.WriteLine(channelChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.MigrateToChatId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoMigrateToChatIdTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic messageInfoMigrateToChatId = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoMigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            messageInfoMigrateToChatId.migrate_to_chat_id = 14881488;
            messageInfo = new MessageInfo(messageInfoMigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 14881488);

            Console.WriteLine(messageInfoMigrateToChatId);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.MigrateFromChatId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoMigrateFromChatIdTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic migrateFromChatId = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(migrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            migrateFromChatId.migrate_from_chat_id = 14881488;
            messageInfo = new MessageInfo(migrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 14881488);

            Console.WriteLine(migrateFromChatId);
        }
        
        [Test, Obsolete]
        public static void MandatoryFieldsMessageInfoTest()
        {
            dynamic mandatoryMessageInfoFields = mMandatoryFieldsMessageInfo;

            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.MessageId, -1147483648);
            Assert.AreEqual(messageInfo.DateUnix, 0);
            Assert.AreEqual(messageInfo.Date, new DateTime(1970, 1, 1).ToLocalTime());
            Assert.AreEqual(messageInfo.Chat.Id, 1049413668);
            

            Console.WriteLine(mandatoryMessageInfoFields);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.PinnedMessage"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoPinnedMessageTest()
        {
            const int messageId = 1000;
            const int date = 0;
            const int chatId = 125421;

            dynamic messageInfoPinnedMessage = mMandatoryFieldsMessageInfo;
            
            messageInfoPinnedMessage.pinned_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, ChatType.@group);

            MessageInfo messageInfo = new MessageInfo(messageInfoPinnedMessage);

            Assert.AreEqual(messageInfo.PinnedMessage.MessageId, messageId);
            Assert.AreEqual(messageInfo.PinnedMessage.DateUnix, date);
            Assert.AreEqual(messageInfo.PinnedMessage.Chat.Id, chatId);

            Console.WriteLine(messageInfoPinnedMessage);
        }
    }
}
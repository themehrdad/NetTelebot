using System;
using System.Linq;
using NetTelebot.BotEnum;
using NetTelebot.Extension;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.GameObject;
using NetTelebot.Tests.TypeTestObject.PaymentObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
#pragma warning disable 618

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class MessageInfoParserTest
    {

        #region Common object

        private static JObject MCommonMandatoryFieldsMessageInfo { get; } =
            MessageInfoObject.GetMandatoryFieldsMessageInfo(-1147483648, 0,
                1049413668, ChatType.@group);

        //UserInfo
        private const int mId = 123;
        private const bool mIsBot = true;
        private const string mFirstName = "testName";
        private const string mLastName = "testLastName";
        private const string mUsername = "testUsername";
        private const string mLanguageCode = "testLanguageCode";

        private static JObject MCommonUserInfo { get;  } = 
            UserInfoObject.GetObject(mId, mIsBot, mFirstName, mLastName, mUsername, mLanguageCode);

        //PhotoSizeInfo
        private const string mFileId = "100";
        private const int mWidth = 100;
        private const int mHeight = 100;
        private const int mFileSize = 10;

        private static JObject MCommonPhotoSizeInfo { get; } = 
            PhotoSizeInfoObject.GetObject(mFileId, mWidth, mHeight, mFileSize);

        //ChatPhotoInfoObject
        private const string mSmallField = "123456";
        private const string mBigField = "654321";

        private static JObject MCommonChatPhotoInfo { get; } = ChatPhotoInfoObject.GetObject(mSmallField, mBigField);

        //ChatInfo
        private const int mChatId = 1049413668;
        private const string mType = "channel";
        private const string mTitle = "TestTitle";
        private const string mChatUsername = "TestUsername";
        private const string mChatFirstName = "TestFirstName";
        private const string mChatLastName = "TestLastName";
        private const bool mAllMembersAreAdministrators = false;
        private const string mDescription = "TestDescription";
        private const string mInviteLink = "TestLink";


        private static JObject MCommonChatInfo { get; } = ChatInfoObject.GetObject(mChatId, mType, mTitle, mChatUsername,
            mChatFirstName, mChatLastName, mAllMembersAreAdministrators, MCommonChatPhotoInfo, mDescription, mInviteLink);

        #endregion

        #region Common assert method

        private static void AssertUserInfo(UserInfo userInfo)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(mId, userInfo.Id);
                Assert.AreEqual(mIsBot, userInfo.IsBot);
                Assert.AreEqual(mFirstName, userInfo.FirstName);
                Assert.AreEqual(mLastName, userInfo.LastName);
                Assert.AreEqual(mUsername, userInfo.UserName);
                Assert.AreEqual(mLanguageCode, userInfo.LanguageCode);
            });
        }

        private static void AssertPhotoSizeInfo(PhotoSizeInfo photoSize)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(mFileId, photoSize.FileId);
                Assert.AreEqual(mWidth, photoSize.Width);
                Assert.AreEqual(mHeight, photoSize.Height);
                Assert.AreEqual(mFileSize, photoSize.FileSize);
            });
        }

        private static void AssertChatPhotoInfo(ChatPhotoInfo chatPhotoInfo)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(mBigField, chatPhotoInfo.BigFileId);
                Assert.AreEqual(mSmallField, chatPhotoInfo.SmallFileId);
            });
        }

        private static void AssertChatInfo(ChatInfo chatInfo)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ChatType.channel, chatInfo.Type);
                Assert.AreEqual(mChatId, chatInfo.Id);
                Assert.AreEqual(mTitle, chatInfo.Title);
                Assert.AreEqual(mChatUsername, chatInfo.Username);
                Assert.AreEqual(mChatFirstName, chatInfo.FirstName);
                Assert.AreEqual(mChatLastName, chatInfo.LastName);
                Assert.AreEqual(mAllMembersAreAdministrators, chatInfo.AllMembersAreAdministrators);
                Assert.AreEqual(mDescription, chatInfo.Description);
                Assert.AreEqual(mInviteLink, chatInfo.InviteLink);

                AssertChatPhotoInfo(chatInfo.Photo);
            });
        }

        #endregion

        /// <summary>
        /// Test for <see cref="MessageInfo.From"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoFromTest()
        {
            dynamic messageInfoUser = MCommonMandatoryFieldsMessageInfo;
            messageInfoUser.from = MCommonUserInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            AssertUserInfo(messageInfo.From);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFrom"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromTest()
        {
            dynamic messageInfoUser = MCommonMandatoryFieldsMessageInfo;
            messageInfoUser.forward_from = MCommonUserInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            AssertUserInfo(messageInfo.ForwardFrom);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFromChat"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromChatTest()
        {
            dynamic mandatoryMessageInfoFields = MCommonMandatoryFieldsMessageInfo;
            mandatoryMessageInfoFields.forward_from_chat = MCommonChatInfo;
            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            AssertChatInfo(messageInfo.ForwardFromChat);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFromMessageId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromMessageIdTest()
        {
            //check MessageInfo witout field [forward_from_message_id]
            dynamic messageInfoForwardFromMessageId = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoForwardFromMessageId);
            Assert.AreEqual(0, messageInfo.ForwardFromMessageId);

            //check MessageInfo with field [forward_from_message_id: 14881488] 
            messageInfoForwardFromMessageId.forward_from_message_id = 14881488;
            messageInfo = new MessageInfo(messageInfoForwardFromMessageId);
            Assert.AreEqual(14881488, messageInfo.ForwardFromMessageId);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardSignature"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardSignatureTest()
        {
            //check MessageInfo witout field [forward_signature]
            dynamic messageInfoForwardFromMessageId = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoForwardFromMessageId);
            Assert.AreEqual(string.Empty, messageInfo.ForwardSignature);

            //check MessageInfo with field [forward_signature: "TestForwardSignature"] 
            messageInfoForwardFromMessageId.forward_signature = "TestForwardSignature";
            messageInfo = new MessageInfo(messageInfoForwardFromMessageId);
            Assert.AreEqual("TestForwardSignature", messageInfo.ForwardSignature);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardDateUnix"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardDateUnixTest()
        {
            //check MessageInfo without field [forward_date]
            dynamic messageInfoForwardDateUnix = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoForwardDateUnix);
            Assert.AreEqual(0, messageInfo.ForwardDateUnix);
            Assert.AreEqual(DateTime.MinValue, messageInfo.ForwardDate);

            //check MessageInfo with field [forward_date: 0] 
            messageInfoForwardDateUnix.forward_date = 0;
            Assert.AreEqual(0, messageInfo.DateUnix);
            Assert.AreEqual(new DateTime(1970, 1, 1).ToLocalTime(), messageInfo.Date);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Chat"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoChatTest()
        {
            dynamic mandatoryMessageInfoFields = MCommonMandatoryFieldsMessageInfo;
            mandatoryMessageInfoFields.chat = MCommonChatInfo;
            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            AssertChatInfo(messageInfo.Chat);
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

            dynamic mandatoryMessageInfoFields = MCommonMandatoryFieldsMessageInfo;

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
            dynamic mandatoryMessageInfoFields = MCommonMandatoryFieldsMessageInfo;

            //private
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "private");
            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);
            
            Assert.AreEqual(ChatType.@private, messageInfo.Chat.Type);

            //channel
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "channel");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(ChatType.channel, messageInfo.Chat.Type);

            //group
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "group");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(ChatType.@group, messageInfo.Chat.Type);

            //supergroup
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "supergroup");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(ChatType.supergroup, messageInfo.Chat.Type);

            //null
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "grou");
            MessageInfo messageInfo2 = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(null, messageInfo2.Chat.Type);
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

            dynamic messageInfoReplyToMessage = MCommonMandatoryFieldsMessageInfo;

            messageInfoReplyToMessage.reply_to_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, ChatType.channel);

            MessageInfo messageInfo = new MessageInfo(messageInfoReplyToMessage);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(messageId, messageInfo.ReplyToMessage.MessageId);
                Assert.AreEqual(date, messageInfo.ReplyToMessage.DateUnix);
                Assert.AreEqual(chatId, messageInfo.ReplyToMessage.Chat.Id);
            });
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

            JObject user = MCommonUserInfo;
            dynamic messageInfoEntities = MCommonMandatoryFieldsMessageInfo;
            messageInfoEntities.entities = new JArray(MessageEntityInfoObject.GetObject(type, offset, length, url, user));

            MessageInfo messageInfo = new MessageInfo(messageInfoEntities);

            Assert.Multiple(() =>
            {
                //test MessageInfo.Entities
                Assert.AreEqual(type, messageInfo.Entities[0].Type);
                Assert.AreEqual(offset, messageInfo.Entities[0].Offset);
                Assert.AreEqual(length, messageInfo.Entities[0].Length);
                Assert.AreEqual(url, messageInfo.Entities[0].Url);
            });

            //test MessageInfo.Entities.User
            AssertUserInfo(messageInfo.Entities[0].User);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.CaptionEntities"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoCaptionEntitiesTest()
        {
            const string type = "type";
            const int offset = 10;
            const int length = 12345;
            const string url = "url";

            JObject user = MCommonUserInfo;
            dynamic messageInfoEntities = MCommonMandatoryFieldsMessageInfo;
            messageInfoEntities.caption_entities = new JArray(MessageEntityInfoObject.GetObject(type, offset, length, url, user));

            MessageInfo messageInfo = new MessageInfo(messageInfoEntities);

            Assert.Multiple(() =>
            {
                //test MessageInfo.Entities
                Assert.AreEqual(type, messageInfo.CaptionEntities[0].Type);
                Assert.AreEqual(offset, messageInfo.CaptionEntities[0].Offset);
                Assert.AreEqual(length, messageInfo.CaptionEntities[0].Length);
                Assert.AreEqual(url, messageInfo.CaptionEntities[0].Url);
            });

            //test MessageInfo.Entities.User
            AssertUserInfo(messageInfo.CaptionEntities[0].User);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.EditDate"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoEditDateTest()
        {
            //check MessageInfo without field [edit_date]
            dynamic messageInfoEditDate = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoEditDate);

            Assert.AreEqual(0, messageInfo.EditDateUnix);
            Assert.AreEqual(DateTime.MinValue, messageInfo.EditDate);

            //check MessageInfo with field [edit_date: 0] 
            messageInfoEditDate.edit_date = 0;
            messageInfo = new MessageInfo(messageInfoEditDate);

            Assert.AreEqual(0, messageInfo.EditDateUnix);
            Assert.AreEqual(new DateTime(1970, 1, 1).ToLocalTime(), messageInfo.EditDate);
        }

        [Test]
        public static void MessageInfoAuthorSignatureTest()
        {
            //check MessageInfo without field [author_signature]
            dynamic messageInfoText = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoText);
            Assert.AreEqual(string.Empty, messageInfo.AuthorSignature);

            //check MessageInfo with field [author_signature: TestAuthorSignature] 
            messageInfoText.author_signature = "TestAuthorSignature";
            messageInfo = new MessageInfo(messageInfoText);
            Assert.AreEqual("TestAuthorSignature", messageInfo.AuthorSignature);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Text"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoTextTest()
        {
            //check MessageInfo without field [text]
            dynamic messageInfoText = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoText);
            Assert.AreEqual(string.Empty, messageInfo.Text);

            //check MessageInfo with field [text: TestText] 
            messageInfoText.text = "TestText";
            messageInfo = new MessageInfo(messageInfoText);
            Assert.AreEqual("TestText", messageInfo.Text);
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

            dynamic messageInfoAudio = MCommonMandatoryFieldsMessageInfo;

            messageInfoAudio.audio = AudioInfoObject.GetObject(fileId, duration, performer,
                title, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoAudio);

            Assert.Multiple(() =>
            {
                //test MessageInfo.Audio
                Assert.AreEqual(fileId, messageInfo.Audio.FileId);
                Assert.AreEqual(duration, messageInfo.Audio.Duration);
                Assert.AreEqual(performer, messageInfo.Audio.Performer);
                Assert.AreEqual(title, messageInfo.Audio.Title);
                Assert.AreEqual(mimeType, messageInfo.Audio.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Audio.FileSize);
            });
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

            dynamic messageInfoDocument = MCommonMandatoryFieldsMessageInfo;

            messageInfoDocument.document = DocumentInfoObject.GetObject(fileId,
               MCommonPhotoSizeInfo, fileName, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoDocument);

            Assert.Multiple(() =>
            {
                //test MessageInfo.Document
                Assert.AreEqual(fileId, messageInfo.Document.FileId);
                Assert.AreEqual(fileName, messageInfo.Document.FileName);
                Assert.AreEqual(mimeType, messageInfo.Document.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Document.FileSize);
            });

            AssertPhotoSizeInfo(messageInfo.Document.Thumb);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Game"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoGameTest()
        {
            const string title = "TestTitle";
            const string description = "TestDescription";
            const string text = "TestText";

            //AnimationInfo field
            const string fileId = "100";
            const string mimeType = "mimeTypeTest";
            const string fileName = "testFleName";
            const int fileSize = 10;
            JObject animation = AnimationInfoObject.GetObject(fileId, MCommonPhotoSizeInfo, fileName, mimeType, fileSize);
            
            //MessageEntityInfo field
            const string type = "TestType";
            const int offset = 123456;
            const int length = 123456;
            const string url = "TestUrl";
            JArray entities = new JArray(MessageEntityInfoObject.GetObject(type, offset, length, url, MCommonUserInfo));

            dynamic messageInfoGame = MCommonMandatoryFieldsMessageInfo;

            messageInfoGame.game = GameInfoObject.GetObject(title, description, new JArray(MCommonPhotoSizeInfo), text, entities, animation);

            MessageInfo messageInfo = new MessageInfo(messageInfoGame);

            Assert.Multiple(() =>
            {
                //Game
                Assert.AreEqual(title, messageInfo.Game.Title);
                Assert.AreEqual(description, messageInfo.Game.Description);
                Assert.AreEqual(text, messageInfo.Game.Text);

                //Game.Entities
                Assert.AreEqual(type, messageInfo.Game.Entities[0].Type);
                Assert.AreEqual(offset, messageInfo.Game.Entities[0].Offset);
                Assert.AreEqual(length, messageInfo.Game.Entities[0].Length);
                Assert.AreEqual(url, messageInfo.Game.Entities[0].Url);

                //Game.Animation
                Assert.AreEqual(fileId, messageInfo.Game.Animation.FileId);
                Assert.AreEqual(fileName, messageInfo.Game.Animation.FileName);
                Assert.AreEqual(mimeType, messageInfo.Game.Animation.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Game.Animation.FileSize);
            });

            //Game.Entites.User
            AssertUserInfo(messageInfo.Game.Entities[0].User);

            //Game.Photo
            AssertPhotoSizeInfo(messageInfo.Game.Photo[0]);

            //Game.Animation.Thumb
            AssertPhotoSizeInfo(messageInfo.Game.Animation.Thumb);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Photo"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoPhotoTest()
        {
            dynamic messageInfoPhoto = MCommonMandatoryFieldsMessageInfo;
            messageInfoPhoto.photo = new JArray(MCommonPhotoSizeInfo);
            MessageInfo messageInfo = new MessageInfo(messageInfoPhoto);

            AssertPhotoSizeInfo(messageInfo.Photo[0]);
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

            dynamic messageInfoSticker = MCommonMandatoryFieldsMessageInfo;

            messageInfoSticker.sticker = StickerInfoObject.GetObject(fileId, width, height,
                MCommonPhotoSizeInfo, emoji, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoSticker);

            Assert.Multiple(() =>
            {
                //test MessageInfo.Sticker
                Assert.AreEqual(fileId, messageInfo.Sticker.FileId);
                Assert.AreEqual(width, messageInfo.Sticker.Width);
                Assert.AreEqual(height, messageInfo.Sticker.Height);
                Assert.AreEqual(emoji, messageInfo.Sticker.Emoji);
                Assert.AreEqual(fileSize, messageInfo.Sticker.FileSize);
            });

            //test MessageInfo.Sticker.Thumb
            AssertPhotoSizeInfo(messageInfo.Sticker.Thumb);
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

            dynamic messageInfoVideo = MCommonMandatoryFieldsMessageInfo;

            messageInfoVideo.video = VideoInfoObject.GetObject(fileId, width, height, duration,
                MCommonPhotoSizeInfo, mimeType, fileSize);

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
            });

            //test MessageInfo.Video.Thumb
            AssertPhotoSizeInfo(messageInfo.Video.Thumb);
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

            dynamic messageInfoVoice = MCommonMandatoryFieldsMessageInfo;

            messageInfoVoice.voice = VoiceInfoObject.GetObject(fileId, duration, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoVoice);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(fileId, messageInfo.Voice.FileId);
                Assert.AreEqual(duration, messageInfo.Voice.Duration);
                Assert.AreEqual(mimeType, messageInfo.Voice.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Voice.FileSize);
            });
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.VideoNote"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoVideoNoteTest()
        {
            const string fileId = "100";
            const int length = 123;
            const int duration = 100;
            const int fileSize = 10;

            dynamic messageInfoVoice = MCommonMandatoryFieldsMessageInfo;

            messageInfoVoice.video_note = VideoNoteInfoObject.GetObject(
                fileId, length, duration, MCommonPhotoSizeInfo, fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoVoice);

            Assert.Multiple(() =>
            {
                //test MessageInfo.VideoNote
                Assert.AreEqual(fileId, messageInfo.VideoNote.FileId);
                Assert.AreEqual(length, messageInfo.VideoNote.Length);
                Assert.AreEqual(duration, messageInfo.VideoNote.Duration);
                Assert.AreEqual(fileSize, messageInfo.VideoNote.FileSize);
            });

            //test MessageInfo.VideoNote.Thumb
            AssertPhotoSizeInfo(messageInfo.VideoNote.Thumb);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatMembers"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatMembersTest()
        {
            dynamic messageInfoUser = MCommonMandatoryFieldsMessageInfo;
            messageInfoUser.new_chat_members = new JArray(MCommonUserInfo);
            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            AssertUserInfo(messageInfo.NewChatMembers[0]);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Caption"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoCaptionTest()
        {
            //check MessageInfo without field [caption]
            dynamic messageInfoCaption = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoCaption);
            Assert.AreEqual(string.Empty, messageInfo.Caption);

            //check MessageInfo with field [caption: TestCaption] 
            messageInfoCaption.caption = "TestCaption";
            messageInfo = new MessageInfo(messageInfoCaption);

            Assert.AreEqual("TestCaption", messageInfo.Caption);
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

            dynamic messageInfoContact = MCommonMandatoryFieldsMessageInfo;
            messageInfoContact.contact = ContactInfoObject.GetObject(phoneNumber, firstName, lastName,
                userId);

            MessageInfo messageInfo = new MessageInfo(messageInfoContact);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(phoneNumber, messageInfo.Contact.PhoneNumber);
                Assert.AreEqual(firstName, messageInfo.Contact.FirstName);
                Assert.AreEqual(lastName, messageInfo.Contact.LastName);
                Assert.AreEqual(userId, messageInfo.Contact.UserId);
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

            dynamic messageInfoLocation = MCommonMandatoryFieldsMessageInfo;
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

            dynamic messageInfoVenue = MCommonMandatoryFieldsMessageInfo;
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
            dynamic messageInfoUser = MCommonMandatoryFieldsMessageInfo;
            messageInfoUser.new_chat_member = MCommonUserInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            AssertUserInfo(messageInfo.NewChatMember);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.LeftChatMember"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoLeftChatMemberTest()
        {
            dynamic messageInfoUser = MCommonMandatoryFieldsMessageInfo;
            messageInfoUser.left_chat_member = MCommonUserInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            AssertUserInfo(messageInfo.LeftChatMember);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatTitle"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatTitleTest()
        {
            //check MessageInfo without field [new_chat_title]
            dynamic messageInfoNewChatTitle = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoNewChatTitle);
            Assert.AreEqual(string.Empty, messageInfo.NewChatTitle);

            //check MessageInfo with field [new_chat_title: TestTitle] 
            messageInfoNewChatTitle.new_chat_title = "TestTitle";
            messageInfo = new MessageInfo(messageInfoNewChatTitle);
            Assert.AreEqual("TestTitle", messageInfo.NewChatTitle);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatPhoto"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatPhotoTest()
        {
            dynamic messageInfoNewChatPhoto = MCommonMandatoryFieldsMessageInfo;
            messageInfoNewChatPhoto.new_chat_photo = new JArray(MCommonPhotoSizeInfo); 
            MessageInfo messageInfo = new MessageInfo(messageInfoNewChatPhoto);

            AssertPhotoSizeInfo(messageInfo.NewChatPhoto[0]);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.DeleteChatPhoto"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoDeleteChatPhotoTest()
        {
            //check MessageInfo without field [delete_chat_photo]
            dynamic deleteChatPhoto = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(deleteChatPhoto);
            Assert.False(messageInfo.DeleteChatPhoto);

            //check MessageInfo with field [delete_chat_photo: true] 
            deleteChatPhoto.delete_chat_photo = true;
            messageInfo = new MessageInfo(deleteChatPhoto);
            Assert.True(messageInfo.DeleteChatPhoto);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.GroupChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoGroupChatCreatedTest()
        {
            //check MessageInfo without field [group_chat_created]
            dynamic groupChatCreated = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(groupChatCreated);
            Assert.False(messageInfo.GroupChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            groupChatCreated.group_chat_created = true;
            messageInfo = new MessageInfo(groupChatCreated);
            Assert.True(messageInfo.GroupChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.SuperGroupChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoSuperGroupChatCreatedTest()
        {
            //check MessageInfo without field [supergroup_chat_created]
            dynamic superGroupChatCreated = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(superGroupChatCreated);
            Assert.False(messageInfo.SuperGroupChatCreated);

            //check MessageInfo with field [supergroup_chat_created: true] 
            superGroupChatCreated.supergroup_chat_created = true;
            messageInfo = new MessageInfo(superGroupChatCreated);
            Assert.True(messageInfo.SuperGroupChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ChannelChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoChannelChatCreatedTest()
        {
            //check MessageInfo without field [group_chat_created]
            dynamic channelChatCreated = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(channelChatCreated);
            Assert.False(messageInfo.ChannelChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            channelChatCreated.channel_chat_created = true;
            messageInfo = new MessageInfo(channelChatCreated);
            Assert.True(messageInfo.ChannelChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.MigrateToChatId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoMigrateToChatIdTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic messageInfoMigrateToChatId = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(messageInfoMigrateToChatId);
            Assert.AreEqual(0, messageInfo.MigrateToChatId);

            //check MessageInfo with field [group_chat_created: true] 
            messageInfoMigrateToChatId.migrate_to_chat_id = 14881488;
            messageInfo = new MessageInfo(messageInfoMigrateToChatId);
            Assert.AreEqual(14881488, messageInfo.MigrateToChatId);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.MigrateFromChatId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoMigrateFromChatIdTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic migrateFromChatId = MCommonMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(migrateFromChatId);
            Assert.AreEqual(0, messageInfo.MigrateFromChatId);

            //check MessageInfo with field [group_chat_created: true] 
            migrateFromChatId.migrate_from_chat_id = 14881488;
            messageInfo = new MessageInfo(migrateFromChatId);
            Assert.AreEqual(14881488, messageInfo.MigrateFromChatId);
        }
        
        [Test]
        public static void MandatoryFieldsMessageInfoTest()
        {
            MessageInfo messageInfo = new MessageInfo(MCommonMandatoryFieldsMessageInfo);

            Assert.AreEqual(-1147483648, messageInfo.MessageId);
            Assert.AreEqual(0, messageInfo.DateUnix);
            Assert.AreEqual(new DateTime(1970, 1, 1).ToLocalTime(), messageInfo.Date);
            Assert.AreEqual(1049413668, messageInfo.Chat.Id);
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

            dynamic messageInfoPinnedMessage = MCommonMandatoryFieldsMessageInfo;
            messageInfoPinnedMessage.pinned_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, ChatType.@group);

            MessageInfo messageInfo = new MessageInfo(messageInfoPinnedMessage);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(messageId, messageInfo.PinnedMessage.MessageId);
                Assert.AreEqual(date, messageInfo.PinnedMessage.DateUnix);
                Assert.AreEqual(chatId, messageInfo.PinnedMessage.Chat.Id);
            });
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Invoice"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoInvoiceTest()
        {
            const string title = "TestTitle";
            const string description = "TestDescription";
            const string startParameter = "TestStartParameter";
            const string currency = "USD";
            const int totalAmount = 123;

            dynamic messageInfoInvoice = MCommonMandatoryFieldsMessageInfo;
            messageInfoInvoice.invoice = InvoiceInfoObject.GetObject(title, description, startParameter,
                currency, totalAmount);

            MessageInfo messageInfo = new MessageInfo(messageInfoInvoice);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(title, messageInfo.Invoice.Title);
                Assert.AreEqual(description, messageInfo.Invoice.Description);
                Assert.AreEqual(startParameter, messageInfo.Invoice.StartParameter);
                Assert.AreEqual(Currency.USD, messageInfo.Invoice.Currency);
                Assert.AreEqual(totalAmount, messageInfo.Invoice.TotalAmmount);
            });
        }

        [Test]
        public static void MessageInfoInvoiceToEnumTest()
        {
            var enumStringList = Enum.GetValues(typeof(Currency))
                .Cast<Currency>()
                .Select(v => v.ToString())
                .ToList();

            var enumList = Enum.GetValues(typeof(Currency))
                .Cast<Currency>()
                .ToList(); 

            for (var i = 0; i < enumStringList.Count; i++)
            {
                Assert.AreEqual(enumStringList[i].ToEnum<Currency>(), enumList[i]);
                Console.WriteLine("Now equals {0} and {1}", enumStringList[i], enumList[i]);
            }
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.SuccessfulPayment"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoSuccessfulPaymentTest()
        {
            //SuccessfulPaymentInfo field
            const string currency = "USD";
            const int totalAmount = 123;
            const string invoicePayload = "TestInvoicePayload";
            const string shippingOptionId = "TestShippingOptionId";
            const string telegramPaymentChargeId = "TestTelegramPaymentChargeId";
            const string providerPaymentChargeId = "TestProviderPaymentChargeId";

            //OrderInfo fields
            const string name = "TestName";
            const string phoneNumber = "123456789";
            const string email = "test@email";

            //ShippingAddressInfo fields
            const string countryCode = "US";
            const string state = "TestState";
            const string city = "TestCity";
            const string streetLineOne = "TestStreetLineOne";
            const string streetLineTwo = "TestStreetLineTwo";
            const string postCode = "TestPostCode";

            JObject shippingAddress = ShippingAddressInfoObject.GetObject(countryCode, state, city, streetLineOne,
                streetLineTwo, postCode);

            JObject orderInfo = OrderInfoObject.GetObject(name, phoneNumber, email, shippingAddress);

            dynamic messageSuccessfulPayment = MCommonMandatoryFieldsMessageInfo;

            messageSuccessfulPayment.successful_payment = SuccessfulPaymentInfoObject.GetObject(currency, totalAmount,
                invoicePayload, shippingOptionId, orderInfo, telegramPaymentChargeId, providerPaymentChargeId);

            MessageInfo messageInfo = new MessageInfo(messageSuccessfulPayment);

            Assert.Multiple(() =>
            {
                //SuccessfulPaymentInfo field
                Assert.AreEqual(Currency.USD, messageInfo.SuccessfulPayment.Currency);
                Assert.AreEqual(totalAmount, messageInfo.SuccessfulPayment.TotalAmmount);
                Assert.AreEqual(invoicePayload, messageInfo.SuccessfulPayment.InvoicePayload);
                Assert.AreEqual(shippingOptionId, messageInfo.SuccessfulPayment.ShippingOptionId);
                Assert.AreEqual(telegramPaymentChargeId, messageInfo.SuccessfulPayment.TelegramPaymentChargeId);
                Assert.AreEqual(providerPaymentChargeId, messageInfo.SuccessfulPayment.ProviderPaymentChargeId);

                //OrderInfo fields
                Assert.AreEqual(name, messageInfo.SuccessfulPayment.OrderInfo.Name);
                Assert.AreEqual(phoneNumber, messageInfo.SuccessfulPayment.OrderInfo.PnoneNumber);
                Assert.AreEqual(email, messageInfo.SuccessfulPayment.OrderInfo.Email);

                //ShippingAddressInfo fields
                Assert.AreEqual(Countries.US, messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress.CountryCode);
                Assert.AreEqual(state, messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress.State);
                Assert.AreEqual(city, messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress.City);
                Assert.AreEqual(streetLineOne, messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress.StreetLineOne);
                Assert.AreEqual(streetLineTwo, messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress.StreetLineTwo);
                Assert.AreEqual(postCode, messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress.PostCode);
            });
        }

        [Test]
        public static void MessageInfoCountriesToEnumTest()
        {
            var enumStringList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(v => v.ToString())
                .ToList();

            var enumList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .ToList();

            for (var i = 0; i < enumStringList.Count; i++)
            {
                Assert.AreEqual(enumStringList[i].ToEnum<Countries>(), enumList[i]);
                Console.WriteLine("Now equals {0} and {1}", enumStringList[i], enumList[i]);
            }
        }
    }
}

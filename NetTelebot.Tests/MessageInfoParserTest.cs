using System;
using NetTelebot.Tests.TypeTestObject;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests
{
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

            dynamic MessageInfoUser = mMandatoryFieldsMessageInfo;

            MessageInfoUser.from = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(MessageInfoUser);

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

            dynamic MessageInfoUser = mMandatoryFieldsMessageInfo;

            MessageInfoUser.forward_from = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(MessageInfoUser);

            Assert.AreEqual(messageInfo.ForwardFrom.Id, id);
            Assert.AreEqual(messageInfo.ForwardFrom.FirstName, firstName);
            Assert.AreEqual(messageInfo.ForwardFrom.LastName, lastName);
            Assert.AreEqual(messageInfo.ForwardFrom.UserName, username);
            Assert.AreEqual(messageInfo.ForwardFrom.LanguageCode, languageCode);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFromMessageId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromMessageIdTest()
        {
            //check MessageInfo witout field [forward_from_message_id]
            dynamic MessageInfoForwardFromMessageId = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MessageInfoForwardFromMessageId);
            Assert.AreEqual(messageInfo.ForwardFromMessageId, 0);

            //check MessageInfo with field [forward_from_message_id: 14881488] 
            MessageInfoForwardFromMessageId.forward_from_message_id = 14881488;
            messageInfo = new MessageInfo(MessageInfoForwardFromMessageId);
            Assert.AreEqual(messageInfo.ForwardFromMessageId, 14881488);

            Console.WriteLine(MessageInfoForwardFromMessageId);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardDateUnix"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardDateUnixTest()
        {
            //check MessageInfo without field [forward_date]
            dynamic MessageInfoForwardDateUnix = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MessageInfoForwardDateUnix);
            Assert.AreEqual(messageInfo.ForwardDateUnix, 0);
            Assert.AreEqual(messageInfo.ForwardDate, DateTime.MinValue);

            //check MessageInfo with field [forward_date: 0] 
            MessageInfoForwardDateUnix.forward_date = 0;
            Assert.AreEqual(messageInfo.DateUnix, 0);
            Assert.AreEqual(messageInfo.Date, new DateTime(1970, 1, 1).ToLocalTime());

            Console.WriteLine(MessageInfoForwardDateUnix);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Chats"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoChatsTest()
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
        /// Test for parse <see cref="ChatType"/> in <see cref="MessageInfo.Chats"/> 
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

            dynamic MessageInfoReplyToMessage = mMandatoryFieldsMessageInfo;

            MessageInfoReplyToMessage.reply_to_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, ChatType.channel);

            MessageInfo messageInfo = new MessageInfo(MessageInfoReplyToMessage);

            Assert.AreEqual(messageInfo.ReplyToMessage.MessageId, messageId);
            Assert.AreEqual(messageInfo.ReplyToMessage.DateUnix, date);
            Assert.AreEqual(messageInfo.ReplyToMessage.Chat.Id, chatId);

            Console.WriteLine(MessageInfoReplyToMessage);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.EditDate"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoEditDateTest()
        {
            //check MessageInfo without field [edit_date]
            dynamic MessageInfoEditDate = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MessageInfoEditDate);
            Assert.AreEqual(messageInfo.EditDateUnix, 0);
            Assert.AreEqual(messageInfo.EditDate, DateTime.MinValue);

            //check MessageInfo with field [edit_date: 0] 
            MessageInfoEditDate.edit_date = 0;
            messageInfo = new MessageInfo(MessageInfoEditDate);
            Assert.AreEqual(messageInfo.EditDateUnix, 0);
            Assert.AreEqual(messageInfo.EditDate, new DateTime(1970, 1, 1).ToLocalTime());

            Console.WriteLine(MessageInfoEditDate);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Text"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoTextTest()
        {
            //check MessageInfo without field [text]
            dynamic MessageInfoText = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MessageInfoText);
            Assert.AreEqual(messageInfo.Text, string.Empty);

            //check MessageInfo with field [text: TestText] 
            MessageInfoText.text = "TestText";
            messageInfo = new MessageInfo(MessageInfoText);
            Assert.AreEqual(messageInfo.Text, "TestText");

            Console.WriteLine(MessageInfoText);
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

            dynamic MessageInfoAudio = mMandatoryFieldsMessageInfo;

            MessageInfoAudio.audio = AudioInfoObject.GetObject(fileId, duration, performer,
                title, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(MessageInfoAudio);

            //test MessageInfo.Audio
            Assert.AreEqual(messageInfo.Audio.FileId, fileId);
            Assert.AreEqual(messageInfo.Audio.Duration, duration);
            Assert.AreEqual(messageInfo.Audio.Performer, performer);
            Assert.AreEqual(messageInfo.Audio.Title, title);
            Assert.AreEqual(messageInfo.Audio.MimeType, mimeType);
            Assert.AreEqual(messageInfo.Audio.FileSize, fileSize);

            Console.WriteLine(MessageInfoAudio);
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

            dynamic MessageInfoDocument = mMandatoryFieldsMessageInfo;

            MessageInfoDocument.document = DocumentInfoObject.GetObject(fileId,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), fileName, mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(MessageInfoDocument);

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


            Console.WriteLine(MessageInfoDocument);
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
            
            dynamic MessageInfoPhoto = mMandatoryFieldsMessageInfo;

            JArray photoArray = new JArray(PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize));

            MessageInfoPhoto.photo = photoArray;

            MessageInfo messageInfo = new MessageInfo(MessageInfoPhoto);

            //test MessageInfo.Photo
            Assert.AreEqual(messageInfo.Photo[0].FileId, fileId);
            Assert.AreEqual(messageInfo.Photo[0].Width, width);
            Assert.AreEqual(messageInfo.Photo[0].Height, height);
            Assert.AreEqual(messageInfo.Photo[0].FileSize, fileSize);

            Console.WriteLine(MessageInfoPhoto);
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

            dynamic MessageInfoSticker = mMandatoryFieldsMessageInfo;

            MessageInfoSticker.sticker = StickerInfoObject.GetObject(fileId, width, height,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), emoji, fileSize);

            MessageInfo messageInfo = new MessageInfo(MessageInfoSticker);

            //test MessageInfo.Sticker
            Assert.AreEqual(messageInfo.Sticker.FileId, fileId);
            Assert.AreEqual(messageInfo.Sticker.Width, width);
            Assert.AreEqual(messageInfo.Sticker.Height, height);
            Assert.AreEqual(messageInfo.Sticker.Emoji, emoji);
            Assert.AreEqual(messageInfo.Sticker.FileSize, fileSize);

            //test MessageInfo.Sticker.Thumb
            Assert.AreEqual(messageInfo.Sticker.Thumb.FileId, fileId);
            Assert.AreEqual(messageInfo.Sticker.Thumb.Width, width);
            Assert.AreEqual(messageInfo.Sticker.Thumb.Height, height);
            Assert.AreEqual(messageInfo.Sticker.Thumb.FileSize, fileSize);

            Console.WriteLine(MessageInfoSticker);
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

            dynamic MessageInfoVideo = mMandatoryFieldsMessageInfo;

            MessageInfoVideo.video = VideoInfoObject.GetObject(fileId, width, height, duration,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), mimeType, fileSize);

            MessageInfo messageInfo = new MessageInfo(MessageInfoVideo);

            //test MessageInfo.Video
            Assert.AreEqual(messageInfo.Video.FileId, fileId);
            Assert.AreEqual(messageInfo.Video.Width, width);
            Assert.AreEqual(messageInfo.Video.Height, height);
            Assert.AreEqual(messageInfo.Video.Duration, duration);
            Assert.AreEqual(messageInfo.Video.MimeType, mimeType);
            Assert.AreEqual(messageInfo.Video.FileSize, fileSize);

            //test MessageInfo.Video.Thumb
            Assert.AreEqual(messageInfo.Video.Thumb.FileId, fileId);
            Assert.AreEqual(messageInfo.Video.Thumb.Width, width);
            Assert.AreEqual(messageInfo.Video.Thumb.Height, height);
            Assert.AreEqual(messageInfo.Video.Thumb.FileSize, fileSize);

            Console.WriteLine(MessageInfoVideo);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Caption"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoCaptionTest()
        {
            //check MessageInfo without field [caption]
            dynamic MessageInfoCaption = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MessageInfoCaption);
            Assert.AreEqual(messageInfo.Caption, string.Empty);

            //check MessageInfo with field [caption: TestCaption] 
            MessageInfoCaption.caption = "TestCaption";
            messageInfo = new MessageInfo(MessageInfoCaption);
            Assert.AreEqual(messageInfo.Caption, "TestCaption");

            Console.WriteLine(MessageInfoCaption);
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

            dynamic MessageInfoContact = mMandatoryFieldsMessageInfo;

            MessageInfoContact.contact = ContactInfoObject.GetObject(phoneNumber, firstName, lastName,
                userId);

            MessageInfo messageInfo = new MessageInfo(MessageInfoContact);

            //test MessageInfo.Contact
            Assert.AreEqual(messageInfo.Contact.PhoneNumber, phoneNumber);
            Assert.AreEqual(messageInfo.Contact.FirstName, firstName);
            Assert.AreEqual(messageInfo.Contact.LastName, lastName);
            Assert.AreEqual(messageInfo.Contact.UserId, userId);

            Console.WriteLine(MessageInfoContact);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.Location"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoLocationTest()
        {
            const float longitude = 1000;
            const float latitude = 1000;

            dynamic MessageInfoLocation = mMandatoryFieldsMessageInfo;

            MessageInfoLocation.location = LocationInfoObject.GetObject(longitude, latitude);

            MessageInfo messageInfo = new MessageInfo(MessageInfoLocation);

            Assert.AreEqual(messageInfo.Location.Latitude, latitude);
            Assert.AreEqual(messageInfo.Location.Longitude, longitude);
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

            dynamic MessageInfoUser = mMandatoryFieldsMessageInfo;

            MessageInfoUser.new_chat_member = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(MessageInfoUser);

            Assert.AreEqual(messageInfo.NewChatMember.Id, id);
            Assert.AreEqual(messageInfo.NewChatMember.FirstName, firstName);
            Assert.AreEqual(messageInfo.NewChatMember.LastName, lastName);
            Assert.AreEqual(messageInfo.NewChatMember.UserName, username);
            Assert.AreEqual(messageInfo.NewChatMember.LanguageCode, languageCode);
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

            dynamic MessageInfoUser = mMandatoryFieldsMessageInfo;

            MessageInfoUser.left_chat_member = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(MessageInfoUser);

            Assert.AreEqual(messageInfo.LeftChatMember.Id, id);
            Assert.AreEqual(messageInfo.LeftChatMember.FirstName, firstName);
            Assert.AreEqual(messageInfo.LeftChatMember.LastName, lastName);
            Assert.AreEqual(messageInfo.LeftChatMember.UserName, username);
            Assert.AreEqual(messageInfo.LeftChatMember.LanguageCode, languageCode);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatTitle"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatTitleTest()
        {
            //check MessageInfo without field [new_chat_title]
            dynamic MessageInfoNewChatTitle = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MessageInfoNewChatTitle);
            Assert.AreEqual(messageInfo.NewChatTitle, string.Empty);

            //check MessageInfo with field [new_chat_title: TestTitle] 
            MessageInfoNewChatTitle.new_chat_title = "TestTitle";
            messageInfo = new MessageInfo(MessageInfoNewChatTitle);
            Assert.AreEqual(messageInfo.NewChatTitle, "TestTitle");

            Console.WriteLine(MessageInfoNewChatTitle);
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

            dynamic MessageInfoNewChatPhoto = mMandatoryFieldsMessageInfo;

            JArray photoArray = new JArray(PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize));

            MessageInfoNewChatPhoto.new_chat_photo = photoArray;

            MessageInfo messageInfo = new MessageInfo(MessageInfoNewChatPhoto);

            //test MessageInfo.NewChatPhoto
            Assert.AreEqual(messageInfo.NewChatPhoto[0].FileId, fileId);
            Assert.AreEqual(messageInfo.NewChatPhoto[0].Width, width);
            Assert.AreEqual(messageInfo.NewChatPhoto[0].Height, height);
            Assert.AreEqual(messageInfo.NewChatPhoto[0].FileSize, fileSize);

            Console.WriteLine(MessageInfoNewChatPhoto);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.DeleteChatPhoto"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoDeleteChatPhotoTest()
        {
            //check MessageInfo without field [delete_chat_photo]
            dynamic DeleteChatPhoto = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(DeleteChatPhoto);
            Assert.False(messageInfo.DeleteChatPhoto);

            //check MessageInfo with field [delete_chat_photo: true] 
            DeleteChatPhoto.delete_chat_photo = true;
            messageInfo = new MessageInfo(DeleteChatPhoto);
            Assert.True(messageInfo.DeleteChatPhoto);

            Console.WriteLine(DeleteChatPhoto);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.GroupChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoGroupChatCreatedTest()
        {
            //check MessageInfo without field [group_chat_created]
            dynamic GroupChatCreated = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(GroupChatCreated);
            Assert.False(messageInfo.GroupChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            GroupChatCreated.group_chat_created = true;
            messageInfo = new MessageInfo(GroupChatCreated);
            Assert.True(messageInfo.GroupChatCreated);

            Console.WriteLine(GroupChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.SuperGroupChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoSuperGroupChatCreatedTest()
        {
            //check MessageInfo without field [supergroup_chat_created]
            dynamic SuperGroupChatCreated = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(SuperGroupChatCreated);
            Assert.False(messageInfo.SuperGroupChatCreated);

            //check MessageInfo with field [supergroup_chat_created: true] 
            SuperGroupChatCreated.supergroup_chat_created = true;
            messageInfo = new MessageInfo(SuperGroupChatCreated);
            Assert.True(messageInfo.SuperGroupChatCreated);

            Console.WriteLine(SuperGroupChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ChannelChatCreated"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoChannelChatCreatedTest()
        {
            //check MessageInfo without field [group_chat_created]
            dynamic ChannelChatCreated = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(ChannelChatCreated);
            Assert.False(messageInfo.ChannelChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            ChannelChatCreated.channel_chat_created = true;
            messageInfo = new MessageInfo(ChannelChatCreated);
            Assert.True(messageInfo.ChannelChatCreated);

            Console.WriteLine(ChannelChatCreated);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.MigrateToChatId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoMigrateToChatIdTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic MessageInfoMigrateToChatId = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MessageInfoMigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            MessageInfoMigrateToChatId.migrate_to_chat_id = 14881488;
            messageInfo = new MessageInfo(MessageInfoMigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 14881488);

            Console.WriteLine(MessageInfoMigrateToChatId);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.MigrateFromChatId"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoMigrateFromChatIdTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic MigrateFromChatId = mMandatoryFieldsMessageInfo;
            MessageInfo messageInfo = new MessageInfo(MigrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            MigrateFromChatId.migrate_from_chat_id = 14881488;
            messageInfo = new MessageInfo(MigrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 14881488);

            Console.WriteLine(MigrateFromChatId);
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
            //const string chatFirstName = "TestFirstName";

            dynamic MessageInfoPinnedMessage = mMandatoryFieldsMessageInfo;

            //MessageInfoPinnedMessage.pinned_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatFirstName);
            MessageInfoPinnedMessage.pinned_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, ChatType.@group);

            MessageInfo messageInfo = new MessageInfo(MessageInfoPinnedMessage);

            Assert.AreEqual(messageInfo.PinnedMessage.MessageId, messageId);
            Assert.AreEqual(messageInfo.PinnedMessage.DateUnix, date);
            Assert.AreEqual(messageInfo.PinnedMessage.Chat.Id, chatId);

            Console.WriteLine(MessageInfoPinnedMessage);
        }
    }
}
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
            const bool isBot = true;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.from = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.From.Id);
                Assert.AreEqual(isBot, messageInfo.From.IsBot);
                Assert.AreEqual(firstName, messageInfo.From.FirstName);
                Assert.AreEqual(lastName, messageInfo.From.LastName);
                Assert.AreEqual(username, messageInfo.From.UserName);
                Assert.AreEqual(languageCode, messageInfo.From.LanguageCode);
            });
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.ForwardFrom"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoForwardFromTest()
        {
            const int id = 1000;
            const bool isBot = true;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.forward_from = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.ForwardFrom.Id);
                Assert.AreEqual(isBot, messageInfo.ForwardFrom.IsBot);
                Assert.AreEqual(firstName, messageInfo.ForwardFrom.FirstName);
                Assert.AreEqual(lastName, messageInfo.ForwardFrom.LastName);
                Assert.AreEqual(username, messageInfo.ForwardFrom.UserName);
                Assert.AreEqual(languageCode, messageInfo.ForwardFrom.LanguageCode);
            });
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

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.ForwardFromChat.Id, id);
                Assert.AreEqual(ChatType.channel, messageInfo.ForwardFromChat.Type);
                Assert.AreEqual(title, messageInfo.ForwardFromChat.Title, title);
                Assert.AreEqual(username, messageInfo.ForwardFromChat.Username, username);
                Assert.AreEqual(firstName, messageInfo.ForwardFromChat.FirstName, firstName);
                Assert.AreEqual(lastName, messageInfo.ForwardFromChat.LastName, lastName);
                Assert.AreEqual(allMembersAreAdministrators, messageInfo.ForwardFromChat.AllMembersAreAdministrators);
                Assert.AreEqual("123456", messageInfo.ForwardFromChat.Photo.SmallFileId);
                Assert.AreEqual("654321", messageInfo.ForwardFromChat.Photo.BigFileId);
                Assert.AreEqual(description, messageInfo.ForwardFromChat.Description);
                Assert.AreEqual(inviteLink, messageInfo.ForwardFromChat.InviteLink);
            });

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
            Assert.AreEqual(0, messageInfo.ForwardFromMessageId);

            //check MessageInfo with field [forward_from_message_id: 14881488] 
            messageInfoForwardFromMessageId.forward_from_message_id = 14881488;
            messageInfo = new MessageInfo(messageInfoForwardFromMessageId);
            Assert.AreEqual(14881488, messageInfo.ForwardFromMessageId);

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
            Assert.AreEqual(0, messageInfo.ForwardDateUnix);
            Assert.AreEqual(DateTime.MinValue, messageInfo.ForwardDate);

            //check MessageInfo with field [forward_date: 0] 
            messageInfoForwardDateUnix.forward_date = 0;
            Assert.AreEqual(0, messageInfo.DateUnix);
            Assert.AreEqual(new DateTime(1970, 1, 1).ToLocalTime(), messageInfo.Date);

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

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.Chat.Id);
                Assert.IsInstanceOf<long>(messageInfo.Chat.Id);

                Assert.AreEqual(ChatType.channel, messageInfo.Chat.Type);
                Assert.AreEqual(title, messageInfo.Chat.Title, title);
                Assert.AreEqual(username, messageInfo.Chat.Username, username);
                Assert.AreEqual(firstName, messageInfo.Chat.FirstName, firstName);
                Assert.AreEqual(lastName, messageInfo.Chat.LastName, lastName);
                Assert.AreEqual(allMembersAreAdministrators, messageInfo.Chat.AllMembersAreAdministrators);
                Assert.AreEqual("123456", messageInfo.Chat.Photo.SmallFileId);
                Assert.AreEqual("654321", messageInfo.Chat.Photo.BigFileId);
                Assert.AreEqual(description, messageInfo.Chat.Description);
                Assert.AreEqual(inviteLink, messageInfo.Chat.InviteLink);
            });

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
            Assert.AreEqual(ChatType.@private, messageInfo.Chat.Type);

            //channel
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "channel");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.AreEqual(ChatType.channel, messageInfo.Chat.Type);

            //group
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "group");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.AreEqual(ChatType.@group, messageInfo.Chat.Type);

            //supergroup
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "supergroup");
            messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(messageInfo.Chat.Id, id);
            Assert.AreEqual(ChatType.supergroup, messageInfo.Chat.Type);

            //null
            mandatoryMessageInfoFields.chat = ChatInfoObject.GetObject(id, "grou");
            MessageInfo messageInfo2 = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(id, messageInfo2.Chat.Id);
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

            dynamic messageInfoReplyToMessage = mMandatoryFieldsMessageInfo;

            messageInfoReplyToMessage.reply_to_message = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, ChatType.channel);

            MessageInfo messageInfo = new MessageInfo(messageInfoReplyToMessage);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(messageId, messageInfo.ReplyToMessage.MessageId);
                Assert.AreEqual(date, messageInfo.ReplyToMessage.DateUnix);
                Assert.AreEqual(chatId, messageInfo.ReplyToMessage.Chat.Id);
            });

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
            const bool isBot = true;
            const string firstName = "name";
            const string lastName = "lastName";
            const string username = "username";
            const string languageCode = "code";

            JObject user = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            dynamic messageInfoEntities = mMandatoryFieldsMessageInfo;

            messageInfoEntities.entities = new JArray(MessageEntityInfoObject.GetObject(type, offset, length, url, user));

            MessageInfo messageInfo = new MessageInfo(messageInfoEntities);


            Assert.Multiple(() =>
            {
                //test MessageInfo.Entities
                Assert.AreEqual(type, messageInfo.Entities[0].Type);
                Assert.AreEqual(offset, messageInfo.Entities[0].Offset);
                Assert.AreEqual(length, messageInfo.Entities[0].Length);
                Assert.AreEqual(url, messageInfo.Entities[0].Url);

                //test MessageInfo.Entities.User
                Assert.AreEqual(id, messageInfo.Entities[0].User.Id);
                Assert.AreEqual(isBot, messageInfo.Entities[0].User.IsBot);
                Assert.AreEqual(firstName, messageInfo.Entities[0].User.FirstName);
                Assert.AreEqual(lastName, messageInfo.Entities[0].User.LastName);
                Assert.AreEqual(username, messageInfo.Entities[0].User.UserName);
                Assert.AreEqual(languageCode, messageInfo.Entities[0].User.LanguageCode);
            });

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

            Assert.AreEqual(0, messageInfo.EditDateUnix);
            Assert.AreEqual(DateTime.MinValue, messageInfo.EditDate);

            //check MessageInfo with field [edit_date: 0] 
            messageInfoEditDate.edit_date = 0;
            messageInfo = new MessageInfo(messageInfoEditDate);


            Assert.AreEqual(0, messageInfo.EditDateUnix);
            Assert.AreEqual(new DateTime(1970, 1, 1).ToLocalTime(), messageInfo.EditDate);


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
            Assert.AreEqual(string.Empty, messageInfo.Text);

            //check MessageInfo with field [text: TestText] 
            messageInfoText.text = "TestText";
            messageInfo = new MessageInfo(messageInfoText);
            Assert.AreEqual("TestText", messageInfo.Text);

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

            Assert.Multiple(() =>
            {
                //test MessageInfo.Document
                Assert.AreEqual(fileId, messageInfo.Document.FileId);
                Assert.AreEqual(fileName, messageInfo.Document.FileName);
                Assert.AreEqual(mimeType, messageInfo.Document.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Document.FileSize);

                //test MessageInfo.Document.Thumb
                Assert.AreEqual(fileId, messageInfo.Document.Thumb.FileId);
                Assert.AreEqual(width, messageInfo.Document.Thumb.Width);
                Assert.AreEqual(height, messageInfo.Document.Thumb.Height);
                Assert.AreEqual(fileSize, messageInfo.Document.Thumb.FileSize);
            });


            Console.WriteLine(messageInfoDocument);
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
            const int width = 100;
            const int height = 100;
            JObject animation = AnimationInfoObject.GetObject(fileId,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), fileName, mimeType, fileSize);

            //UserInfo field
            const int id = 123456;
            const bool isBot = true;
            const string firstName = "TestFirstName";
            const string lastName = "TestLastName";
            const string username = "TestUsername";
            const string languageCode = "TestLanguageCode";
            JObject user = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);
            
            //MessageEntityInfo field
            const string type = "TestType";
            const int offset = 123456;
            const int length = 123456;
            const string url = "TestUrl";
            JArray entities = new JArray(MessageEntityInfoObject.GetObject(type, offset, length, url, user));

            JArray photo = new JArray(PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize));

            dynamic messageInfoGame = mMandatoryFieldsMessageInfo;

            messageInfoGame.game = GameInfoObject.GetObject(title, description, photo, text, entities, animation);

            MessageInfo messageInfo = new MessageInfo(messageInfoGame);

            Assert.Multiple(() =>
            {
                //Game
                Assert.AreEqual(title, messageInfo.Game.Title);
                Assert.AreEqual(description, messageInfo.Game.Description);
                Assert.AreEqual(text, messageInfo.Game.Text);

                //Game.Photo
                Assert.AreEqual(fileId, messageInfo.Game.Photo[0].FileId);
                Assert.AreEqual(width, messageInfo.Game.Photo[0].Width);
                Assert.AreEqual(height, messageInfo.Game.Photo[0].Height);
                Assert.AreEqual(fileSize, messageInfo.Game.Photo[0].FileSize);

                //Game.Entities
                Assert.AreEqual(type, messageInfo.Game.Entities[0].Type);
                Assert.AreEqual(offset, messageInfo.Game.Entities[0].Offset);
                Assert.AreEqual(length, messageInfo.Game.Entities[0].Length);
                Assert.AreEqual(url, messageInfo.Game.Entities[0].Url);

                //Game.Entites.User
                Assert.AreEqual(id, messageInfo.Game.Entities[0].User.Id);
                Assert.AreEqual(isBot, messageInfo.Game.Entities[0].User.IsBot);
                Assert.AreEqual(firstName, messageInfo.Game.Entities[0].User.FirstName);
                Assert.AreEqual(lastName, messageInfo.Game.Entities[0].User.LastName);
                Assert.AreEqual(username, messageInfo.Game.Entities[0].User.UserName);
                Assert.AreEqual(languageCode, messageInfo.Game.Entities[0].User.LanguageCode);

                //Game.Animation
                Assert.AreEqual(fileId, messageInfo.Game.Animation.FileId);
                Assert.AreEqual(fileName, messageInfo.Game.Animation.FileName);
                Assert.AreEqual(mimeType, messageInfo.Game.Animation.MimeType);
                Assert.AreEqual(fileSize, messageInfo.Game.Animation.FileSize);

                //Game.Animation.Thumb
                Assert.AreEqual(fileId, messageInfo.Game.Animation.Thumb.FileId);
                Assert.AreEqual(height, messageInfo.Game.Animation.Thumb.Height);
                Assert.AreEqual(width, messageInfo.Game.Animation.Thumb.Width);
                Assert.AreEqual(fileSize, messageInfo.Game.Animation.Thumb.FileSize);

            });


            Console.WriteLine(messageInfoGame);
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

            Assert.Multiple(() =>
            {
                Assert.AreEqual(fileId, messageInfo.Photo[0].FileId);
                Assert.AreEqual(width, messageInfo.Photo[0].Width);
                Assert.AreEqual(height, messageInfo.Photo[0].Height);
                Assert.AreEqual(fileSize, messageInfo.Photo[0].FileSize);
            });


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
        /// Test for <see cref="MessageInfo.VideoNote"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoVideoNoteTest()
        {
            const string fileId = "100";
            const int length = 123;
            const int duration = 100;
            const int width = 1000;
            const int height = 10000;
            const int fileSize = 10;

            dynamic messageInfoVoice = mMandatoryFieldsMessageInfo;

            messageInfoVoice.video_note  = VideoNoteInfoObject.GetObject(
                fileId, length, duration,
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), 
                fileSize);

            MessageInfo messageInfo = new MessageInfo(messageInfoVoice);

            Assert.Multiple(() =>
            {
                //test MessageInfo.VideoNote
                Assert.AreEqual(fileId, messageInfo.VideoNote.FileId);
                Assert.AreEqual(length, messageInfo.VideoNote.Length);
                Assert.AreEqual(duration, messageInfo.VideoNote.Duration);
                Assert.AreEqual(fileSize, messageInfo.VideoNote.FileSize);

                //test MessageInfo.VideoNote.Thumb
                Assert.AreEqual(fileId, messageInfo.VideoNote.Thumb.FileId);
                Assert.AreEqual(width, messageInfo.VideoNote.Thumb.Width);
                Assert.AreEqual(height, messageInfo.VideoNote.Thumb.Height);
                Assert.AreEqual(fileSize, messageInfo.VideoNote.Thumb.FileSize);
            });

            Console.WriteLine(messageInfoVoice);
        }

        /// <summary>
        /// Test for <see cref="MessageInfo.NewChatMembers"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoNewChatMembersTest()
        {
            const int id = 1000;
            const bool isBot = true;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            JArray membersArray = new JArray(UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode));

            messageInfoUser.new_chat_members = membersArray;

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.NewChatMembers[0].Id);
                Assert.AreEqual(isBot, messageInfo.NewChatMembers[0].IsBot);
                Assert.AreEqual(firstName, messageInfo.NewChatMembers[0].FirstName);
                Assert.AreEqual(lastName, messageInfo.NewChatMembers[0].LastName);
                Assert.AreEqual(messageInfo.NewChatMembers[0].UserName, username);
                Assert.AreEqual(messageInfo.NewChatMembers[0].LanguageCode, languageCode);
            });

            Console.WriteLine(messageInfoUser);
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
            Assert.AreEqual(string.Empty, messageInfo.Caption);

            //check MessageInfo with field [caption: TestCaption] 
            messageInfoCaption.caption = "TestCaption";
            messageInfo = new MessageInfo(messageInfoCaption);

            Assert.AreEqual("TestCaption", messageInfo.Caption);

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
            const bool isBot = true;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.new_chat_member = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.NewChatMember.Id);
                Assert.AreEqual(isBot, messageInfo.NewChatMember.IsBot);
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
            const bool isBot = true;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic messageInfoUser = mMandatoryFieldsMessageInfo;

            messageInfoUser.left_chat_member = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            MessageInfo messageInfo = new MessageInfo(messageInfoUser);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(id, messageInfo.LeftChatMember.Id);
                Assert.AreEqual(isBot, messageInfo.LeftChatMember.IsBot);
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
            Assert.AreEqual(string.Empty, messageInfo.NewChatTitle);

            //check MessageInfo with field [new_chat_title: TestTitle] 
            messageInfoNewChatTitle.new_chat_title = "TestTitle";
            messageInfo = new MessageInfo(messageInfoNewChatTitle);
            Assert.AreEqual("TestTitle", messageInfo.NewChatTitle);

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
            Assert.AreEqual(0, messageInfo.MigrateToChatId);

            //check MessageInfo with field [group_chat_created: true] 
            messageInfoMigrateToChatId.migrate_to_chat_id = 14881488;
            messageInfo = new MessageInfo(messageInfoMigrateToChatId);
            Assert.AreEqual(14881488, messageInfo.MigrateToChatId);

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
            Assert.AreEqual(0, messageInfo.MigrateFromChatId);

            //check MessageInfo with field [group_chat_created: true] 
            migrateFromChatId.migrate_from_chat_id = 14881488;
            messageInfo = new MessageInfo(migrateFromChatId);
            Assert.AreEqual(14881488, messageInfo.MigrateFromChatId);

            Console.WriteLine(migrateFromChatId);
        }
        
        [Test, Obsolete]
        public static void MandatoryFieldsMessageInfoTest()
        {
            dynamic mandatoryMessageInfoFields = mMandatoryFieldsMessageInfo;

            MessageInfo messageInfo = new MessageInfo(mandatoryMessageInfoFields);

            Assert.AreEqual(-1147483648, messageInfo.MessageId);
            Assert.AreEqual(0, messageInfo.DateUnix);
            Assert.AreEqual(new DateTime(1970, 1, 1).ToLocalTime(), messageInfo.Date);
            Assert.AreEqual(1049413668, messageInfo.Chat.Id);
            

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

            Assert.Multiple(() =>
            {
                Assert.AreEqual(messageId, messageInfo.PinnedMessage.MessageId);
                Assert.AreEqual(date, messageInfo.PinnedMessage.DateUnix);
                Assert.AreEqual(chatId, messageInfo.PinnedMessage.Chat.Id);
            });

            Console.WriteLine(messageInfoPinnedMessage);
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

            dynamic messageInfoInvoice = mMandatoryFieldsMessageInfo;

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

            Console.WriteLine(messageInfoInvoice);
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

            dynamic messageSuccessfulPayment = mMandatoryFieldsMessageInfo;

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

            Console.WriteLine(messageSuccessfulPayment);
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

using System;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;

namespace NetTelebot.Tests.NullReferenceExceptionTest
{
    /// <summary>
    /// Checking for NullReferenceException when accessing to null fields MessageInfo after use available methods TelegramBotClients.
    /// </summary>
    [TestFixture]
    internal class MessageInfoTest
    {
        private TelegramBotClient mTelegramBot;
        private long mChatId;

        /// <summary>
        /// Called when [test start].
        /// </summary>
        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetGroupChatBot();
            mChatId = new TelegramBot().GetGroupChatId();
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardFrom"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyForwardFrom()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyForwardFrom()");

            UserInfo forwardFrom = sendMessage.Result.ForwardFrom;

            var id = sendMessage.Result.ForwardFrom.Id;
            var firstName = sendMessage.Result.ForwardFrom.FirstName;
            var lastName = sendMessage.Result.ForwardFrom.LastName;
            var userName = sendMessage.Result.ForwardFrom.UserName;
            var languageCode = sendMessage.Result.ForwardFrom.LanguageCode;

            ConsoleUtlis.PrintResult(forwardFrom);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (UserInfo), forwardFrom);
                Assert.AreEqual(id, 0);
                Assert.IsNull(firstName);
                Assert.IsNull(lastName);
                Assert.IsNull(userName);
                Assert.IsNull(languageCode);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardFromChat"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyForwardFromChat()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyForwardFrom()");

            ChatInfo forwardFromChat = sendMessage.Result.ForwardFromChat;

            var id = sendMessage.Result.ForwardFromChat.Id;
            var type = sendMessage.Result.ForwardFromChat.Type;
            var title = sendMessage.Result.ForwardFromChat.Title;
            var userName = sendMessage.Result.ForwardFromChat.Username;
            var firstName = sendMessage.Result.ForwardFromChat.FirstName;
            var lastName = sendMessage.Result.ForwardFromChat.LastName;
            var allMembersAreAdministrators = sendMessage.Result.ForwardFromChat.AllMembersAreAdministrators;
            var description = sendMessage.Result.ForwardFromChat.Description;
            var inviteLink = sendMessage.Result.ForwardFromChat.InviteLink;

            var photoBigFlleId = sendMessage.Result.ForwardFromChat.Photo.BigFileId;
            var photoSmallFileId = sendMessage.Result.ForwardFromChat.Photo.SmallFileId;

            ConsoleUtlis.PrintResult(forwardFromChat);
            ConsoleUtlis.PrintResult(forwardFromChat.Photo);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (ChatInfo), forwardFromChat);
                Assert.AreEqual(id, 0);
                Assert.IsNull(type);
                Assert.IsNull(title);
                Assert.IsNull(userName);
                Assert.IsNull(firstName);
                Assert.IsNull(lastName);
                Assert.IsFalse(allMembersAreAdministrators);
                Assert.IsNull(photoBigFlleId);
                Assert.IsNull(photoSmallFileId);
                Assert.IsNull(description);
                Assert.IsNull(inviteLink);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardDate"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromForwardDate()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromForwardDate()");
            
            DateTime forwardDate = sendMessage.Result.ForwardDate;

            var forwardDateYear = sendMessage.Result.ForwardDate.Year;
            var forwardDateMonth = sendMessage.Result.ForwardDate.Month;
            var forwardDateDay = sendMessage.Result.ForwardDate.Day;

            ConsoleUtlis.PrintResult(forwardDate);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (DateTime), forwardDate);
                Assert.AreEqual(forwardDate, DateTime.MinValue);
                Assert.AreEqual(forwardDateYear, 0001);
                Assert.AreEqual(forwardDateMonth, 01);
                Assert.AreEqual(forwardDateDay, 01);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ReplyToMessage"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromReplyToMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromReplyToMessage()");

            // typeof MessageInfo.ReplyToMessage
            MessageInfo replyMessage = sendMessage.Result.ReplyToMessage;
            
            // field MessageInfo.PinnedMessage.field
            var messageId = sendMessage.Result.ReplyToMessage.MessageId;

            UserInfo from = sendMessage.Result.ReplyToMessage.From;
            var fromId = sendMessage.Result.ReplyToMessage.From.Id;

            DateTime date = sendMessage.Result.ReplyToMessage.Date;
            var dateDay = sendMessage.Result.ReplyToMessage.Date.Day;

            ChatInfo chat = sendMessage.Result.ReplyToMessage.Chat;
            var chatId = sendMessage.Result.ReplyToMessage.Chat.Id;

            UserInfo forwardFrom = sendMessage.Result.ReplyToMessage.ForwardFrom;

            var forwardFromMessageId = sendMessage.Result.ReplyToMessage.ForwardFromMessageId;

            ChatInfo forwardFromChat = sendMessage.Result.ReplyToMessage.ForwardFromChat;
            var forwardFromChatId = sendMessage.Result.ReplyToMessage.ForwardFromChat.Id;

            DateTime forwardDate = sendMessage.Result.ReplyToMessage.ForwardDate;
            var forwardDateDay = sendMessage.Result.ReplyToMessage.ForwardDate.Day;

            MessageInfo replyToMessage = sendMessage.Result.ReplyToMessage.ReplyToMessage;
            var replyToMessageChatId = sendMessage.Result.ReplyToMessage.ReplyToMessage.Chat.Id;

            DateTime editDate = sendMessage.Result.ReplyToMessage.EditDate;
            var editDateDay = sendMessage.Result.ReplyToMessage.EditDate.Day;

            var text = sendMessage.Result.ReplyToMessage.Text;

            var messageEntityInfo = sendMessage.Result.ReplyToMessage.Entities;

            AudioInfo audio = sendMessage.Result.ReplyToMessage.Audio;
            var audioDuration = sendMessage.Result.ReplyToMessage.Audio.Duration;

            DocumentInfo document = sendMessage.Result.ReplyToMessage.Document;
            var documentFileId = sendMessage.Result.ReplyToMessage.Document.FileId;

            //todo game

            var photo = sendMessage.Result.ReplyToMessage.Photo;

            StickerInfo sticker = sendMessage.Result.ReplyToMessage.Sticker;
            var stickerFileId = sendMessage.Result.ReplyToMessage.Sticker.FileId;

            VideoInfo video = sendMessage.Result.ReplyToMessage.Video;
            var videoFileid = sendMessage.Result.ReplyToMessage.Video.FileId;

            //todo Voice
            //todo VideoNote
            //todo NewChatMembers;

            var caption = sendMessage.Result.ReplyToMessage.Caption;

            ContactInfo contact = sendMessage.Result.ReplyToMessage.Contact;
            var contactUserId = sendMessage.Result.ReplyToMessage.Contact.UserId;

            LocationInfo location = sendMessage.Result.ReplyToMessage.Location;
            var locationLatitude = sendMessage.Result.ReplyToMessage.Location.Latitude;

            //todo Venue

            UserInfo newChatMember = sendMessage.Result.ReplyToMessage.NewChatMember;
            var newChatMemberId = sendMessage.Result.ReplyToMessage.NewChatMember.Id;

            UserInfo leftChatMember = sendMessage.Result.ReplyToMessage.LeftChatMember;
            var leftChatMemberId = sendMessage.Result.ReplyToMessage.LeftChatMember.Id;

            var newChatTitle = sendMessage.Result.ReplyToMessage.NewChatTitle;
            var newChatPhoto = sendMessage.Result.ReplyToMessage.NewChatPhoto;
            var deleteChatPhoto = sendMessage.Result.ReplyToMessage.DeleteChatPhoto;
            var groupChatCreated = sendMessage.Result.ReplyToMessage.GroupChatCreated;
            var superGroupChatCreated = sendMessage.Result.ReplyToMessage.SuperGroupChatCreated;
            var channelChatCreated = sendMessage.Result.ReplyToMessage.ChannelChatCreated;
            var migrateToChatId = sendMessage.Result.ReplyToMessage.MigrateToChatId;
            var migrateFromChatId = sendMessage.Result.ReplyToMessage.MigrateFromChatId;

            MessageInfo pinnedMessage = sendMessage.Result.ReplyToMessage.PinnedMessage;
            var pinnedMessageChatId = sendMessage.Result.ReplyToMessage.PinnedMessage.Chat.Id;

            //todo Invoice
            //todo SuceffulPayment

            ConsoleUtlis.PrintResult(replyMessage);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (MessageInfo), replyMessage);

                Assert.AreEqual(messageId, 0);

                Assert.IsInstanceOf<UserInfo>(from);
                Assert.AreEqual(fromId, 0);

                Assert.AreEqual(date, DateTime.MinValue);
                Assert.AreEqual(dateDay, DateTime.MinValue.Day);

                Assert.IsInstanceOf<ChatInfo>(chat);
                Assert.AreEqual(chatId, 0);

                Assert.IsInstanceOf<UserInfo>(forwardFrom);

                Assert.AreEqual(forwardFromMessageId, 0);

                Assert.IsInstanceOf<ChatInfo>(forwardFromChat);
                Assert.AreEqual(forwardFromChatId, 0);

                Assert.AreEqual(forwardDate, DateTime.MinValue);
                Assert.AreEqual(forwardDateDay, DateTime.MinValue.Day);

                Assert.IsInstanceOf<MessageInfo>(replyToMessage);
                Assert.AreEqual(replyToMessageChatId, 0);

                Assert.AreEqual(editDate, DateTime.MinValue);
                Assert.AreEqual(editDateDay, DateTime.MinValue.Day);

                Assert.IsNull(text);

                Assert.IsInstanceOf<MessageEntityInfo[]>(messageEntityInfo);

                Assert.IsInstanceOf<AudioInfo>(audio);
                Assert.AreEqual(audioDuration, 0);

                Assert.IsInstanceOf<DocumentInfo>(document);
                Assert.IsNull(documentFileId);

                Assert.IsEmpty(photo);

                Assert.IsInstanceOf<StickerInfo>(sticker);
                Assert.IsNull(stickerFileId);

                Assert.IsInstanceOf<VideoInfo>(video);
                Assert.IsNull(videoFileid);

                Assert.IsNull(caption);

                Assert.IsInstanceOf<ContactInfo>(contact);
                Assert.IsNull(contactUserId);

                Assert.IsInstanceOf<LocationInfo>(location);
                Assert.AreEqual(locationLatitude, 0);

                Assert.IsInstanceOf<UserInfo>(newChatMember);
                Assert.AreEqual(newChatMemberId, 0);

                Assert.IsInstanceOf<UserInfo>(leftChatMember);
                Assert.AreEqual(leftChatMemberId, 0);

                Assert.IsInstanceOf<UserInfo>(leftChatMember);
                Assert.AreEqual(leftChatMemberId, 0);

                Assert.IsNull(newChatTitle);
                Assert.IsEmpty(newChatPhoto);
                Assert.IsFalse(deleteChatPhoto);
                Assert.IsFalse(groupChatCreated);
                Assert.IsFalse(superGroupChatCreated);
                Assert.IsFalse(channelChatCreated);
                Assert.AreEqual(migrateToChatId, 0);
                Assert.AreEqual(migrateFromChatId, 0);

                Assert.IsInstanceOf<MessageInfo>(pinnedMessage);
                Assert.AreEqual(pinnedMessageChatId, 0);
            });
        }



        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.EditDate"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromEditDate()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromEditDate()");

            DateTime editDate = sendMessage.Result.EditDate;

            var editDateYear = sendMessage.Result.EditDate.Year;
            var editDateMonth = sendMessage.Result.EditDate.Month;
            var editDateDay = sendMessage.Result.EditDate.Day;

            ConsoleUtlis.PrintResult(editDate);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (DateTime), editDate);
                Assert.AreEqual(editDate, DateTime.MinValue);
                Assert.AreEqual(editDateYear, 0001);
                Assert.AreEqual(editDateMonth, 01);
                Assert.AreEqual(editDateDay, 01);
            });
        }

        
        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Entities"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyEntities()
        {
            //todo remade this
            const float latitude = 37.0000114f;
            const float longitude = 37.0000076f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatId, latitude, longitude);

            // typeof MessageInfo.Entities
            var entities = sendLocation.Result.Entities;
            var entitesLength = sendLocation.Result.Entities.Length;

            Console.WriteLine("TestAppealToTheEmptyEntities():"
                              + "\n sendLocation.Result.Entities: " + entities
                              + "\n sendLocation.Result.Entities.Length: " + entitesLength);

            //check instance MessageInfo.Entities
            Assert.IsInstanceOf(typeof(MessageEntityInfo[]), entities);

            //check value MessageInfo.Entities
            Assert.IsEmpty(entities);
            Assert.AreEqual(entitesLength, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Audio"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyAudio()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyAudio()");

            AudioInfo audio = sendMessage.Result.Audio;

            var fileId = sendMessage.Result.Audio.FileId;
            var duration = sendMessage.Result.Audio.Duration;
            var performer = sendMessage.Result.Audio.Performer;
            var title = sendMessage.Result.Audio.Title;
            var mimeType = sendMessage.Result.Audio.MimeType;
            var fileSize = sendMessage.Result.Audio.FileSize;

            ConsoleUtlis.PrintResult(audio);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (AudioInfo), audio);
                Assert.IsNull(fileId);
                Assert.AreEqual(duration, 0);
                Assert.IsNull(performer);
                Assert.IsNull(title);
                Assert.IsNull(mimeType);
                Assert.AreEqual(fileSize, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Document"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyDocument()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyDocument()");

            DocumentInfo document = sendMessage.Result.Document;
            var fileId = sendMessage.Result.Document.FileId;
            var fileName = sendMessage.Result.Document.FileName;
            var mimeType = sendMessage.Result.Document.MimeType;
            var fileSize = sendMessage.Result.Document.FileSize;

            PhotoSizeInfo thumb = sendMessage.Result.Document.Thumb;
            var thumbWidth = sendMessage.Result.Document.Thumb.Width;
            var thumbHeight = sendMessage.Result.Document.Thumb.Height;
            var thumbFileId = sendMessage.Result.Document.Thumb.FileId;
            var thumbFileSize = sendMessage.Result.Document.Thumb.FileSize;

            ConsoleUtlis.PrintResult(document);
            ConsoleUtlis.PrintResult(thumb);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (DocumentInfo), document);
                Assert.IsNull(fileId);
                Assert.IsNull(fileName);
                Assert.IsNull(mimeType);
                Assert.AreEqual(fileSize, 0);

                Assert.IsInstanceOf(typeof (PhotoSizeInfo), thumb);
                Assert.AreEqual(thumbWidth, 0);
                Assert.AreEqual(thumbHeight, 0);
                Assert.IsNull(thumbFileId);
                Assert.AreEqual(thumbFileSize, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Photo"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyPhoto()
        {
            //todo remade this
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyPhoto()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.Photo
            var photo = sendMessage.Result.Photo;
            var photoLength = sendMessage.Result.Photo.Length;

            Console.WriteLine("TestAppealToTheEmptyPhoto():"
                              + "\n sendMessage.Result.Photo: " + photo
                              + "\n sendMessage.Result.photoLength: " + photoLength);

            //check instance MessageInfo.Photo
            Assert.IsInstanceOf(typeof(PhotoSizeInfo[]), photo);

            //сhecks the return value
            Assert.AreEqual(photoLength, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Sticker"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptySticker()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptySticker()");
            
            StickerInfo sticker = sendMessage.Result.Sticker;

            var fileId = sendMessage.Result.Sticker.FileId;
            var width = sendMessage.Result.Sticker.Width;
            var height = sendMessage.Result.Sticker.Height;
            var emoji = sendMessage.Result.Sticker.Emoji;
            var fileSize = sendMessage.Result.Sticker.FileSize;

            var thumb = sendMessage.Result.Sticker.Thumb;
            var thumbWidth = sendMessage.Result.Sticker.Thumb.Width;
            var thumbHeight = sendMessage.Result.Sticker.Thumb.Height;
            var thumbFileId = sendMessage.Result.Sticker.Thumb.FileId;
            var thumbFileSize = sendMessage.Result.Sticker.Thumb.FileSize;

            ConsoleUtlis.PrintResult(sticker);
            ConsoleUtlis.PrintResult(thumb);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
            
                Assert.IsInstanceOf(typeof (StickerInfo), sticker);
                Assert.IsNull(fileId);
                Assert.AreEqual(width, 0);
                Assert.AreEqual(height, 0);
                Assert.IsNull(emoji);
                Assert.AreEqual(fileSize, 0);
                
                Assert.IsInstanceOf(typeof (PhotoSizeInfo), thumb);
                Assert.AreEqual(thumbWidth, 0);
                Assert.AreEqual(thumbHeight, 0);
                Assert.IsNull(thumbFileId);
                Assert.AreEqual(thumbFileSize, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Video"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyVideo()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyVideo()");
            
            VideoInfo video = sendMessage.Result.Video;
            var fileId = sendMessage.Result.Video.FileId;
            var duration = sendMessage.Result.Video.Duration;
            var fileSize = sendMessage.Result.Video.FileSize;
            var width = sendMessage.Result.Video.Width;
            var height = sendMessage.Result.Video.Height;
            var mimeType = sendMessage.Result.Video.MimeType;
            
            var thumb = sendMessage.Result.Video.Thumb;
            var thumbWidth = sendMessage.Result.Video.Thumb.Width;
            var thumbHeight = sendMessage.Result.Video.Thumb.Height;
            var thumbFileId = sendMessage.Result.Video.Thumb.FileId;
            var thumbFileSize = sendMessage.Result.Video.Thumb.FileSize;

            ConsoleUtlis.PrintResult(video);
            ConsoleUtlis.PrintResult(thumb);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (VideoInfo), video);
                Assert.IsNull(fileId);
                Assert.AreEqual(duration, 0);
                Assert.AreEqual(width, 0);
                Assert.AreEqual(height, 0);
                Assert.AreEqual(fileSize, 0);
                Assert.IsNull(mimeType);
                
                Assert.IsInstanceOf(typeof (PhotoSizeInfo), thumb);
                Assert.AreEqual(thumbWidth, 0);
                Assert.AreEqual(thumbHeight, 0);
                Assert.IsNull(thumbFileId);
                Assert.AreEqual(thumbFileSize, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Contact"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyContact()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyContact()");
            
            ContactInfo contact = sendMessage.Result.Contact;
            var userId = sendMessage.Result.Contact.UserId;
            var phoneNumber = sendMessage.Result.Contact.PhoneNumber;
            var firstName = sendMessage.Result.Contact.FirstName;
            var lastName = sendMessage.Result.Contact.LastName;
            
            ConsoleUtlis.PrintResult(contact);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (ContactInfo), contact);
                Assert.IsNull(userId);
                Assert.IsNull(phoneNumber);
                Assert.IsNull(firstName);
                Assert.IsNull(lastName);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Location"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyLocation()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyLocation()");
            
            LocationInfo location = sendMessage.Result.Location;
            var latitude = sendMessage.Result.Location.Latitude;
            var longitude = sendMessage.Result.Location.Longitude;
            
            ConsoleUtlis.PrintResult(location);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (LocationInfo), location);
                Assert.AreEqual(latitude, 0);
                Assert.AreEqual(longitude, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatMember"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatMember()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatMember()");
            
            UserInfo newChatMember = sendMessage.Result.NewChatMember;
            var id = sendMessage.Result.NewChatMember.Id;
            var firstName = sendMessage.Result.NewChatMember.FirstName;
            var lastName = sendMessage.Result.NewChatMember.LastName;
            var userName = sendMessage.Result.NewChatMember.UserName;
            var languageCode = sendMessage.Result.NewChatMember.LanguageCode;

            ConsoleUtlis.PrintResult(newChatMember);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                
                Assert.IsInstanceOf(typeof (UserInfo), newChatMember);
                Assert.AreEqual(id, 0);
                Assert.IsNull(firstName);
                Assert.IsNull(lastName);
                Assert.IsNull(userName);
                Assert.IsNull(languageCode);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.LeftChatMember"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyLeftChatMember()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyLeftChatMember()");
            
            UserInfo leftChatMember = sendMessage.Result.LeftChatMember;
            var id = sendMessage.Result.LeftChatMember.Id;
            var firstName = sendMessage.Result.LeftChatMember.FirstName;
            var lastName = sendMessage.Result.LeftChatMember.LastName;
            var userName = sendMessage.Result.LeftChatMember.UserName;
            var languageCode = sendMessage.Result.LeftChatMember.LanguageCode;

            ConsoleUtlis.PrintResult(leftChatMember);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (UserInfo), leftChatMember);
                Assert.AreEqual(id, 0);
                Assert.IsNull(firstName);
                Assert.IsNull(lastName);
                Assert.IsNull(userName);
                Assert.IsNull(languageCode);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.PinnedMessage"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromPinnedMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromPinnedMessage()");

            // typeof MessageInfo.PinnedMessage
            MessageInfo message = sendMessage.Result.PinnedMessage;

            // field MessageInfo.PinnedMessage.field
            var messageId = sendMessage.Result.PinnedMessage.MessageId;

            UserInfo from = sendMessage.Result.PinnedMessage.From;
            var fromId = sendMessage.Result.PinnedMessage.From.Id;

            DateTime date = sendMessage.Result.PinnedMessage.Date;
            var dateDay = sendMessage.Result.PinnedMessage.Date.Day;

            ChatInfo chat = sendMessage.Result.PinnedMessage.Chat;
            var chatId = sendMessage.Result.PinnedMessage.Chat.Id;

            UserInfo forwardFrom = sendMessage.Result.PinnedMessage.ForwardFrom;

            var forwardFromMessageId = sendMessage.Result.PinnedMessage.ForwardFromMessageId;

            ChatInfo forwardFromChat = sendMessage.Result.PinnedMessage.ForwardFromChat;
            var forwardFromChatId = sendMessage.Result.PinnedMessage.ForwardFromChat.Id;

            DateTime forwardDate = sendMessage.Result.PinnedMessage.ForwardDate;
            var forwardDateDay = sendMessage.Result.PinnedMessage.ForwardDate.Day;

            MessageInfo replyToMessage = sendMessage.Result.PinnedMessage.ReplyToMessage;
            var replyToMessageChatId = sendMessage.Result.PinnedMessage.ReplyToMessage.Chat.Id;

            DateTime editDate = sendMessage.Result.PinnedMessage.EditDate;
            var editDateDay = sendMessage.Result.PinnedMessage.EditDate.Day;

            var text = sendMessage.Result.PinnedMessage.Text;

            var messageEntityInfo = sendMessage.Result.PinnedMessage.Entities;
            
            AudioInfo audio = sendMessage.Result.PinnedMessage.Audio;
            var audioDuration = sendMessage.Result.PinnedMessage.Audio.Duration;

            DocumentInfo document = sendMessage.Result.PinnedMessage.Document;
            var documentFileId = sendMessage.Result.PinnedMessage.Document.FileId;

            //todo game

            var photo = sendMessage.Result.PinnedMessage.Photo;

            StickerInfo sticker = sendMessage.Result.PinnedMessage.Sticker;
            var stickerFileId = sendMessage.Result.PinnedMessage.Sticker.FileId;

            VideoInfo video = sendMessage.Result.PinnedMessage.Video;
            var videoFileid = sendMessage.Result.PinnedMessage.Video.FileId;

            //todo Voice
            //todo VideoNote
            //todo NewChatMembers;

            var caption = sendMessage.Result.PinnedMessage.Caption;

            ContactInfo contact = sendMessage.Result.PinnedMessage.Contact;
            var contactUserId = sendMessage.Result.PinnedMessage.Contact.UserId;

            LocationInfo location = sendMessage.Result.PinnedMessage.Location;
            var locationLatitude = sendMessage.Result.PinnedMessage.Location.Latitude;

            //todo Venue

            UserInfo newChatMember = sendMessage.Result.PinnedMessage.NewChatMember;
            var newChatMemberId = sendMessage.Result.PinnedMessage.NewChatMember.Id;

            UserInfo leftChatMember = sendMessage.Result.PinnedMessage.LeftChatMember;
            var leftChatMemberId = sendMessage.Result.PinnedMessage.LeftChatMember.Id;

            var newChatTitle = sendMessage.Result.PinnedMessage.NewChatTitle;
            var newChatPhoto = sendMessage.Result.PinnedMessage.NewChatPhoto;
            var deleteChatPhoto = sendMessage.Result.PinnedMessage.DeleteChatPhoto;
            var groupChatCreated = sendMessage.Result.PinnedMessage.GroupChatCreated;
            var superGroupChatCreated = sendMessage.Result.PinnedMessage.SuperGroupChatCreated;
            var channelChatCreated = sendMessage.Result.PinnedMessage.ChannelChatCreated;
            var migrateToChatId = sendMessage.Result.PinnedMessage.MigrateToChatId;
            var migrateFromChatId = sendMessage.Result.PinnedMessage.MigrateFromChatId;

            MessageInfo pinnedMessage = sendMessage.Result.PinnedMessage.PinnedMessage;
            var pinnedMessageChatId = sendMessage.Result.PinnedMessage.PinnedMessage.Chat.Id;

            //todo Invoice
            //todo SuceffulPayment

            ConsoleUtlis.PrintResult(message);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (MessageInfo), message);

                Assert.AreEqual(messageId, 0);

                Assert.IsInstanceOf<UserInfo>(from);
                Assert.AreEqual(fromId, 0);

                Assert.AreEqual(date, DateTime.MinValue);
                Assert.AreEqual(dateDay, DateTime.MinValue.Day);

                Assert.IsInstanceOf<ChatInfo>(chat);
                Assert.AreEqual(chatId, 0);

                Assert.IsInstanceOf<UserInfo>(forwardFrom);

                Assert.AreEqual(forwardFromMessageId, 0);

                Assert.IsInstanceOf<ChatInfo>(forwardFromChat);
                Assert.AreEqual(forwardFromChatId, 0);

                Assert.AreEqual(forwardDate, DateTime.MinValue);
                Assert.AreEqual(forwardDateDay, DateTime.MinValue.Day);

                Assert.IsInstanceOf<MessageInfo>(replyToMessage);
                Assert.AreEqual(replyToMessageChatId, 0);

                Assert.AreEqual(editDate, DateTime.MinValue);
                Assert.AreEqual(editDateDay, DateTime.MinValue.Day);

                Assert.IsNull(text);

                Assert.IsInstanceOf<MessageEntityInfo[]>(messageEntityInfo);

                Assert.IsInstanceOf<AudioInfo>(audio);
                Assert.AreEqual(audioDuration, 0);

                Assert.IsInstanceOf<DocumentInfo>(document);
                Assert.IsNull(documentFileId);

                Assert.IsEmpty(photo);

                Assert.IsInstanceOf<StickerInfo>(sticker);
                Assert.IsNull(stickerFileId);

                Assert.IsInstanceOf<VideoInfo>(video);
                Assert.IsNull(videoFileid);

                Assert.IsNull(caption);

                Assert.IsInstanceOf<ContactInfo>(contact);
                Assert.IsNull(contactUserId);

                Assert.IsInstanceOf<LocationInfo>(location);
                Assert.AreEqual(locationLatitude, 0);

                Assert.IsInstanceOf<UserInfo>(newChatMember);
                Assert.AreEqual(newChatMemberId, 0);

                Assert.IsInstanceOf<UserInfo>(leftChatMember);
                Assert.AreEqual(leftChatMemberId, 0);

                Assert.IsInstanceOf<UserInfo>(leftChatMember);
                Assert.AreEqual(leftChatMemberId, 0);

                Assert.IsNull(newChatTitle);
                Assert.IsEmpty(newChatPhoto);
                Assert.IsFalse(deleteChatPhoto);
                Assert.IsFalse(groupChatCreated);
                Assert.IsFalse(superGroupChatCreated);
                Assert.IsFalse(channelChatCreated);
                Assert.AreEqual(migrateToChatId, 0);
                Assert.AreEqual(migrateFromChatId, 0);

                Assert.IsInstanceOf<MessageInfo>(pinnedMessage);
                Assert.AreEqual(pinnedMessageChatId, 0);
            });
        }  
    }
}

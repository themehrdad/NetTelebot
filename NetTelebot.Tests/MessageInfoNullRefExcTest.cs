using System;
using NetTelebot.Tests.Utils;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    /// <summary>
    /// Checking for NullReferenceException when accessing to null fields MessageInfo after use available methods TelegramBotClients.
    /// </summary>
    [TestFixture]
    internal class MessageInfoNullRefExcTest
    {
        private TelegramBotClient mTelegramBot;
        private int mChatId;

        /// <summary>
        /// Called when [test start].
        /// </summary>
        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetBot();
            mChatId = new TelegramBot().GetChatId();
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardDateUnix"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromForwardDateUnix()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromForwardDateUnix()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.ForwardDate
            var forwardDateUnix = sendMessage.Result.ForwardDateUnix;
            var forwardDateString = sendMessage.Result.ForwardDateUnix.ToString();
            
            Console.WriteLine("TestAppealToMigrateFromForwardDateUnix():"
                              + "\n sendMessage.Result.ForwardDateUnix: " + forwardDateUnix
                              + "\n sendMessage.Result.ForwardDateUnix.ToString(): " + forwardDateString);

            //check instance MessageInfo.ForwardDate
            Assert.IsInstanceOf(typeof(int), forwardDateUnix);

            //check value MessageInfo.ForwardDate
            Assert.AreEqual(forwardDateUnix, 0);
            Assert.AreEqual(forwardDateString, "0");
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardDate"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromForwardDate()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromForwardDate()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.ForwardDate
            var forwardDate = sendMessage.Result.ForwardDate;

            var forwardDateYear = sendMessage.Result.ForwardDate.Year;
            var forwardDateMonth = sendMessage.Result.ForwardDate.Month;
            var forwardDateDay = sendMessage.Result.ForwardDate.Day;

            Console.WriteLine("TestAppealToMigrateFromForwardDate():"
                              + "\n sendMessage.Result.ForwardDate: " + forwardDate
                              + "\n sendMessage.Result.ForwardDate.Year: " + forwardDateYear
                              + "\n sendMessage.Result.ForwardDate.Month: " + forwardDateMonth
                              + "\n sendMessage.Result.ForwardDate.Day: " + forwardDateDay);

            //check instance MessageInfo.ForwardDate
            Assert.IsInstanceOf(typeof(DateTime), forwardDate);

            //check value MessageInfo.ForwardDate
            Assert.AreEqual(forwardDate, DateTime.MinValue);
            Assert.AreEqual(forwardDateYear, 0001);
            Assert.AreEqual(forwardDateMonth, 01);
            Assert.AreEqual(forwardDateDay, 01);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ReplyToMessage"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromReplyToMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromReplyToMessage()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.ReplyToMessage
            var message = sendMessage.Result.ReplyToMessage;

            // field MessageInfo.PinnedMessage.field
            var messageId = sendMessage.Result.ReplyToMessage.MessageId;
            var from = sendMessage.Result.ReplyToMessage.From;
            var date = sendMessage.Result.ReplyToMessage.Date;
            var chat = sendMessage.Result.ReplyToMessage.Chat;
            var forwardFrom = sendMessage.Result.ReplyToMessage.ForwardFrom;
            //todo forward_from_chat
            var forwardFromMessageId = sendMessage.Result.ReplyToMessage.ForwardFromMessageId;
            var forwardDate = sendMessage.Result.ReplyToMessage.ForwardDate;
            var replyToMessage = sendMessage.Result.ReplyToMessage.ReplyToMessage;
            var editDate = sendMessage.Result.ReplyToMessage.EditDate;
            var text = sendMessage.Result.ReplyToMessage.Text;
            //todo entities
            var audio = sendMessage.Result.ReplyToMessage.Audio;
            var document = sendMessage.Result.ReplyToMessage.Document;
            //todo game
            var photo = sendMessage.Result.ReplyToMessage.Photo;
            var sticker = sendMessage.Result.ReplyToMessage.Sticker;
            var video = sendMessage.Result.ReplyToMessage.Video;
            //todo Voice
            //todo VideoNote
            //todo NewChatMembers;
            var caption = sendMessage.Result.ReplyToMessage.Caption;
            var contact = sendMessage.Result.ReplyToMessage.Contact;
            var location = sendMessage.Result.ReplyToMessage.Location;
            //todo Venue
            var newChatMember = sendMessage.Result.ReplyToMessage.NewChatMember;
            var leftChatMember = sendMessage.Result.ReplyToMessage.LeftChatMember;
            var newChatTitle = sendMessage.Result.ReplyToMessage.NewChatTitle;
            var newChatPhoto = sendMessage.Result.ReplyToMessage.NewChatPhoto;
            var deleteChatPhoto = sendMessage.Result.ReplyToMessage.DeleteChatPhoto;
            var groupChatCreated = sendMessage.Result.ReplyToMessage.GroupChatCreated;
            var superGroupChatCreated = sendMessage.Result.ReplyToMessage.SuperGroupChatCreated;
            var channelChatCreated = sendMessage.Result.ReplyToMessage.ChannelChatCreated;
            var migrateToChatId = sendMessage.Result.ReplyToMessage.MigrateToChatId;
            var migrateFromChatId = sendMessage.Result.ReplyToMessage.MigrateFromChatId;
            var pinnedMessage = sendMessage.Result.ReplyToMessage.PinnedMessage;
            //todo Invoice
            //todo SuceffulPayment

            Console.WriteLine("TestAppealToMigrateFromReplyToMessage():"
                              + "\n sendMessage.Result.ReplyToMessage: " + message
                              + "\n sendMessage.Result.ReplyToMessage.MessageId: " + messageId
                              + "\n sendMessage.Result.ReplyToMessage.From: " + from
                              + "\n sendMessage.Result.ReplyToMessage.Date: " + date
                              + "\n sendMessage.Result.ReplyToMessage.Chat: " + chat
                              + "\n sendMessage.Result.ReplyToMessage.ForwardFrom: " + forwardFrom
                              + "\n sendMessage.Result.ReplyToMessage.ForwardFromMessageId: " + forwardFromMessageId
                              + "\n sendMessage.Result.ReplyToMessage.ReplyToMessage: " + replyToMessage
                              + "\n sendMessage.Result.ReplyToMessage.EditDate: " + editDate
                              + "\n sendMessage.Result.ReplyToMessage.Text: " + text
                              + "\n sendMessage.Result.ReplyToMessage.Audio: " + audio
                              + "\n sendMessage.Result.ReplyToMessage.Document: " + document
                              + "\n sendMessage.Result.ReplyToMessage.Photo: " + photo
                              + "\n sendMessage.Result.ReplyToMessage.Sticker " + sticker
                              + "\n sendMessage.Result.ReplyToMessage.Video: " + video
                              + "\n sendMessage.Result.ReplyToMessage.Caption: " + caption
                              + "\n sendMessage.Result.ReplyToMessage.Contact: " + contact
                              + "\n sendMessage.Result.ReplyToMessage.Location: " + location
                              + "\n sendMessage.Result.ReplyToMessage.NewChatMember: " + newChatMember
                              + "\n sendMessage.Result.ReplyToMessage.LeftChatMember: " + leftChatMember
                              + "\n sendMessage.Result.ReplyToMessage.NewChatTitle: " + newChatTitle
                              + "\n sendMessage.Result.ReplyToMessage.NewChatPhoto: " + newChatPhoto
                              + "\n sendMessage.Result.ReplyToMessage.DeleteChatPhoto: " + deleteChatPhoto
                              + "\n sendMessage.Result.ReplyToMessage.GroupChatCreated: " + groupChatCreated
                              + "\n sendMessage.Result.ReplyToMessage.SuperGroupChatCreated: " + superGroupChatCreated
                              + "\n sendMessage.Result.ReplyToMessage.ChannelChatCreated: " + channelChatCreated
                              + "\n sendMessage.Result.ReplyToMessage.MigrateToChatId: " + migrateToChatId
                              + "\n sendMessage.Result.ReplyToMessage.MigrateFromChatId: " + migrateFromChatId
                              + "\n sendMessage.Result.ReplyToMessage.PinnedMessage: " + pinnedMessage);

            //check instance MessageInfo.PinnedMesage
            Assert.IsInstanceOf(typeof(MessageInfo), message);

            //check MessageInfo.PinnedMesage.field
            Assert.AreEqual(messageId, 0);
            Assert.IsNull(from);
            Assert.AreEqual(date, DateTime.MinValue);
            Assert.IsNull(chat);
            Assert.IsNull(forwardFrom);
            Assert.AreEqual(forwardFromMessageId, 0);
            Assert.AreEqual(forwardDate, DateTime.MinValue);
            Assert.IsNull(replyToMessage);
            Assert.AreEqual(editDate, DateTime.MinValue);
            Assert.IsNull(text);
            Assert.IsNull(audio);
            Assert.IsNull(document);
            Assert.IsNull(photo);
            Assert.IsNull(sticker);
            Assert.IsNull(video);
            Assert.IsNull(caption);
            Assert.IsNull(contact);
            Assert.IsNull(location);
            Assert.IsNull(newChatMember);
            Assert.IsNull(leftChatMember);
            Assert.IsNull(leftChatMember);
            Assert.IsNull(newChatTitle);
            Assert.IsNull(newChatPhoto);
            Assert.IsFalse(deleteChatPhoto);
            Assert.IsFalse(groupChatCreated);
            Assert.IsFalse(superGroupChatCreated);
            Assert.IsFalse(channelChatCreated);
            Assert.AreEqual(migrateToChatId, 0);
            Assert.AreEqual(migrateFromChatId, 0);
            Assert.IsNull(pinnedMessage);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.EditDateUnix"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromEditDateUnix()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromEditDateUnix()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.ForwardDate
            var editDateUnix = sendMessage.Result.EditDateUnix;
            var editDateString = sendMessage.Result.EditDateUnix.ToString();

            Console.WriteLine("TestAppealToMigrateFromEditDateUnix():"
                              + "\n sendMessage.Result.EditDateUnix: " + editDateUnix
                              + "\n sendMessage.Result.EditDateUnix.ToString(): " + editDateString);

            //check instance MessageInfo.ForwardDate
            Assert.IsInstanceOf(typeof(int), editDateUnix);

            //check value MessageInfo.ForwardDate
            Assert.AreEqual(editDateUnix, 0);
            Assert.AreEqual(editDateString, "0");
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.EditDate"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromEditDate()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromEditDate()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.ForwardDate
            var editDate = sendMessage.Result.EditDate;

            var editDateYear = sendMessage.Result.EditDate.Year;
            var editDateMonth = sendMessage.Result.EditDate.Month;
            var editDateDay = sendMessage.Result.EditDate.Day;

            Console.WriteLine("TestAppealToMigrateFromEditDate():"
                              + "\n sendMessage.Result.EditDate: " + editDate
                              + "\n sendMessage.Result.EditDate.Year: " + editDateYear
                              + "\n endMessage.Result.EditDate.Month: " +  editDateMonth
                              + "\n sendMessage.Result.EditDate.Day: " +  editDateDay);

            //check instance MessageInfo.ForwardDate
            Assert.IsInstanceOf(typeof(DateTime), editDate);

            //check value MessageInfo.ForwardDate
            Assert.AreEqual(editDate, DateTime.MinValue);
            Assert.AreEqual(editDateYear, 0001);
            Assert.AreEqual(editDateMonth, 01);
            Assert.AreEqual(editDateDay, 01);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardFromMessageId"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyForwardFromMessageId()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyForwardFromMessageId()");
            Assert.True(sendMessage.Ok);

            var forwardFromMessageId = sendMessage.Result.ForwardFromMessageId;

            Console.WriteLine("TestAppealToTheEmptyForwardFromMessageId():"
                              + "\n sendMessage.Result.ForwardFromMessageId: " + forwardFromMessageId);

            //check instance MessageInfo.ForwardFromMessageId
            Assert.IsInstanceOf(typeof(int), forwardFromMessageId);

            //сhecks the return value
            Assert.AreEqual(forwardFromMessageId, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Audio"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyAudio()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyAudio()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.Audio
            var audio = sendMessage.Result.Audio;

            // field MessageInfo.Audio
            var fileId = sendMessage.Result.Audio.FileId;
            var duration = sendMessage.Result.Audio.Duration;
            var performer = sendMessage.Result.Audio.Performer;
            var title = sendMessage.Result.Audio.Title;
            var mimeType = sendMessage.Result.Audio.MimeType;
            var fileSize = sendMessage.Result.Audio.FileSize;

            Console.WriteLine("TestAppealToTheEmptyAudio():"
                              + "\n sendMessage.Result.Audio " + audio
                              + "\n sendMessage.Result.Audio.FileId: " + fileId
                              + "\n sendMessage.Result.Audio.Duration;: " + duration
                              + "\n sendMessage.Result.Audio.Performer: " + performer
                              + "\n sendMessage.Result.Audio.Title: " + title
                              + "\n sendMessage.Result.Audio.MimeType: " + mimeType
                              + "\n sendMessage.Result.Audio.FileSize: " + fileSize);

            //check instance MessageInfo.Audio
            Assert.IsInstanceOf(typeof(AudioInfo), audio);

            //check MessageInfo.Audio.field
            Assert.IsNull(fileId);
            Assert.AreEqual(duration, 0);
            Assert.IsNull(performer);
            Assert.IsNull(title);
            Assert.IsNull(mimeType);
            Assert.AreEqual(fileSize, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Document"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyDocument()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyDocument()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.Document
            var document = sendMessage.Result.Document;

            // field MessageInfo.Document
            var fileId = sendMessage.Result.Document.FileId;
            var fileName = sendMessage.Result.Document.FileName;
            var mimeType = sendMessage.Result.Document.MimeType;
            var fileSize = sendMessage.Result.Document.FileSize;

            // typeof MessageInfo.Document.Thumb
            var thumb = sendMessage.Result.Document.Thumb;

            // field MessageInfo.Document.Thumb
            var thumbWidth = sendMessage.Result.Document.Thumb.Width;
            var thumbHeight = sendMessage.Result.Document.Thumb.Height;
            var thumbFileId = sendMessage.Result.Document.Thumb.FileId;
            var thumbFileSize = sendMessage.Result.Document.Thumb.FileSize;

            Console.WriteLine("TestAppealToTheEmptyDocument():"
                              + "\n sendMessage.Result.Document " + document
                              + "\n sendMessage.Result.Document.FileId: " + fileId
                              + "\n sendMessage.Result.Document.FileName;: " + fileName
                              + "\n sendMessage.Result.Document.MimeType: " + mimeType
                              + "\n sendMessage.Result.Document.FileSize: " + fileSize 
                              + "\n sendMessage.Result.Document.Thumb: " + thumb
                              + "\n sendMessage.Result.Document.Thumb.Width: " + thumbWidth
                              + "\n sendMessage.Result.Document.Thumb.Height: " + thumbHeight
                              + "\n sendMessage.Result.Document.Thumb.FileId: " + thumbFileId
                              + "\n sendMessage.Result.Document.Thumb.FileSize: " + thumbFileSize);


            //check instance MessageInfo.Document
            Assert.IsInstanceOf(typeof(DocumentInfo), document);

            //check MessageInfo.Document.field
            Assert.IsNull(fileId);
            Assert.IsNull(fileName);
            Assert.IsNull(mimeType);
            Assert.AreEqual(fileSize, 0);

            //check instance MessageInfo.Document.Thumb
            Assert.IsInstanceOf(typeof(PhotoSizeInfo), thumb);

            //check MessageInfo.Document.field
            Assert.AreEqual(thumbWidth, 0);
            Assert.AreEqual(thumbHeight, 0);
            Assert.IsNull(thumbFileId);
            Assert.AreEqual(thumbFileSize, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Photo"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyPhoto()
        {
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
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.Sticker
            var sticker = sendMessage.Result.Sticker;

            // field MessageInfo.Sticker
            var fileId = sendMessage.Result.Sticker.FileId;
            var width = sendMessage.Result.Sticker.Width;
            var height = sendMessage.Result.Sticker.Height;
            var emoji = sendMessage.Result.Sticker.Emoji;
            var fileSize = sendMessage.Result.Sticker.FileSize;

            // typeof MessageInfo.Sticker.Thumb
            var thumb = sendMessage.Result.Sticker.Thumb;

            // field MessageInfo.Sticker.Thumb
            var thumbWidth = sendMessage.Result.Sticker.Thumb.Width;
            var thumbHeight = sendMessage.Result.Sticker.Thumb.Height;
            var thumbFileId = sendMessage.Result.Sticker.Thumb.FileId;
            var thumbFileSize = sendMessage.Result.Sticker.Thumb.FileSize;

            Console.WriteLine("TestAppealToTheEmptySticker():"
                              + "\n sendMessage.Result.Sticker: " + sticker
                              + "\n sendMessage.Result.Sticker.FileId: " + fileId
                              + "\n sendMessage.Result.Sticker.Width;: " + width
                              + "\n sendMessage.Result.Sticker.Height: " + height
                              + "\n sendMessage.Result.Sticker.Thumb: " + thumb
                              + "\n sendMessage.Result.Sticker.Emoji: " + emoji
                              + "\n sendMessage.Result.Sticker.FileSize: " + fileSize
                              + "\n sendMessage.Result.Sticker.Thumb: " + thumb
                              + "\n sendMessage.Result.Sticker.Thumb.Width: " + thumbWidth
                              + "\n sendMessage.Result.Sticker.Thumb.Height: " + thumbHeight
                              + "\n sendMessage.Result.Sticker.Thumb.FileId: " + thumbFileId
                              + "\n sendMessage.Result.Sticker.Thumb.FileSize: " + thumbFileSize);

            //check instance MessageInfo.Sticker
            Assert.IsInstanceOf(typeof(StickerInfo), sticker);

            //check MessageInfo.Sticker.field
            Assert.IsNull(fileId);
            Assert.AreEqual(width, 0);
            Assert.AreEqual(height, 0);
            Assert.IsNull(emoji);
            Assert.AreEqual(fileSize, 0);

            //check instance MessageInfo.Sticker.Thumb
            Assert.IsInstanceOf(typeof(PhotoSizeInfo), thumb);

            //check MessageInfo.Sticker.field
            Assert.AreEqual(thumbWidth, 0);
            Assert.AreEqual(thumbHeight, 0);
            Assert.IsNull(thumbFileId);
            Assert.AreEqual(thumbFileSize, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Video"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyVideo()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyVideo()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.Video
            var video = sendMessage.Result.Video;

            // field MessageInfo.Video
            var fileId = sendMessage.Result.Video.FileId;
            var duration = sendMessage.Result.Video.Duration;
            var fileSize = sendMessage.Result.Video.FileSize;
            var width = sendMessage.Result.Video.Width;
            var height = sendMessage.Result.Video.Height;
            var mimeType = sendMessage.Result.Video.MimeType;

            // typeof MessageInfo.Video.Thumb
            var thumb = sendMessage.Result.Video.Thumb;

            // field MessageInfo.Video.Thumb
            var thumbWidth = sendMessage.Result.Video.Thumb.Width;
            var thumbHeight = sendMessage.Result.Video.Thumb.Height;
            var thumbFileId = sendMessage.Result.Video.Thumb.FileId;
            var thumbFileSize = sendMessage.Result.Video.Thumb.FileSize;

            Console.WriteLine("TestAppealToTheEmptyVideo():"
                              + "\n sendMessage.Result.Video: " + video
                              + "\n sendMessage.Result.Video.FileId: " + fileId
                              + "\n sendMessage.Result.Video.Duration: " + duration
                              + "\n sendMessage.Result.Video.FileSize: " + fileSize
                              + "\n sendMessage.Result.Video.Width: " + width
                              + "\n sendMessage.Result.Video.Height: " + height
                              + "\n sendMessage.Result.Video.MimeType: " + mimeType
                              + "\n sendMessage.Result.Video.Thumb: " + thumb
                              + "\n sendMessage.Result.Video.Thumb.Width: " + thumbWidth
                              + "\n sendMessage.Result.Video.Thumb.Height: " + thumbHeight
                              + "\n sendMessage.Result.Video.Thumb.FileId: " + thumbFileId
                              + "\n sendMessage.Result.Video.Thumb.FileSize: " + thumbFileSize);

            //check instance MessageInfo.Video
            Assert.IsInstanceOf(typeof(VideoInfo), video);

            //check MessageInfo.Video.field
            Assert.IsNull(fileId);
            Assert.AreEqual(duration, 0);
            Assert.AreEqual(width, 0);
            Assert.AreEqual(height, 0);
            Assert.AreEqual(fileSize, 0);
            Assert.IsNull(mimeType);

            //check instance MessageInfo.Video.Thumb
            Assert.IsInstanceOf(typeof(PhotoSizeInfo), thumb);
            
            //check MessageInfo.Video.Thumb.field
            Assert.AreEqual(thumbWidth, 0);
            Assert.AreEqual(thumbHeight, 0);
            Assert.IsNull(thumbFileId);
            Assert.AreEqual(thumbFileSize, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Caption"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyCaption()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyCaption()");
            Assert.True(sendMessage.Ok);

            var caption = sendMessage.Result.Caption;
            var captionLength = sendMessage.Result.Caption.Length;

            Console.WriteLine("TestAppealToTheEmptyCaption():"
                + "\n sendMessage.Result.Caption: " + caption
                + "\n sendMessage.Result.Caption.Length: " + captionLength);

            //check instance MessageInfo.Caption
            Assert.IsInstanceOf(typeof(string), caption);

            //сhecks the return value
            Assert.IsEmpty(caption);
            Assert.AreEqual(caption, string.Empty);
            Assert.AreEqual(captionLength, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Contact"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyContact()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyContact()");
            Assert.True(sendMessage.Ok);
            
            // typeof MessageInfo.Contact
            var contact = sendMessage.Result.Contact;

            // field MessageInfo.Contact
            var userId = sendMessage.Result.Contact.UserId;
            var phoneNumber = sendMessage.Result.Contact.PhoneNumber;
            var firstName = sendMessage.Result.Contact.FirstName;
            var lastName = sendMessage.Result.Contact.LastName;

            Console.WriteLine("AppealToTheEmptyContact():"
                + "\n sendMessage.Result.Contact: " + contact
                + "\n sendMessage.Result.Contact.UserId: " + userId
                + "\n sendMessage.Result.Contact.PhoneNumber: " + phoneNumber
                + "\n sendMessage.Result.Contact.FirstName: " + firstName
                + "\n sendMessage.Result.Contact.LastName: " + lastName);

            //check instance MessageInfo.Contact
            Assert.IsInstanceOf(typeof(ContactInfo), contact);

            //check MessageInfo.Contact.field
            Assert.IsNull(userId);
            Assert.IsNull(phoneNumber);
            Assert.IsNull(firstName);
            Assert.IsNull(lastName);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Location"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyLocation()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyLocation()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.Contact
            var location = sendMessage.Result.Location;

            // field MessageInfo.Contact
            var latitude = sendMessage.Result.Location.Latitude;
            var longitude = sendMessage.Result.Location.Longitude;

            Console.WriteLine("TestAppealToTheEmptyLocation()"
                              + "\n sendMessage.Result.Location: " + location
                              + "\n sendMessage.Result.Location.Latitude: " + latitude
                              + "\n sendMessage.Result.Location.Longitude: " + longitude);

            //check instance MessageInfo.Location
            Assert.IsInstanceOf(typeof(LocationInfo), location);

            //check MessageInfo.Location.field
            Assert.AreEqual(latitude, 0);
            Assert.AreEqual(longitude, 0);
        }


        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatMember"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatMember()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatMember()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.NewChatMember
            var newChatMember = sendMessage.Result.NewChatMember;

            // field MessageInfo.NewChatMember
            var id = sendMessage.Result.NewChatMember.Id;
            var firstName = sendMessage.Result.NewChatMember.FirstName;
            var lastName = sendMessage.Result.NewChatMember.LastName;
            var userName = sendMessage.Result.NewChatMember.UserName;
            var languageCode = sendMessage.Result.NewChatMember.LanguageCode;

            Console.WriteLine("TestAppealToTheEmptyNewChatMember():"
                              + "\n ssendMessage.Result.NewChatMember: " + newChatMember
                              + "\n sendMessage.Result.NewChatMember.Id: " + id
                              + "\n sendMessage.Result.NewChatMember.FirstName: " + firstName
                              + "\n sendMessage.Result.NewChatMember.LastName: " + lastName
                              + "\n sendMessage.Result.NewChatMember.UserName: " + userName
                              + "\n sendMessage.Result.NewChatMember.LanguageCode: " + languageCode);

            //check instance MessageInfo.NewChatMember
            Assert.IsInstanceOf(typeof(UserInfo), newChatMember);

            //check MessageInfo.NewChatMember.field
            Assert.AreEqual(id, 0);
            Assert.IsNull(firstName);
            Assert.IsNull(lastName);
            Assert.IsNull(userName);
            Assert.IsNull(languageCode);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatMember"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyLeftChatMember()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyLeftChatMember()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.LeftChatMember
            var leftChatMember = sendMessage.Result.LeftChatMember;

            // field MessageInfo.LeftChatMember
            var id = sendMessage.Result.LeftChatMember.Id;
            var firstName = sendMessage.Result.LeftChatMember.FirstName;
            var lastName = sendMessage.Result.LeftChatMember.LastName;
            var userName = sendMessage.Result.LeftChatMember.UserName;
            var languageCode = sendMessage.Result.LeftChatMember.LanguageCode;

            Console.WriteLine("TestAppealToTheEmptyLeftChatMember():"
                              + "\n sendMessage.Result.LeftChatMember: " + leftChatMember
                              + "\n sendMessage.Result.LeftChatMember.Id: " + id
                              + "\n sendMessage.Result.LeftChatMember.FirstName: " + firstName
                              + "\n sendMessage.Result.LeftChatMember.LastName: " + lastName
                              + "\n sendMessage.Result.LeftChatMember.UserName: " + userName
                              + "\n sendMessage.Result.LeftChatMember.LanguageCode: " + languageCode);

            //check instance MessageInfo.LeftChatMember
            Assert.IsInstanceOf(typeof(UserInfo), leftChatMember);

            //check MessageInfo.LeftChatMember.field
            Assert.AreEqual(id, 0);
            Assert.IsNull(firstName);
            Assert.IsNull(lastName);
            Assert.IsNull(userName);
            Assert.IsNull(languageCode);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatTitle"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatTitle()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatTitle()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.NewChatTitle
            var newChatTitle = sendMessage.Result.NewChatTitle;

            var newChatTitleLenth = sendMessage.Result.NewChatTitle.Length;

            Console.WriteLine("TestAppealToTheEmptyNewChatTitle():"
                + "\n sendMessage.Result.Caption: " + newChatTitle
                + "\n sendMessage.Result.Caption.Length: " + newChatTitleLenth);

            //check instance MessageInfo.NewChatTitle
            Assert.IsInstanceOf(typeof(string), newChatTitle);

            //сhecks the return value
            Assert.IsEmpty(newChatTitle);
            Assert.AreEqual(newChatTitle, string.Empty);
            Assert.AreEqual(newChatTitleLenth, 0);

        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatPhoto"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatPhoto()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatPhoto()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.NewChatPhoto
            var newChatPhoto = sendMessage.Result.NewChatPhoto;

            var newChatPhotoLength = sendMessage.Result.NewChatPhoto.Length;

            Console.WriteLine("TestAppealToTheEmptyNewChatPhoto():"
                              + "\n sendMessage.Result.Photo: " + newChatPhoto
                              + "\n sendMessage.Result.photoLength: " + newChatPhotoLength);

            //check instance  MessageInfo.NewChatPhoto
            Assert.IsInstanceOf(typeof(PhotoSizeInfo[]), newChatPhoto);

            //сhecks the return value
            Assert.AreEqual(newChatPhotoLength, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.DeleteChatPhoto"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyDeleteChatPhoto()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyDeleteChatPhoto()");
            Assert.True(sendMessage.Ok);

            var deleteChatPhoto = sendMessage.Result.DeleteChatPhoto;
            
            Console.WriteLine("TestAppealToTheEmptyDeleteChatPhoto():"
                + "\n sendMessage.Result.DeleteChatPhoto: " + deleteChatPhoto);

            //check instance MessageInfo.DeleteChatPhoto
            Assert.IsInstanceOf(typeof(bool), deleteChatPhoto);

            //сhecks the return value
            Assert.IsFalse(deleteChatPhoto);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.GroupChatCreated"/>
        /// </summary>
        [Test]
        public void TestAppealToTheGroupChatCreated()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheGroupChatCreated()");
            Assert.True(sendMessage.Ok);

            var groupChatCreated = sendMessage.Result.GroupChatCreated;

            Console.WriteLine("TestAppealToTheGroupChatCreated():"
                + "\n sendMessage.Result.GroupChatCreated: " + groupChatCreated);

            //check instance MessageInfo.GroupChatCreated
            Assert.IsInstanceOf(typeof(bool), groupChatCreated);

            //сhecks the return value
            Assert.IsFalse(groupChatCreated);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.SuperGroupChatCreated"/>
        /// </summary>
        [Test]
        public void TestAppealToSuperGroupChatCreated()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToSuperGroupChatCreated()");
            Assert.True(sendMessage.Ok);

            var superGroupChatCreated = sendMessage.Result.SuperGroupChatCreated;

            Console.WriteLine("TestAppealToSuperGroupChatCreated():"
                + "\n sendMessage.Result.SuperGroupChatCreated: " + superGroupChatCreated);

            Assert.IsFalse(superGroupChatCreated);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ChannelChatCreated"/>
        /// </summary>
        [Test]
        public void TestAppealToChannelChatCreated()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToChannelChatCreated()");
            Assert.True(sendMessage.Ok);

            var channelChatCreated = sendMessage.Result.ChannelChatCreated;

            Console.WriteLine("TestAppealToChannelChatCreated():"
                + "\n sendMessage.Result.ChannelChatCreated: " + channelChatCreated);

            //check instance MessageInfo.ChannelChatCreated
            Assert.IsInstanceOf(typeof(bool), channelChatCreated);

            //сhecks the return value
            Assert.IsFalse(channelChatCreated);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.MigrateToChatId"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateToChatId()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateToChatId()");
            Assert.True(sendMessage.Ok);

            var migrateToChatId = sendMessage.Result.MigrateToChatId;

            Console.WriteLine("TestAppealToMigrateToChatId():"
                + "\n sendMessage.Result.MigrateToChatId: " + migrateToChatId);

            //check instance MessageInfo.MigrateToChatId
            Assert.IsInstanceOf(typeof(int), migrateToChatId);

            //сhecks the return value
            Assert.AreEqual(migrateToChatId, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.MigrateFromChatId"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromChatId()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromChatId()");
            Assert.True(sendMessage.Ok);

            var migrateFromChatId = sendMessage.Result.MigrateFromChatId;

            Console.WriteLine("TestAppealToMigrateFromChatId():"
                + "\n sendMessage.Result.MigrateToChatId: " + migrateFromChatId);
            
            //check instance MessageInfo.MigrateFromChatId
            Assert.IsInstanceOf(typeof(int), migrateFromChatId);

            //сhecks the return value
            Assert.AreEqual(migrateFromChatId, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.PinnedMessage"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromPinnedMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromPinnedMessage()");
            Assert.True(sendMessage.Ok);

            // typeof MessageInfo.PinnedMessage
            var message = sendMessage.Result.PinnedMessage;

            // field MessageInfo.PinnedMessage.field
            var messageId = sendMessage.Result.PinnedMessage.MessageId;
            var from = sendMessage.Result.PinnedMessage.From;
            var date = sendMessage.Result.PinnedMessage.Date;
            var chat = sendMessage.Result.PinnedMessage.Chat;
            var forwardFrom = sendMessage.Result.PinnedMessage.ForwardFrom;
            //todo forward_from_chat
            var forwardFromMessageId = sendMessage.Result.PinnedMessage.ForwardFromMessageId;
            var forwardDate = sendMessage.Result.PinnedMessage.ForwardDate;
            var replyToMessage = sendMessage.Result.PinnedMessage.ReplyToMessage;
            var editDate = sendMessage.Result.PinnedMessage.EditDate;
            var text = sendMessage.Result.PinnedMessage.Text;
            //todo entities
            var audio = sendMessage.Result.PinnedMessage.Audio;
            var document = sendMessage.Result.PinnedMessage.Document;
            //todo game
            var photo = sendMessage.Result.PinnedMessage.Photo;
            var sticker = sendMessage.Result.PinnedMessage.Sticker;
            var video = sendMessage.Result.PinnedMessage.Video;
            //todo Voice
            //todo VideoNote
            //todo NewChatMembers;
            var caption = sendMessage.Result.PinnedMessage.Caption;
            var contact = sendMessage.Result.PinnedMessage.Contact;
            var location = sendMessage.Result.PinnedMessage.Location;
            //todo Venue
            var newChatMember = sendMessage.Result.PinnedMessage.NewChatMember;
            var leftChatMember = sendMessage.Result.PinnedMessage.LeftChatMember;
            var newChatTitle = sendMessage.Result.PinnedMessage.NewChatTitle;
            var newChatPhoto = sendMessage.Result.PinnedMessage.NewChatPhoto;
            var deleteChatPhoto = sendMessage.Result.PinnedMessage.DeleteChatPhoto;
            var groupChatCreated = sendMessage.Result.PinnedMessage.GroupChatCreated;
            var superGroupChatCreated = sendMessage.Result.PinnedMessage.SuperGroupChatCreated;
            var channelChatCreated = sendMessage.Result.PinnedMessage.ChannelChatCreated;
            var migrateToChatId = sendMessage.Result.PinnedMessage.MigrateToChatId;
            var migrateFromChatId = sendMessage.Result.PinnedMessage.MigrateFromChatId;
            var pinnedMessage = sendMessage.Result.PinnedMessage.PinnedMessage;
            //todo Invoice
            //todo SuceffulPayment

            Console.WriteLine("TestAppealToMigrateFromPinnedMessage():"
                              + "\n sendMessage.Result.PinnedMessage: " + message
                              + "\n sendMessage.Result.PinnedMessage.MessageId: " + messageId
                              + "\n sendMessage.Result.PinnedMessage.From: " + from
                              + "\n sendMessage.Result.PinnedMessage.Date: " + date
                              + "\n sendMessage.Result.PinnedMessage.Chat: " + chat
                              + "\n sendMessage.Result.PinnedMessage.ForwardFrom: " + forwardFrom
                              + "\n sendMessage.Result.PinnedMessage.ForwardFromMessageId: " + forwardFromMessageId
                              + "\n sendMessage.Result.PinnedMessage.ReplyToMessage: " + replyToMessage
                              + "\n sendMessage.Result.PinnedMessage.EditDate: " + editDate
                              + "\n sendMessage.Result.PinnedMessage.Text: " + text
                              + "\n sendMessage.Result.PinnedMessage.Audio: " + audio
                              + "\n sendMessage.Result.PinnedMessage.Document: " + document
                              + "\n sendMessage.Result.PinnedMessage.Photo: " + photo
                              + "\n sendMessage.Result.PinnedMessage.Sticker " + sticker
                              + "\n sendMessage.Result.PinnedMessage.Video: " + video
                              + "\n sendMessage.Result.PinnedMessage.Caption: " + caption
                              + "\n sendMessage.Result.PinnedMessage.Contact: " + contact
                              + "\n sendMessage.Result.PinnedMessage.Location: " + location
                              + "\n sendMessage.Result.PinnedMessage.NewChatMember: " + newChatMember
                              + "\n sendMessage.Result.PinnedMessage.LeftChatMember: " + leftChatMember
                              + "\n sendMessage.Result.PinnedMessage.NewChatTitle: " + newChatTitle
                              + "\n sendMessage.Result.PinnedMessage.NewChatPhoto: " + newChatPhoto
                              + "\n sendMessage.Result.PinnedMessage.DeleteChatPhoto: " + deleteChatPhoto
                              + "\n sendMessage.Result.PinnedMessage.GroupChatCreated: " + groupChatCreated
                              + "\n sendMessage.Result.PinnedMessage.SuperGroupChatCreated: " + superGroupChatCreated
                              + "\n sendMessage.Result.PinnedMessage.ChannelChatCreated: " + channelChatCreated
                              + "\n sendMessage.Result.PinnedMessage.MigrateToChatId: " + migrateToChatId
                              + "\n sendMessage.Result.PinnedMessage.MigrateFromChatId: " + migrateFromChatId
                              + "\n sendMessage.Result.PinnedMessage.PinnedMessage: " + pinnedMessage);

            //check instance MessageInfo.PinnedMesage
            Assert.IsInstanceOf(typeof(MessageInfo), message);

            //check MessageInfo.PinnedMesage.field
            Assert.AreEqual(messageId, 0);
            Assert.IsNull(from);
            Assert.AreEqual(date, DateTime.MinValue);
            Assert.IsNull(chat);
            Assert.IsNull(forwardFrom);
            Assert.AreEqual(forwardFromMessageId, 0);
            Assert.AreEqual(forwardDate, DateTime.MinValue);
            Assert.IsNull(replyToMessage);
            Assert.AreEqual(editDate, DateTime.MinValue);
            Assert.IsNull(text);
            Assert.IsNull(audio);
            Assert.IsNull(document);
            Assert.IsNull(photo);
            Assert.IsNull(sticker);
            Assert.IsNull(video);
            Assert.IsNull(caption);
            Assert.IsNull(contact);
            Assert.IsNull(location);
            Assert.IsNull(newChatMember);
            Assert.IsNull(leftChatMember);
            Assert.IsNull(leftChatMember);
            Assert.IsNull(newChatTitle);
            Assert.IsNull(newChatPhoto);
            Assert.IsFalse(deleteChatPhoto);
            Assert.IsFalse(groupChatCreated);
            Assert.IsFalse(superGroupChatCreated);
            Assert.IsFalse(channelChatCreated);
            Assert.AreEqual(migrateToChatId, 0);
            Assert.AreEqual(migrateFromChatId, 0);
            Assert.IsNull(pinnedMessage);
        }


        [Test]
        public void TestAppealToTheNonEmptyContact()
        {
            //todo create test after add method SendContact
        }
        
    }
}

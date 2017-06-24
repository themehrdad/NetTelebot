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

            // field MessageInfo.Video"
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
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Contact"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyContact()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyContact()");
            Assert.True(sendMessage.Ok);

            var contact = sendMessage.Result.Contact;
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
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatTitle"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatTitle()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatTitle()");
            Assert.True(sendMessage.Ok);

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

        [Test]
        public void TestAppealToTheNonEmptyContact()
        {
            //todo create test after add method SendContact
        }
        
    }
}

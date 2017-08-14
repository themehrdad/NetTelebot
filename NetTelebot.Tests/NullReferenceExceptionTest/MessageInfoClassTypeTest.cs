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
    internal class MessageInfoClassTypeTest
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
    }
}

using System;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NetTelebot.Type.Games;
using NetTelebot.Type.Payment;
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
        private long? mChatId;

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

            ConsoleUtlis.PrintResult(forwardFrom);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (UserInfo), forwardFrom);
                Assert.AreEqual(forwardFrom.Id, 0);
                Assert.IsNull(forwardFrom.FirstName);
                Assert.IsNull(forwardFrom.LastName);
                Assert.IsNull(forwardFrom.UserName);
                Assert.IsNull(forwardFrom.LanguageCode);
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
            
            ConsoleUtlis.PrintResult(forwardFromChat);
            ConsoleUtlis.PrintResult(forwardFromChat.Photo);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (ChatInfo), forwardFromChat);
                Assert.AreEqual(forwardFromChat.Id, 0);
                Assert.IsNull(forwardFromChat.Type);
                Assert.IsNull(forwardFromChat.Title);
                Assert.IsNull(forwardFromChat.Username);
                Assert.IsNull(forwardFromChat.FirstName);
                Assert.IsNull(forwardFromChat.LastName);
                Assert.IsFalse(forwardFromChat.AllMembersAreAdministrators);
                Assert.IsNull(forwardFromChat.Description);
                Assert.IsNull(forwardFromChat.InviteLink);

                Assert.IsNull(forwardFromChat.Photo.BigFileId);
                Assert.IsNull(forwardFromChat.Photo.SmallFileId);
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

            ConsoleUtlis.PrintResult(forwardDate);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(DateTime), forwardDate);
                Assert.AreEqual(forwardDate, DateTime.MinValue);
                Assert.AreEqual(forwardDate.Year, 0001);
                Assert.AreEqual(forwardDate.Month, 01);
                Assert.AreEqual(forwardDate.Day, 01);
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
            
            ConsoleUtlis.PrintResult(editDate);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (DateTime), editDate);
                Assert.AreEqual(editDate, DateTime.MinValue);
                Assert.AreEqual(editDate.Year, 0001);
                Assert.AreEqual(editDate.Month, 01);
                Assert.AreEqual(editDate.Day, 01);
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
            
            ConsoleUtlis.PrintResult(audio);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (AudioInfo), audio);
                Assert.IsNull(audio.FileId);
                Assert.AreEqual(audio.Duration, 0);
                Assert.IsNull(audio.Performer);
                Assert.IsNull(audio.Title);
                Assert.IsNull(audio.MimeType);
                Assert.AreEqual(audio.FileSize, 0);
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
            
            ConsoleUtlis.PrintResult(document);
            ConsoleUtlis.PrintResult(document.Thumb);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (DocumentInfo), document);
                Assert.IsNull(document.FileId);
                Assert.IsNull(document.FileName);
                Assert.IsNull(document.MimeType);
                Assert.AreEqual(document.FileSize, 0);

                Assert.IsInstanceOf(typeof (PhotoSizeInfo), document.Thumb);
                Assert.AreEqual(document.Thumb.Width, 0);
                Assert.AreEqual(document.Thumb.Height, 0);
                Assert.IsNull(document.Thumb.FileId);
                Assert.AreEqual(document.Thumb.FileSize, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Game"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyGame()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyGame()");

            GameInfo gameInfo = sendMessage.Result.Game;

            ConsoleUtlis.PrintResult(gameInfo);

            Assert.Multiple(() =>
            {
                //Game
                Assert.IsInstanceOf(typeof(GameInfo), gameInfo);
                Assert.IsNull(gameInfo.Title);
                Assert.IsNull(gameInfo.Description);
                Assert.IsNull(gameInfo.Text);

                //Game.Photo
                Assert.IsInstanceOf(typeof(PhotoSizeInfo[]), gameInfo.Photo);

                //Game.Entities
                Assert.IsInstanceOf(typeof(MessageEntityInfo[]), gameInfo.Entities);

                //Game.Animation
                Assert.IsNull(gameInfo.Animation.FileId);
                Assert.IsNull(gameInfo.Animation.FileName);
                Assert.IsNull(gameInfo.Animation.MimeType);
                Assert.AreEqual(0, gameInfo.Animation.FileSize);

                //Game.Animation.Thumb
                Assert.IsNull(gameInfo.Animation.Thumb.FileId);
                Assert.AreEqual(0, gameInfo.Animation.Thumb.Height);
                Assert.AreEqual(0, gameInfo.Animation.Thumb.Width);
                Assert.AreEqual(0, gameInfo.Animation.Thumb.FileSize);
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

            ConsoleUtlis.PrintResult(sticker);
            ConsoleUtlis.PrintResult(sticker.Thumb);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
            
                Assert.IsInstanceOf(typeof (StickerInfo), sticker);
                Assert.IsNull(sticker.FileId);
                Assert.AreEqual(sticker.Width, 0);
                Assert.AreEqual(sticker.Height, 0);
                Assert.IsNull(sticker.Emoji);
                Assert.AreEqual(sticker.FileSize, 0);
                
                Assert.IsInstanceOf(typeof (PhotoSizeInfo), sticker.Thumb);
                Assert.AreEqual(sticker.Thumb.Width, 0);
                Assert.AreEqual(sticker.Thumb.Height, 0);
                Assert.IsNull(sticker.Thumb.FileId);
                Assert.AreEqual(sticker.Thumb.FileSize, 0);
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
            
            ConsoleUtlis.PrintResult(video);
            ConsoleUtlis.PrintResult(video.Thumb);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (VideoInfo), video);
                Assert.IsNull(video.FileId);
                Assert.AreEqual(video.Duration, 0);
                Assert.AreEqual(video.Width, 0);
                Assert.AreEqual(video.Height, 0);
                Assert.AreEqual(video.FileSize, 0);
                Assert.IsNull(video.MimeType);
                
                Assert.IsInstanceOf(typeof (PhotoSizeInfo), video.Thumb);
                Assert.AreEqual(video.Thumb.Width, 0);
                Assert.AreEqual(video.Thumb.Height, 0);
                Assert.IsNull(video.Thumb.FileId);
                Assert.AreEqual(video.Thumb.FileSize, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Voice"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyVoice()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyVoice");

            VoiceInfo voice = sendMessage.Result.Voice;

            ConsoleUtlis.PrintResult(voice);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(VoiceInfo), voice);
                Assert.IsNull(voice.FileId);
                Assert.AreEqual(voice.Duration, 0);
                Assert.IsNull(voice.MimeType);
                Assert.AreEqual(voice.FileSize, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.VideoNote"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyVideoNote()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyVideoNote");

            VideoNoteInfo videoNote = sendMessage.Result.VideoNote;

            ConsoleUtlis.PrintResult(videoNote);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(VideoNoteInfo), videoNote);
                Assert.IsNull(videoNote.FileId);
                Assert.AreEqual(videoNote.Length, 0);
                Assert.AreEqual(videoNote.Duration, 0);
                Assert.AreEqual(videoNote.FileSize, 0);

                Assert.IsInstanceOf(typeof(PhotoSizeInfo), videoNote.Thumb);
                Assert.AreEqual(videoNote.Thumb.Width, 0);
                Assert.AreEqual(videoNote.Thumb.Height, 0);
                Assert.IsNull(videoNote.Thumb.FileId);
                Assert.AreEqual(videoNote.Thumb.FileSize, 0);
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
            
            ConsoleUtlis.PrintResult(contact);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (ContactInfo), contact);
                Assert.IsNull(contact.UserId);
                Assert.IsNull(contact.PhoneNumber);
                Assert.IsNull(contact.FirstName);
                Assert.IsNull(contact.LastName);
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
            
            ConsoleUtlis.PrintResult(location);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (LocationInfo), location);
                Assert.AreEqual(location.Latitude, 0);
                Assert.AreEqual(location.Longitude, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Venue"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyVenue()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyLocation()");

            VenueInfo venue = sendMessage.Result.Venue;

            ConsoleUtlis.PrintResult(venue);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(VenueInfo), venue);

                Assert.AreEqual(0, venue.Location.Latitude);
                Assert.AreEqual(0, venue.Location.Longitude);
                Assert.IsNull(venue.Title);
                Assert.IsNull(venue.Address);
                Assert.IsNull(venue.FoursquareId);
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
            
            ConsoleUtlis.PrintResult(leftChatMember);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (UserInfo), leftChatMember);
                Assert.AreEqual(leftChatMember.Id, 0);
                Assert.IsNull(leftChatMember.FirstName);
                Assert.IsNull(leftChatMember.LastName);
                Assert.IsNull(leftChatMember.UserName);
                Assert.IsNull(leftChatMember.LanguageCode);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Invoice"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyInvoice()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyInvoice()");

            InvoceInfo invoiceMessageInfo = sendMessage.Result.Invoice;

            ConsoleUtlis.PrintResult(invoiceMessageInfo);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(InvoceInfo), invoiceMessageInfo);
                Assert.IsNull(invoiceMessageInfo.Title);
                Assert.IsNull(invoiceMessageInfo.Description);
                Assert.IsNull(invoiceMessageInfo.StartParameter);
                Assert.IsNull(invoiceMessageInfo.Currency);
                Assert.AreEqual(invoiceMessageInfo.TotalAmmount, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.SuccessfulPayment"/>
        /// </summary>
        [Test]
        public void TestAppealToSuccessfulPayment()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptySuccessfulPayment()");

            SuccessfulPaymentInfo successfulPaymentInfo = sendMessage.Result.SuccessfulPayment;

            ConsoleUtlis.PrintResult(successfulPaymentInfo);

            Assert.Multiple(() =>
            {
                //SuccessfulPaymentInfo field
                Assert.IsInstanceOf(typeof(SuccessfulPaymentInfo), successfulPaymentInfo);
                Assert.IsNull(successfulPaymentInfo.Currency);
                Assert.AreEqual(0, successfulPaymentInfo.TotalAmmount);
                Assert.IsNull(successfulPaymentInfo.InvoicePayload);
                Assert.IsNull(successfulPaymentInfo.ShippingOptionId);
                Assert.IsNull(successfulPaymentInfo.TelegramPaymentChargeId);
                Assert.IsNull(successfulPaymentInfo.ProviderPaymentChargeId);

                //OrderInfo fields
                Assert.IsInstanceOf(typeof(OrderInfo), successfulPaymentInfo.OrderInfo);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.Name);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.PnoneNumber);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.Email);

                //ShippingAddressInfo fields
                Assert.IsInstanceOf(typeof(ShippingAddressInfo), successfulPaymentInfo.OrderInfo.ShippingAddress);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.ShippingAddress.CountryCode);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.ShippingAddress.State);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.ShippingAddress.City);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.ShippingAddress.StreetLineOne);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.ShippingAddress.StreetLineTwo);
                Assert.IsNull(successfulPaymentInfo.OrderInfo.ShippingAddress.PostCode);
            });
        }

    }
}

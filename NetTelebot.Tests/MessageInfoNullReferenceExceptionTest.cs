using System;
using NetTelebot.Tests.Utils;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    /// <summary>
    /// Checking for NullReferenceException when accessing to null fields MessageInfo after use available methods TelegramBotClients
    /// </summary>
    [TestFixture]
    internal class MessageInfoNullReferenceExceptionTest
    {
        private TelegramBotClient mTelegramBot;
        private int mChatId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetBot();
            mChatId = new TelegramBot().GetChatId();
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields MessageInfo.Caption
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyCaption()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyCaption()");
            Assert.AreEqual(sendMessage.Result.Text, "TestAppealToTheEmptyCaption()");
            Assert.True(sendMessage.Ok);

            var caption = sendMessage.Result.Caption;
            var captionLength = sendMessage.Result.Caption.Length;

            Console.WriteLine("TestAppealToTheEmptyCaption():"
                + "\n sendMessage.Result.Caption: " + caption
                + "\n sendMessage.Result.Caption.Length: " + captionLength);

            Assert.IsEmpty(caption);
            Assert.AreEqual(caption, string.Empty);
            Assert.AreEqual(captionLength, 0);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields MessageInfo.Contact
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyContact()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyContact()");
            Assert.AreEqual(sendMessage.Result.Text, "TestAppealToTheEmptyContact");
            Assert.True(sendMessage.Ok);

            var userId = sendMessage.Result.Contact.UserId;
            var phoneNumber = sendMessage.Result.Contact.PhoneNumber;
            var firstName = sendMessage.Result.Contact.FirstName;
            var lastName = sendMessage.Result.Contact.LastName;

            Console.WriteLine("AppealToTheEmptyContact():"
                + "\n sendMessage.Result.Contact.UserId: " + userId
                + "\n sendMessage.Result.Contact.PhoneNumber: " + phoneNumber
                + "\n sendMessage.Result.Contact.FirstName: " + firstName
                + "\n sendMessage.Result.Contact.LastName: " + lastName);
            
            Assert.IsNull(userId);
            Assert.IsNull(phoneNumber);
            Assert.IsNull(firstName);
            Assert.IsNull(lastName);
        }

        [Test]
        public void TestAppealToTheNonEmptyContact()
        {
            //todo create test after add method SendContact
        }

        private SendMessageResult SendMessage()
        {
            
        }
    }
}

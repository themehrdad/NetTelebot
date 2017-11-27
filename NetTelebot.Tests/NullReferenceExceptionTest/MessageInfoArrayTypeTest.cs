using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;

namespace NetTelebot.Tests.NullReferenceExceptionTest
{
    [TestFixture]
    internal class MessageInfoArrayTypeTest
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
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Entities"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyEntities()
        {
            const float latitude = 37.0000114f;
            const float longitude = 37.0000076f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatId, latitude, longitude);

            var entities = sendLocation.Result.Entities;
            
            ConsoleUtlis.PrintResult(entities);

            Assert.Multiple(() =>
            {
                Assert.True(sendLocation.Ok);

                Assert.IsInstanceOf(typeof (MessageEntityInfo[]), entities);
                Assert.IsEmpty(entities);
                Assert.AreEqual(sendLocation.Result.Entities.Length, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.CaptionEntities"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyCaptionEntities()
        {
            const float latitude = 37.0000114f;
            const float longitude = 37.0000076f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatId, latitude, longitude);

            var captionEntities = sendLocation.Result.CaptionEntities;

            ConsoleUtlis.PrintResult(captionEntities);

            Assert.Multiple(() =>
            {
                Assert.True(sendLocation.Ok);

                Assert.IsInstanceOf(typeof(MessageEntityInfo[]), sendLocation.Result.CaptionEntities);
                Assert.IsEmpty(sendLocation.Result.CaptionEntities);
                Assert.AreEqual(sendLocation.Result.CaptionEntities.Length, 0);
            });

        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Photo"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyPhoto()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyPhoto()");
            
            var photo = sendMessage.Result.Photo;
            
            ConsoleUtlis.PrintResult(photo);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (PhotoSizeInfo[]), photo);
                Assert.IsEmpty(photo);
                Assert.AreEqual(sendMessage.Result.Photo.Length, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatPhoto"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatPhoto()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatPhoto()");

            var newChatPhoto = sendMessage.Result.NewChatPhoto;

            ConsoleUtlis.PrintResult(newChatPhoto);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(PhotoSizeInfo[]), newChatPhoto);
                Assert.AreEqual(sendMessage.Result.NewChatPhoto.Length, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatMembers"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatMembers()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatMember()");

            var newChatMembers = sendMessage.Result.NewChatMembers;

            ConsoleUtlis.PrintResult(newChatMembers);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(UserInfo[]), newChatMembers);
                Assert.AreEqual(sendMessage.Result.NewChatMembers.Length, 0);
            });
        }
    }
}

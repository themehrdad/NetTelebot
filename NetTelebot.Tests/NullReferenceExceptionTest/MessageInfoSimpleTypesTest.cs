using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;

namespace NetTelebot.Tests.NullReferenceExceptionTest
{
    [TestFixture]
    internal class MessageInfoSimpleTypesTest
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
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardFromMessageId"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyForwardFromMessageId()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyForwardFromMessageId()");

            var forwardFromMessageId = sendMessage.Result.ForwardFromMessageId;

            ConsoleUtlis.PrintSimpleResult(forwardFromMessageId);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(int), forwardFromMessageId);
                Assert.AreEqual(forwardFromMessageId, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardSignature"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyForwardSignatureMessageId()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyForwardSignature()");

            var  forwardSignature = sendMessage.Result.ForwardSignature;

            ConsoleUtlis.PrintSimpleResult(forwardSignature);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(string), forwardSignature);
                Assert.AreEqual(forwardSignature, string.Empty);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ForwardDateUnix"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromForwardDateUnix()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromForwardDateUnix()");
            
            var forwardDateUnix = sendMessage.Result.ForwardDateUnix;
           
            ConsoleUtlis.PrintSimpleResult(forwardDateUnix);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                
                Assert.IsInstanceOf(typeof (long), forwardDateUnix);
                Assert.AreEqual(forwardDateUnix, 0);
                Assert.AreEqual(forwardDateUnix.ToString(), "0");
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.EditDateUnix"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromEditDateUnix()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromEditDateUnix()");
            
            var editDateUnix = sendMessage.Result.EditDateUnix;

            ConsoleUtlis.PrintSimpleResult(editDateUnix);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                
                Assert.IsInstanceOf(typeof (long), editDateUnix);
                Assert.AreEqual(editDateUnix, 0);
                Assert.AreEqual(editDateUnix.ToString(), "0");
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.AuthorSignature"/>
        /// </summary>
        [Test]
        public void TestAppealToAuthorSignature()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromEditDateUnix()");

            var authorSignature = sendMessage.Result.AuthorSignature;

            ConsoleUtlis.PrintSimpleResult(authorSignature);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(string), authorSignature);
                Assert.AreEqual(authorSignature, string.Empty);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Text"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyText()
        {
            const float latitude = 37.0000114f;
            const float longitude = 37.0000076f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatId, latitude, longitude);

            var text = sendLocation.Result.Text;

            ConsoleUtlis.PrintSimpleResult(text);

            Assert.Multiple(() =>
            {
                Assert.True(sendLocation.Ok);

                Assert.IsInstanceOf(typeof (string), text);
                Assert.IsEmpty(text);
                Assert.IsEmpty(text.ToUpper());
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.Caption"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyCaption()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyCaption()");
            
            var caption = sendMessage.Result.Caption;

            ConsoleUtlis.PrintSimpleResult(caption);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                
                Assert.IsInstanceOf(typeof (string), caption);
                Assert.IsEmpty(caption);
                Assert.AreEqual(caption, string.Empty);
                Assert.AreEqual(caption.Length, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.NewChatTitle"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyNewChatTitle()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyNewChatTitle()");
            
            var newChatTitle = sendMessage.Result.NewChatTitle;

            ConsoleUtlis.PrintSimpleResult(newChatTitle);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (string), newChatTitle);
                Assert.IsEmpty(newChatTitle);
                Assert.AreEqual(newChatTitle, string.Empty);
                Assert.AreEqual(newChatTitle.Length, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.DeleteChatPhoto"/>
        /// </summary>
        [Test]
        public void TestAppealToTheEmptyDeleteChatPhoto()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheEmptyDeleteChatPhoto()");
            
            var deleteChatPhoto = sendMessage.Result.DeleteChatPhoto;

            ConsoleUtlis.PrintSimpleResult(deleteChatPhoto);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (bool), deleteChatPhoto);
                Assert.IsFalse(deleteChatPhoto);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.GroupChatCreated"/>
        /// </summary>
        [Test]
        public void TestAppealToTheGroupChatCreated()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToTheGroupChatCreated()");
            
            var groupChatCreated = sendMessage.Result.GroupChatCreated;

            ConsoleUtlis.PrintSimpleResult(groupChatCreated);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (bool), groupChatCreated);
                Assert.IsFalse(groupChatCreated);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.SuperGroupChatCreated"/>
        /// </summary>
        [Test]
        public void TestAppealToSuperGroupChatCreated()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToSuperGroupChatCreated()");
            
            var superGroupChatCreated = sendMessage.Result.SuperGroupChatCreated;

            ConsoleUtlis.PrintSimpleResult(superGroupChatCreated);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof(bool), superGroupChatCreated);
                Assert.IsFalse(superGroupChatCreated);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ChannelChatCreated"/>
        /// </summary>
        [Test]
        public void TestAppealToChannelChatCreated()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToChannelChatCreated()");
            
            var channelChatCreated = sendMessage.Result.ChannelChatCreated;

            ConsoleUtlis.PrintSimpleResult(channelChatCreated);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                
                Assert.IsInstanceOf(typeof (bool), channelChatCreated);
                Assert.IsFalse(channelChatCreated);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.MigrateToChatId"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateToChatId()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateToChatId()");

            var migrateToChatId = sendMessage.Result.MigrateToChatId;

            ConsoleUtlis.PrintSimpleResult(migrateToChatId);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                
                Assert.IsInstanceOf(typeof (int), migrateToChatId);
                Assert.AreEqual(migrateToChatId, 0);
            });
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.MigrateFromChatId"/>
        /// </summary>
        [Test]
        public void TestAppealToMigrateFromChatId()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromChatId()");
            
            var migrateFromChatId = sendMessage.Result.MigrateFromChatId;

            ConsoleUtlis.PrintSimpleResult(migrateFromChatId);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);

                Assert.IsInstanceOf(typeof (int), migrateFromChatId);
                Assert.AreEqual(migrateFromChatId, 0);
            });
        }
    }
}

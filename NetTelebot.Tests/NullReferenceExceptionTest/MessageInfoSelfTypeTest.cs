using System;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;


namespace NetTelebot.Tests.NullReferenceExceptionTest
{
    [TestFixture]
    internal class MessageInfoSelfTypeTest
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
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ReplyToMessage"/>
        /// </summary>
        [Test, Order(10)]
        public void TestAppealToMigrateFromReplyToMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromReplyToMessage()");

            MessageInfo replyToMessage = sendMessage.Result.ReplyToMessage;

            ConsoleUtlis.PrintResult(replyToMessage);

            CommonAssert(replyToMessage);
        }

        /// <summary>
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.PinnedMessage"/>
        /// </summary>
        [Test, Order(20)]
        public void TestAppealToMigrateFromPinnedMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromPinnedMessage()");

            MessageInfo pinnedMessage = sendMessage.Result.PinnedMessage;

            ConsoleUtlis.PrintResult(pinnedMessage);

            CommonAssert(pinnedMessage);
        }

        public void CommonAssert<T>(T messageInfo) where T : MessageInfo
        {
            Assert.Multiple(() =>
            {

                //todo game
                //todo Voice
                //todo VideoNote
                //todo NewChatMembers;
                //todo Venue
                //todo Invoice
                //todo SuceffulPayment

                Assert.IsInstanceOf(typeof (MessageInfo), messageInfo);

                Assert.AreEqual(messageInfo.MessageId, 0);

                Assert.IsInstanceOf<UserInfo>(messageInfo.From);
                Assert.AreEqual(messageInfo.From.Id, 0);

                Assert.AreEqual(messageInfo.Date, DateTime.MinValue);
                Assert.AreEqual(messageInfo.Date.Day, DateTime.MinValue.Day);

                Assert.IsInstanceOf<ChatInfo>(messageInfo.Chat);
                Assert.AreEqual(messageInfo.Chat.Id, 0);

                Assert.IsInstanceOf<UserInfo>(messageInfo.ForwardFrom);

                Assert.AreEqual(messageInfo.ForwardFromMessageId, 0);

                Assert.IsInstanceOf<ChatInfo>(messageInfo.ForwardFromChat);
                Assert.AreEqual(messageInfo.ForwardFromChat.Id, 0);

                Assert.AreEqual(messageInfo.ForwardDate, DateTime.MinValue);
                Assert.AreEqual(messageInfo.ForwardDate.Day, DateTime.MinValue.Day);

                Assert.IsInstanceOf<MessageInfo>(messageInfo.ReplyToMessage);
                Assert.AreEqual(messageInfo.ReplyToMessage.Chat.Id, 0);

                Assert.AreEqual(messageInfo.EditDate, DateTime.MinValue);
                Assert.AreEqual(messageInfo.EditDate.Day, DateTime.MinValue.Day);

                Assert.IsNull(messageInfo.Text);

                Assert.IsInstanceOf<MessageEntityInfo[]>(messageInfo.Entities);

                Assert.IsInstanceOf<AudioInfo>(messageInfo.Audio);
                Assert.AreEqual(messageInfo.Audio.Duration, 0);

                Assert.IsInstanceOf<DocumentInfo>(messageInfo.Document);
                Assert.IsNull(messageInfo.Document.FileId);

                Assert.IsEmpty(messageInfo.Photo);

                Assert.IsInstanceOf<StickerInfo>(messageInfo.Sticker);
                Assert.IsNull(messageInfo.Sticker.FileId);

                Assert.IsInstanceOf<VideoInfo>(messageInfo.Video);
                Assert.IsNull(messageInfo.Video.FileId);

                Assert.IsNull(messageInfo.Caption);

                Assert.IsInstanceOf<ContactInfo>(messageInfo.Contact);
                Assert.IsNull(messageInfo.Contact.UserId);

                Assert.IsInstanceOf<LocationInfo>(messageInfo.Location);
                Assert.AreEqual(messageInfo.Location.Latitude, 0);

                Assert.IsInstanceOf<UserInfo>(messageInfo.NewChatMember);
                Assert.AreEqual(messageInfo.NewChatMember.Id, 0);

                Assert.IsInstanceOf<UserInfo>(messageInfo.LeftChatMember);
                Assert.AreEqual(messageInfo.LeftChatMember.Id, 0);

                Assert.IsInstanceOf<UserInfo>(messageInfo.LeftChatMember);
                Assert.AreEqual(messageInfo.LeftChatMember.Id, 0);

                Assert.IsNull(messageInfo.NewChatTitle);
                Assert.IsEmpty(messageInfo.NewChatPhoto);
                Assert.IsFalse(messageInfo.DeleteChatPhoto);
                Assert.IsFalse(messageInfo.GroupChatCreated);
                Assert.IsFalse(messageInfo.SuperGroupChatCreated);
                Assert.IsFalse(messageInfo.ChannelChatCreated);
                Assert.AreEqual(messageInfo.MigrateToChatId, 0);
                Assert.AreEqual(messageInfo.MigrateFromChatId, 0);

                Assert.IsInstanceOf<MessageInfo>(messageInfo.PinnedMessage);
                Assert.AreEqual(messageInfo.PinnedMessage.Chat.Id, 0);

            });
        }
    }
}

using System;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NetTelebot.Type.Games;
using NetTelebot.Type.Payment;
using NUnit.Framework;


namespace NetTelebot.Tests.NullReferenceExceptionTest
{
    [TestFixture]
    internal class MessageInfoSelfTypeTest
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
        /// Checking for NullReferenceException when accessing null fields <see cref="MessageInfo.ReplyToMessage"/>
        /// </summary>
        [Test, Order(10)]
        public void TestAppealToMigrateFromReplyToMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "TestAppealToMigrateFromReplyToMessage()");

            MessageInfo replyToMessage = sendMessage.Result.ReplyToMessage;

            ConsoleUtlis.PrintResult(replyToMessage);

            CommonAsserts(replyToMessage);
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

            CommonAsserts(pinnedMessage);
        }

        private static void CommonAsserts<T>(T messageInfo) where T : MessageInfo
        {
            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf(typeof (MessageInfo), messageInfo);

                Assert.AreEqual(0, messageInfo.MessageId);

                Assert.IsInstanceOf<UserInfo>(messageInfo.From);
                Assert.AreEqual(0, messageInfo.From.Id);

                Assert.AreEqual(DateTime.MinValue, messageInfo.Date);
                Assert.AreEqual(DateTime.MinValue.Day, messageInfo.Date.Day);

                Assert.IsInstanceOf<ChatInfo>(messageInfo.Chat);
                Assert.AreEqual(0, messageInfo.Chat.Id);

                Assert.IsInstanceOf<UserInfo>(messageInfo.ForwardFrom);

                Assert.AreEqual(0, messageInfo.ForwardFromMessageId);

                Assert.IsInstanceOf<ChatInfo>(messageInfo.ForwardFromChat);
                Assert.AreEqual(0, messageInfo.ForwardFromChat.Id);

                Assert.AreEqual(DateTime.MinValue, messageInfo.ForwardDate);
                Assert.AreEqual(DateTime.MinValue.Day, messageInfo.ForwardDate.Day);

                Assert.IsInstanceOf<MessageInfo>(messageInfo.ReplyToMessage);
                Assert.AreEqual(0, messageInfo.ReplyToMessage.Chat.Id);

                Assert.AreEqual(DateTime.MinValue, messageInfo.EditDate);
                Assert.AreEqual(DateTime.MinValue.Day, messageInfo.EditDate.Day);

                Assert.IsNull(messageInfo.Text);

                Assert.IsInstanceOf<MessageEntityInfo[]>(messageInfo.Entities);
                Assert.IsInstanceOf<MessageEntityInfo[]>(messageInfo.CaptionEntities);

                Assert.IsInstanceOf<AudioInfo>(messageInfo.Audio);
                Assert.AreEqual(0, messageInfo.Audio.Duration);

                Assert.IsInstanceOf<DocumentInfo>(messageInfo.Document);
                Assert.IsNull(messageInfo.Document.FileId);

                Assert.IsInstanceOf(typeof(GameInfo), messageInfo.Game);
                Assert.IsNull(messageInfo.Game.Title);
                Assert.IsInstanceOf(typeof(PhotoSizeInfo[]), messageInfo.Game.Photo);
                Assert.IsInstanceOf(typeof(MessageEntityInfo[]), messageInfo.Game.Entities);
                Assert.IsInstanceOf(typeof(AnimationInfo), messageInfo.Game.Animation);
                Assert.IsNull(messageInfo.Game.Animation.FileId);
                
                Assert.IsEmpty(messageInfo.Photo);

                Assert.IsInstanceOf<StickerInfo>(messageInfo.Sticker);
                Assert.IsNull(messageInfo.Sticker.FileId);

                Assert.IsInstanceOf<VideoInfo>(messageInfo.Video);
                Assert.IsNull(messageInfo.Video.FileId);

                Assert.IsInstanceOf<VoiceInfo>(messageInfo.Voice);
                Assert.IsNull(messageInfo.Voice.FileId);

                Assert.IsInstanceOf<VideoNoteInfo>(messageInfo.VideoNote);
                Assert.IsNull(messageInfo.VideoNote.FileId);

                Assert.IsInstanceOf<UserInfo[]>(messageInfo.NewChatMembers);
                Assert.IsEmpty(messageInfo.NewChatMembers);

                Assert.IsNull(messageInfo.Caption);

                Assert.IsInstanceOf<ContactInfo>(messageInfo.Contact);
                Assert.IsNull(messageInfo.Contact.UserId);

                Assert.IsInstanceOf<LocationInfo>(messageInfo.Location);
                Assert.AreEqual(0, messageInfo.Location.Latitude);

                Assert.IsInstanceOf<VenueInfo>(messageInfo.Venue);
                Assert.AreEqual(0, messageInfo.Venue.Location.Latitude);

                Assert.IsInstanceOf<UserInfo>(messageInfo.NewChatMember);
                Assert.AreEqual(0, messageInfo.NewChatMember.Id);

                Assert.IsInstanceOf<UserInfo>(messageInfo.LeftChatMember);
                Assert.AreEqual(0, messageInfo.LeftChatMember.Id);

                Assert.IsInstanceOf<UserInfo>(messageInfo.LeftChatMember);
                Assert.AreEqual(0, messageInfo.LeftChatMember.Id);

                Assert.IsNull(messageInfo.NewChatTitle);
                Assert.IsEmpty(messageInfo.NewChatPhoto);
                Assert.IsFalse(messageInfo.DeleteChatPhoto);
                Assert.IsFalse(messageInfo.GroupChatCreated);
                Assert.IsFalse(messageInfo.SuperGroupChatCreated);
                Assert.IsFalse(messageInfo.ChannelChatCreated);
                Assert.AreEqual(0, messageInfo.MigrateToChatId);
                Assert.AreEqual(0, messageInfo.MigrateFromChatId);

                Assert.IsInstanceOf<MessageInfo>(messageInfo.PinnedMessage);
                Assert.AreEqual(0, messageInfo.PinnedMessage.Chat.Id);

                Assert.IsInstanceOf<InvoceInfo>(messageInfo.Invoice);
                Assert.AreEqual(0, messageInfo.Invoice.TotalAmmount);

                Assert.IsInstanceOf<SuccessfulPaymentInfo>(messageInfo.SuccessfulPayment);
                Assert.AreEqual(0, messageInfo.SuccessfulPayment.TotalAmmount);

                Assert.IsInstanceOf<OrderInfo>(messageInfo.SuccessfulPayment.OrderInfo);
                Assert.IsNull(messageInfo.SuccessfulPayment.OrderInfo.Email);

                Assert.IsInstanceOf<ShippingAddressInfo>(messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress);
                Assert.IsNull(messageInfo.SuccessfulPayment.OrderInfo.ShippingAddress.City);
            });
        }
    }
}

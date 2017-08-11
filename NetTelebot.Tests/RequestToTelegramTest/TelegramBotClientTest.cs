using System;
using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NetTelebot.Type.Keyboard;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToTelegramTest
{
    [TestFixture]
    internal class TelegramRealBotClientTest
    {
        private TelegramBotClient mTelegramBot;
        private long mChatGroupId;
        private long mChatSuperGroupId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetGroupChatBot();

            mChatGroupId = new TelegramBot().GetGroupChatId();
            mChatSuperGroupId = new TelegramBot().GetSuperGroupChatId();
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetMe"/>.
        /// </summary>
        [Test]
        public void GetMeTest()
        {
            MeInfo getMe = mTelegramBot.GetMe();

            Console.WriteLine(
                "\nid: " + getMe.Id +
                "\nFirstName: " + getMe.FirstName +
                "\nLastName: " + getMe.LastName +
                "\nUserName: " + getMe.UserName +
                "\nLanguageCode: " + getMe.LanguageCode +
                "\nOk: " + getMe.Ok);

            Assert.AreEqual(getMe.FirstName, "NetTelebotTestedBot");
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to group chat id.
        /// </summary>
        [Test]
        public void SendMessageToChatTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatGroupId, "Test");

            Console.WriteLine(
                "\n id " + sendMessage.Result.Chat.Id +
                "\n type " + sendMessage.Result.Chat.Type +
                "\n title " + sendMessage.Result.Chat.Title +
                "\n username " + sendMessage.Result.Chat.Username +
                "\n firstname " + sendMessage.Result.Chat.FirstName +
                "\n lastaname " + sendMessage.Result.Chat.LastName +
                "\n All members are administrator " + sendMessage.Result.Chat.AllMembersAreAdministrators +
                "\n Photo " + sendMessage.Result.Chat.Photo +
                "\n description " + sendMessage.Result.Chat.Description +
                "\n invite link" + sendMessage.Result.Chat.InviteLink
                );

            Assert.AreEqual(sendMessage.Result.Chat.Id, mChatGroupId);
            Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.@group);
            Assert.IsTrue(sendMessage.Result.Chat.AllMembersAreAdministrators);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to supergroup chat id.
        /// </summary>
        [Test]
        public void SendMessageToSuperGroupTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatSuperGroupId, "Test");

            Console.WriteLine(
                "\n id " + sendMessage.Result.Chat.Id +
                "\n type " + sendMessage.Result.Chat.Type +
                "\n title " + sendMessage.Result.Chat.Title +
                "\n username " + sendMessage.Result.Chat.Username +
                "\n firstname " + sendMessage.Result.Chat.FirstName +
                "\n lastaname " + sendMessage.Result.Chat.LastName +
                "\n All members are administrator " + sendMessage.Result.Chat.AllMembersAreAdministrators +
                "\n Photo " + sendMessage.Result.Chat.Photo +
                "\n description " + sendMessage.Result.Chat.Description +
                "\n invite link" + sendMessage.Result.Chat.InviteLink
                );

            Assert.AreEqual(sendMessage.Result.Chat.Id, mChatSuperGroupId);
            Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.supergroup);
            Assert.IsFalse(sendMessage.Result.Chat.AllMembersAreAdministrators);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to @shannelname chat id.
        /// </summary>
        [Test]
        public void SendMessageToPublicChannelTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage("@telebotTestChannel", "Test");

            Console.WriteLine(
                "\n id " + sendMessage.Result.Chat.Id +
                "\n type " + sendMessage.Result.Chat.Type +
                "\n title " + sendMessage.Result.Chat.Title +
                "\n username " + sendMessage.Result.Chat.Username +
                "\n firstname " + sendMessage.Result.Chat.FirstName +
                "\n lastaname " + sendMessage.Result.Chat.LastName +
                "\n All members are administrator " + sendMessage.Result.Chat.AllMembersAreAdministrators +
                "\n Photo " + sendMessage.Result.Chat.Photo +
                "\n description " + sendMessage.Result.Chat.Description +
                "\n invite link" + sendMessage.Result.Chat.InviteLink
                );

            Assert.IsInstanceOf<long>(sendMessage.Result.Chat.Id);
            Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.channel);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendLocation"/>.
        /// </summary>
        [Test]
        public void SendLocationTest()
        {
            const float latitude = 1.00000095f;
            const float longitude = 1.00000203f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatGroupId, latitude, longitude);

            Assert.AreEqual(sendLocation.Result.Location.Latitude, latitude);
            Assert.AreEqual(sendLocation.Result.Location.Longitude, longitude);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.LeaveChat"/>.
        /// </summary>
        [Test, Ignore("Do not use. Leave bot from group")]
        public void LeaveChatTest()
        {
            BooleanResult leaveChat = mTelegramBot.LeaveChat(mChatGroupId);

            Assert.True(leaveChat.Ok);
            Assert.True(leaveChat.Result);
        }

        [Test]
        public void SendInlineKeyboardToGroupTest()
        {

            InlineKeyboardButton[] lines1 =
            {
                new InlineKeyboardButton {Text = "AboutInline", Url = "https://core.telegram.org/bots/api#inlinekeyboardmarkup"},
                new InlineKeyboardButton {Text = "GoToRepo", Url = "https://github.com/themehrdad/NetTelebot"},
            };

            InlineKeyboardButton[] lines2 =
            {
                new InlineKeyboardButton {Text = "GoToGoogle", Url = "https://www.google.com", },
                new InlineKeyboardButton {Text = "GoToYouTube", Url = "https://www.youtube.com"}
            };

            InlineKeyboardButton[][] keyboard =
            {
                lines1, lines2
            };

            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup
            {
                Keyboard = keyboard,
            };

            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatGroupId, "Please press button", replyMarkup: inlineKeyboard);

            Assert.True(sendMessage.Ok);
        }

        [Test]
        public void GetChatFromGroupTest()
        {
            ChatInfoResult getChatResult = mTelegramBot.GetChat(mChatGroupId);

            Assert.True(getChatResult.Ok);
            Assert.AreEqual(getChatResult.Result.Id, mChatGroupId);
            Assert.AreEqual(getChatResult.Result.Type, ChatType.@group);
            Assert.AreEqual(getChatResult.Result.AllMembersAreAdministrators, true);

            Console.WriteLine("GetChat result: " +
                "\ngetChatResult.Result.Id " + getChatResult.Result.Id +
                "\ngetChatResult.Result.Title " + getChatResult.Result.Type +
                "\ngetChatResult.Result.Title " + getChatResult.Result.Title +
                "\ngetChatResult.Result.Username " + getChatResult.Result.Username +
                "\ngetChatResult.Result.FirstName " + getChatResult.Result.FirstName +
                "\ngetChatResult.Result.LastName " + getChatResult.Result.LastName +
                "\ngetChatResult.Result.AllMembersAreAdministrators " + getChatResult.Result.AllMembersAreAdministrators +
                "\ngetChatResult.Result.Photo " + getChatResult.Result.Photo +
                "\ngetChatResult.Result.Description " + getChatResult.Result.Description +
                "\ngetChatResult.Result.InviteLink " + getChatResult.Result.InviteLink
                );
        }
    }
}
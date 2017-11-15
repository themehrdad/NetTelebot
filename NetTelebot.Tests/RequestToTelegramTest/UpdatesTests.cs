using System;
using System.Threading;
using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToTelegramTest
{
    [TestFixture]
    internal class UpdatesTests
    {
        private TelegramBotClient mTelegramBot;
        private long? mChatGroupId;
        private long? mChatSuperGroupId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetSuperGroupChatBot();

            mChatGroupId = new TelegramBot().GetGroupChatId();
            mChatSuperGroupId = new TelegramBot().GetSuperGroupChatId();

            mTelegramBot.SendMessage(mChatSuperGroupId, "Test");
        }

        [Test]
        public void AllowedUpdatesTest()
        {
            ConsoleUtlis.WriteConsoleLog("StartTest");
            AllowedUpdates[] allowedUpdateses =
           {
                //AllowedUpdates.Message,
                AllowedUpdates.EditedMessage,
                AllowedUpdates.ChannelPost,
                //AllowedUpdates.EditedChannelPost,
                //AllowedUpdates.InlineQuery,
                //AllowedUpdates.ChosenInlineResult,
                //AllowedUpdates.CallbackQuery,
                //AllowedUpdates.ShippingQuery,
                //AllowedUpdates.PreCheckoutQuery
            };

            mTelegramBot.SendMessage(mChatGroupId, "Test");

            var results = mTelegramBot.GetUpdates(allowedUpdates:allowedUpdateses);

            foreach (var result in results.Result)
            {
               Console.WriteLine("result "+ result.Message.Text);
            }
            //ConsoleUtlis.PrintResult(result.Result[0].Message);

            //SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatGroupId, "Test");
            


            /*Assert.Multiple(() =>
            {
                Assert.AreEqual(sendMessage.Result.Chat.Id, mChatGroupId);
                Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.@group);
                Assert.IsTrue(sendMessage.Result.Chat.AllMembersAreAdministrators);
            });*/
        }
    }
}

using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;

namespace NetTelebot.Tests.NullReferenceExceptionTest
{
    [TestFixture]
    internal class DiceInfoTest
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
        /// Checking for NullReferenceException when accessing <see cref="DiceInfo"/> fields
        /// </summary>
        [Test]
        public void TestAppealToEmptyDiceInfo()
        {
            SendMessageResult sendMessage = mTelegramBot.SendDice(mChatId);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                Assert.IsNotNull(sendMessage.Result.Dice);
                Assert.IsInstanceOf(typeof(DiceInfo), sendMessage.Result.Dice);
                Assert.IsNotEmpty(sendMessage.Result.Dice.Emoji);
                Assert.Greater(sendMessage.Result.Dice.Value, 0);
            });

            ConsoleUtlis.PrintResult(sendMessage);
        }

        /// <summary>
        /// Test different dice emoji types
        /// </summary>
        [Test]
        [TestCase("🎲")]
        [TestCase("🎯")]
        [TestCase("🏀")]
        [TestCase("⚽")]
        [TestCase("🎳")]
        [TestCase("🎰")]
        public void TestSendDiceWithDifferentEmoji(string emoji)
        {
            SendMessageResult sendMessage = mTelegramBot.SendDice(mChatId, emoji);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                Assert.IsNotNull(sendMessage.Result.Dice);
                Assert.AreEqual(emoji, sendMessage.Result.Dice.Emoji);
                Assert.Greater(sendMessage.Result.Dice.Value, 0);
            });

            ConsoleUtlis.PrintResult(sendMessage);
        }
    }
}

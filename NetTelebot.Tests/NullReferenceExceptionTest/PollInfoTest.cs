using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;

namespace NetTelebot.Tests.NullReferenceExceptionTest
{
    [TestFixture]
    internal class PollInfoTest
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
        /// Checking for NullReferenceException when accessing <see cref="PollInfo"/> fields
        /// </summary>
        [Test]
        public void TestAppealToEmptyPollInfo()
        {
            string[] options = { "Option 1", "Option 2", "Option 3" };
            SendMessageResult sendMessage = mTelegramBot.SendPoll(mChatId, "Test Question?", options);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                Assert.IsNotNull(sendMessage.Result.Poll);
                Assert.IsInstanceOf(typeof(PollInfo), sendMessage.Result.Poll);
                Assert.IsNotEmpty(sendMessage.Result.Poll.Id);
                Assert.AreEqual("Test Question?", sendMessage.Result.Poll.Question);
                Assert.AreEqual(3, sendMessage.Result.Poll.Options.Length);
                Assert.AreEqual(0, sendMessage.Result.Poll.TotalVoterCount);
                Assert.IsFalse(sendMessage.Result.Poll.IsClosed);
            });

            ConsoleUtlis.PrintResult(sendMessage);
        }

        /// <summary>
        /// Test quiz mode poll
        /// </summary>
        [Test]
        public void TestSendQuizPoll()
        {
            string[] options = { "Wrong 1", "Wrong 2", "Correct", "Wrong 3" };
            SendMessageResult sendMessage = mTelegramBot.SendPoll(
                mChatId,
                "What is the correct answer?",
                options,
                type: "quiz",
                correctOptionId: 2,
                explanation: "The third option is correct!"
            );

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                Assert.IsNotNull(sendMessage.Result.Poll);
                Assert.AreEqual("quiz", sendMessage.Result.Poll.Type);
                Assert.AreEqual(2, sendMessage.Result.Poll.CorrectOptionId);
                Assert.AreEqual("The third option is correct!", sendMessage.Result.Poll.Explanation);
            });

            ConsoleUtlis.PrintResult(sendMessage);
        }

        /// <summary>
        /// Test poll with multiple answers
        /// </summary>
        [Test]
        public void TestSendPollWithMultipleAnswers()
        {
            string[] options = { "Choice A", "Choice B", "Choice C" };
            SendMessageResult sendMessage = mTelegramBot.SendPoll(
                mChatId,
                "Select all that apply:",
                options,
                allowsMultipleAnswers: true
            );

            Assert.Multiple(() =>
            {
                Assert.True(sendMessage.Ok);
                Assert.IsNotNull(sendMessage.Result.Poll);
                Assert.IsTrue(sendMessage.Result.Poll.AllowsMultipleAnswers);
            });

            ConsoleUtlis.PrintResult(sendMessage);
        }
    }
}

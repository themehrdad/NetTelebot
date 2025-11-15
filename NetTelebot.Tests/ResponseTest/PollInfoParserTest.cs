using NetTelebot.Type;
using NetTelebot.Tests.TypeTestObject;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class PollInfoParserTest
    {
        /// <summary>
        /// Test for <see cref="PollInfo"/> parse field for regular poll.
        /// </summary>
        [Test]
        public static void PollInfoRegularTest()
        {
            const string id = "5319054849019019520";
            const string question = "What is your favorite color?";
            const int totalVoterCount = 10;
            const bool isClosed = false;
            const bool isAnonymous = true;
            const string type = "regular";
            const bool allowsMultipleAnswers = false;

            JArray options = new JArray
            {
                PollOptionInfoObject.GetObject("Red", 3),
                PollOptionInfoObject.GetObject("Blue", 5),
                PollOptionInfoObject.GetObject("Green", 2)
            };

            JObject pollObject = PollInfoObject.GetObject(id, question, options, totalVoterCount,
                isClosed, isAnonymous, type, allowsMultipleAnswers);

            PollInfo pollInfo = new PollInfo(pollObject);

            Assert.AreEqual(id, pollInfo.Id);
            Assert.AreEqual(question, pollInfo.Question);
            Assert.AreEqual(3, pollInfo.Options.Length);
            Assert.AreEqual(totalVoterCount, pollInfo.TotalVoterCount);
            Assert.AreEqual(isClosed, pollInfo.IsClosed);
            Assert.AreEqual(isAnonymous, pollInfo.IsAnonymous);
            Assert.AreEqual(type, pollInfo.Type);
            Assert.AreEqual(allowsMultipleAnswers, pollInfo.AllowsMultipleAnswers);

            // Test option values
            Assert.AreEqual("Red", pollInfo.Options[0].Text);
            Assert.AreEqual(3, pollInfo.Options[0].VoterCount);
            Assert.AreEqual("Blue", pollInfo.Options[1].Text);
            Assert.AreEqual(5, pollInfo.Options[1].VoterCount);
            Assert.AreEqual("Green", pollInfo.Options[2].Text);
            Assert.AreEqual(2, pollInfo.Options[2].VoterCount);
        }

        /// <summary>
        /// Test for <see cref="PollInfo"/> parse field for quiz mode poll.
        /// </summary>
        [Test]
        public static void PollInfoQuizTest()
        {
            const string id = "5319054849019019521";
            const string question = "What is 2+2?";
            const int totalVoterCount = 15;
            const bool isClosed = true;
            const bool isAnonymous = true;
            const string type = "quiz";
            const bool allowsMultipleAnswers = false;
            const int correctOptionId = 2;
            const string explanation = "The correct answer is 4!";

            JArray options = new JArray
            {
                PollOptionInfoObject.GetObject("3", 2),
                PollOptionInfoObject.GetObject("5", 3),
                PollOptionInfoObject.GetObject("4", 10)
            };

            JObject pollObject = PollInfoObject.GetObject(id, question, options, totalVoterCount,
                isClosed, isAnonymous, type, allowsMultipleAnswers, correctOptionId, explanation);

            PollInfo pollInfo = new PollInfo(pollObject);

            Assert.AreEqual(id, pollInfo.Id);
            Assert.AreEqual(question, pollInfo.Question);
            Assert.AreEqual(3, pollInfo.Options.Length);
            Assert.AreEqual(totalVoterCount, pollInfo.TotalVoterCount);
            Assert.AreEqual(isClosed, pollInfo.IsClosed);
            Assert.AreEqual(isAnonymous, pollInfo.IsAnonymous);
            Assert.AreEqual(type, pollInfo.Type);
            Assert.AreEqual(allowsMultipleAnswers, pollInfo.AllowsMultipleAnswers);
            Assert.AreEqual(correctOptionId, pollInfo.CorrectOptionId);
            Assert.AreEqual(explanation, pollInfo.Explanation);
        }

        /// <summary>
        /// Test for <see cref="PollOptionInfo"/> parse field.
        /// </summary>
        [Test]
        public static void PollOptionInfoTest()
        {
            const string text = "Option A";
            const int voterCount = 42;

            JObject optionObject = PollOptionInfoObject.GetObject(text, voterCount);
            PollOptionInfo optionInfo = new PollOptionInfo(optionObject);

            Assert.AreEqual(text, optionInfo.Text);
            Assert.AreEqual(voterCount, optionInfo.VoterCount);
        }
    }
}

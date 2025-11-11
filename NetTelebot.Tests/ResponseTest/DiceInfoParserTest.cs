using NetTelebot.Type;
using NetTelebot.Tests.TypeTestObject;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class DiceInfoParserTest
    {
        /// <summary>
        /// Test for <see cref="DiceInfo"/> parse field.
        /// </summary>
        [Test]
        public static void DiceInfoTest()
        {
            const string emoji = "🎲";
            const int value = 4;

            JObject diceObject = DiceInfoObject.GetObject(emoji, value);
            DiceInfo diceInfo = new DiceInfo(diceObject);

            Assert.AreEqual(emoji, diceInfo.Emoji);
            Assert.AreEqual(value, diceInfo.Value);
        }

        /// <summary>
        /// Test for different emoji types
        /// </summary>
        [Test]
        [TestCase("🎲", 3)]
        [TestCase("🎯", 5)]
        [TestCase("🏀", 4)]
        [TestCase("⚽", 2)]
        [TestCase("🎳", 6)]
        [TestCase("🎰", 32)]
        public static void DiceInfoVariousEmojiTest(string emoji, int value)
        {
            JObject diceObject = DiceInfoObject.GetObject(emoji, value);
            DiceInfo diceInfo = new DiceInfo(diceObject);

            Assert.AreEqual(emoji, diceInfo.Emoji);
            Assert.AreEqual(value, diceInfo.Value);
        }
    }
}

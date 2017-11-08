using System;
using NetTelebot.BotEnum;
using NetTelebot.Extension;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    internal static class UtilityExtensionTest
    {
        [Test]
        public static void ToDateTimeTest()
        {
            DateTime timeZoneOffset = new DateTime(1970, 1, 1, 0, 0, 0);

            const long zeroDateTime = 0;

            Assert.AreEqual(zeroDateTime.ToDateTime(), timeZoneOffset.ToLocalTime());
        }

        [Test]
        public static void ToDateTimeAfter2038YearTest()
        {
            DateTime timeZoneOffset = new DateTime(2047, 07, 27);

            const long dateTime = 2447798400;

            Assert.AreEqual(dateTime.ToDateTime(), timeZoneOffset.ToLocalTime());
        }

        [Test]
        public static void ToUnixTimeTest()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            Assert.AreEqual(0, dateTime.ToUnixTime());
        }

        [Test]
        public static void ToUnixTimeAfter2038YearTest()
        {
            DateTime dateTime = new DateTime(2047, 07, 27);
            Assert.AreEqual(2447798400, dateTime.ToUnixTime());
        }

        [Test]
        public static void ToEnumCheckExistValueTest()
        {
            Assert.AreEqual("AAA".ToEnum<TestStruct>(), TestStruct.AAA);
            Assert.AreEqual("BBB".ToEnum<TestStruct>(), TestStruct.BBB);
            Assert.AreEqual("ccc".ToEnum<TestStruct>(), TestStruct.ccc);
            Assert.AreEqual("eEe".ToEnum<TestStruct>(), TestStruct.eEe);
        }

        [Test]
        public static void ToEnumCheckEmptyValueTest()
        {
            Assert.AreEqual("aAAa".ToEnum<TestStruct>(), null);
        }


        private enum TestStruct
        {
            /// <summary>
            /// The private
            /// </summary>
            AAA,

            /// <summary>
            /// The group
            /// </summary>
            BBB,

            /// <summary>
            /// The supergroup
            /// </summary>
            ccc,

            /// <summary>
            /// The channel
            /// </summary>
            eEe
        }

        [Test]
        public static void AllowedUpdateToJarray()
        {
            AllowedUpdates[] allowedUpdateses =
            {
                AllowedUpdates.Message,
                AllowedUpdates.EditedMessage, 
                AllowedUpdates.ChannelPost,
                AllowedUpdates.EditedChannelPost, 
                AllowedUpdates.InlineQuery, 
                AllowedUpdates.ChosenInlineResult, 
                AllowedUpdates.CallbackQuery, 
                AllowedUpdates.ShippingQuery, 
                AllowedUpdates.PreCheckoutQuery
            };

            Assert.AreEqual("[\r\n  \"message\",\r\n  " +
                            "\"edited_message\",\r\n  " +
                            "\"channel_post\",\r\n  " +
                            "\"edited_channel_post\",\r\n  " +
                            "\"inline_query\",\r\n  " +
                            "\"chosen_inline_result\",\r\n  " +
                            "\"callback_query\",\r\n  " +
                            "\"shipping_query\",\r\n  " +
                            "\"pre_checkout_query\"\r\n]", allowedUpdateses.ToJarray());
        }

    }
}
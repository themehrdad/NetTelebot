using System;
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
    }
}
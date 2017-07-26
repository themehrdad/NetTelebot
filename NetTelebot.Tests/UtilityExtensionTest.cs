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

            Assert.AreEqual(0.ToDateTime(), timeZoneOffset.ToLocalTime());
        }
    }
}
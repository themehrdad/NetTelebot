using System;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    public class UtilityExtensionTest
    {
        [Test]
        public void ToDateTimeTest()
        {
            DateTime timeZoneOffset = new DateTime(1970, 1, 1, 0, 0, 0);

            Assert.AreEqual(0.ToDateTime(), timeZoneOffset.ToLocalTime());
        }
    }
}
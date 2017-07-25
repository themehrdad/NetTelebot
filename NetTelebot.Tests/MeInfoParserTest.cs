using NetTelebot.Tests.TypeTestObject;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    internal static class MeInfoParserTest
    {
        /// <summary>
        /// Test for <see cref="MeInfo"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoFromTest()
        {
            const bool ok = true;
            const int id = 1000;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            dynamic meInfoObject = MeInfoObject.GetObject(ok, id, firstName, lastName, username, languageCode);

            MeInfo meInfo = new MeInfo(meInfoObject);

            Assert.AreEqual(meInfo.Ok, ok);
            Assert.AreEqual(meInfo.Id, id);
            Assert.AreEqual(meInfo.FirstName, firstName);
            Assert.AreEqual(meInfo.LastName, lastName);
            Assert.AreEqual(meInfo.UserName, username);
            Assert.AreEqual(meInfo.LanguageCode, languageCode);
        }
    }
}

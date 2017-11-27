using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class UserInfoParserTest
    {
        /// <summary>
        /// Test for <see cref="UserInfoResult"/> parse field.
        /// </summary>
        [Test]
        public static void UserInfoResultTest()
        {
            const bool ok = true;
            const int id = 1000;
            const bool isBot = false;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";

            JObject userObject = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            dynamic userInfoResultObject = UserInfoResultObject.GetObject(ok, userObject);

            UserInfoResult userInfo = new UserInfoResult(userInfoResultObject.ToString());

            Assert.AreEqual(ok, userInfo.Ok);
            Assert.AreEqual(id, userInfo.Result.Id);
            Assert.AreEqual(isBot, userInfo.Result.IsBot);
            Assert.AreEqual(firstName, userInfo.Result.FirstName);
            Assert.AreEqual(lastName, userInfo.Result.LastName);
            Assert.AreEqual(username, userInfo.Result.UserName);
            Assert.AreEqual(languageCode, userInfo.Result.LanguageCode);
        }
    }
}

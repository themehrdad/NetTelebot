using System;
using NetTelebot.BotEnum;
using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class ChatMemberInfoResultParserTest
    {
        /// <summary>
        /// Test for <see cref="ChatMemberInfo"/> parse field.
        /// </summary>
        [Test]
        public static void UserInfoResultTest()
        {
            const int id = 1000;
            const bool isBot = true;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";
            JObject userObject = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            const string status = "creator";

            JObject chatMember = ChatMemberInfoObject.GetObject(userObject, status, 0, true, true,
                true, true, true, true, true, true, true, true, true, true, true);

            dynamic chatMemberResultObject = ChatMemberInfoResultObject.GetObject(true, chatMember);

            ChatMemberInfoResult chatMemberInfoResult = new ChatMemberInfoResult(chatMemberResultObject.ToString());

            Assert.Multiple(() =>
            {
                Assert.True(chatMemberInfoResult.Ok);

                Assert.AreEqual(id, chatMemberInfoResult.Result.User.Id);
                Assert.AreEqual(isBot, chatMemberInfoResult.Result.User.IsBot);
                Assert.AreEqual(firstName, chatMemberInfoResult.Result.User.FirstName);
                Assert.AreEqual(lastName, chatMemberInfoResult.Result.User.LastName);
                Assert.AreEqual(username, chatMemberInfoResult.Result.User.UserName);
                Assert.AreEqual(languageCode, chatMemberInfoResult.Result.User.LanguageCode);

                Assert.AreEqual(Status.creator, chatMemberInfoResult.Result.Status);
                Assert.AreEqual(0, chatMemberInfoResult.Result.UntilDateUnix);
                Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime(),
                    chatMemberInfoResult.Result.UntilDate);
                Assert.True(chatMemberInfoResult.Result.CanBeEdited);
                Assert.True(chatMemberInfoResult.Result.CanChangeInfo);
                Assert.True(chatMemberInfoResult.Result.CanPostMessages);
                Assert.True(chatMemberInfoResult.Result.CanEditMessages);
                Assert.True(chatMemberInfoResult.Result.CanDeleteMessages);
                Assert.True(chatMemberInfoResult.Result.CanInviteUsers);
                Assert.True(chatMemberInfoResult.Result.CanRestrictMembers);
                Assert.True(chatMemberInfoResult.Result.CanPinMessages);
                Assert.True(chatMemberInfoResult.Result.CanPromoteMembers);
                Assert.True(chatMemberInfoResult.Result.CanSendMessages);
                Assert.True(chatMemberInfoResult.Result.CanSendMediaMessages);
                Assert.True(chatMemberInfoResult.Result.CanSendOtherMessages);
                Assert.True(chatMemberInfoResult.Result.CanAddWebPagePreviews);
            });
        }
    }
}

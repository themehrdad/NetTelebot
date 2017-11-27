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
    internal static class ChatMembersInfoResultParserTest
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


            dynamic chatMemberResultObject = ChatMembersInfoResultObject.GetObject(true, new JArray(chatMember));

            ChatMembersInfoResult chatMemberInfoResult = new ChatMembersInfoResult(chatMemberResultObject.ToString());

            Assert.Multiple(() =>
            {
                Assert.True(chatMemberInfoResult.Ok);

                Assert.AreEqual(id, chatMemberInfoResult.Result[0].User.Id);
                Assert.AreEqual(isBot, chatMemberInfoResult.Result[0].User.IsBot);
                Assert.AreEqual(firstName, chatMemberInfoResult.Result[0].User.FirstName);
                Assert.AreEqual(lastName, chatMemberInfoResult.Result[0].User.LastName);
                Assert.AreEqual(username, chatMemberInfoResult.Result[0].User.UserName);
                Assert.AreEqual(languageCode, chatMemberInfoResult.Result[0].User.LanguageCode);

                Assert.AreEqual(Status.creator, chatMemberInfoResult.Result[0].Status);
                Assert.AreEqual(0, chatMemberInfoResult.Result[0].UntilDateUnix);
                Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime(),
                    chatMemberInfoResult.Result[0].UntilDate);
                Assert.True(chatMemberInfoResult.Result[0].CanBeEdited);
                Assert.True(chatMemberInfoResult.Result[0].CanChangeInfo);
                Assert.True(chatMemberInfoResult.Result[0].CanPostMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanEditMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanDeleteMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanInviteUsers);
                Assert.True(chatMemberInfoResult.Result[0].CanRestrictMembers);
                Assert.True(chatMemberInfoResult.Result[0].CanPinMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanPromoteMembers);
                Assert.True(chatMemberInfoResult.Result[0].CanSendMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanSendMediaMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanSendOtherMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanAddWebPagePreviews);
            });
        }

        /// <summary>
        /// Test for <see cref="Status"/>.
        /// </summary>
        [Test]
        public static void StatusEnumTest()
        {
            const int id = 1000;
            const bool isBot = true;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";
            JObject userObject = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);

            const string statusCreator = "creator";
            const string statusAdministrator = "administrator";
            const string statusKicked = "kicked";
            const string statusLeft = "left";
            const string statusMember = "member";
            const string statusRestricted = "restricted";
            
            //status creator
            JObject chatMember = ChatMemberInfoObject.GetObject(userObject, statusCreator);
            dynamic fileInfoResultObject = ChatMembersInfoResultObject.GetObject(true, new JArray(chatMember));
            ChatMembersInfoResult chatMemberInfoResult = new ChatMembersInfoResult(fileInfoResultObject.ToString());

            Assert.AreEqual(Status.creator, chatMemberInfoResult.Result[0].Status);

            //status administrator
            chatMember = ChatMemberInfoObject.GetObject(userObject, statusAdministrator);
            fileInfoResultObject = ChatMembersInfoResultObject.GetObject(true, new JArray(chatMember));
            chatMemberInfoResult = new ChatMembersInfoResult(fileInfoResultObject.ToString());

            Assert.AreEqual(Status.administrator, chatMemberInfoResult.Result[0].Status);

            //status kicked
            chatMember = ChatMemberInfoObject.GetObject(userObject, statusKicked);
            fileInfoResultObject = ChatMembersInfoResultObject.GetObject(true, new JArray(chatMember));
            chatMemberInfoResult = new ChatMembersInfoResult(fileInfoResultObject.ToString());

            Assert.AreEqual(Status.kicked, chatMemberInfoResult.Result[0].Status);

            //status left
            chatMember = ChatMemberInfoObject.GetObject(userObject, statusLeft);
            fileInfoResultObject = ChatMembersInfoResultObject.GetObject(true, new JArray(chatMember));
            chatMemberInfoResult = new ChatMembersInfoResult(fileInfoResultObject.ToString());
            
            Assert.AreEqual(Status.left, chatMemberInfoResult.Result[0].Status);

            //status member
            chatMember = ChatMemberInfoObject.GetObject(userObject, statusMember);
            fileInfoResultObject = ChatMembersInfoResultObject.GetObject(true, new JArray(chatMember));
            chatMemberInfoResult = new ChatMembersInfoResult(fileInfoResultObject.ToString());

            Assert.AreEqual(Status.member, chatMemberInfoResult.Result[0].Status);

            //status restricted
            chatMember = ChatMemberInfoObject.GetObject(userObject, statusRestricted);
            fileInfoResultObject = ChatMembersInfoResultObject.GetObject(true, new JArray(chatMember));
            chatMemberInfoResult = new ChatMembersInfoResult(fileInfoResultObject.ToString());

            Assert.AreEqual(Status.restricted, chatMemberInfoResult.Result[0].Status);
        }
    }
}

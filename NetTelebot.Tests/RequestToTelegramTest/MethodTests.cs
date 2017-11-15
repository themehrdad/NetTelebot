using System;
using System.IO;
using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToTelegramTest
{
    [TestFixture]
    internal class TelegramRealBotClientTest
    {
        private TelegramBotClient mTelegramBot;
        private long? mChatGroupId;
        private long? mChatSuperGroupId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetGroupChatBot();

            mChatGroupId = new TelegramBot().GetGroupChatId();
            mChatSuperGroupId = new TelegramBot().GetSuperGroupChatId();
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetsMe"/>.
        /// </summary>
        [Test]
        public void GetsMeTest()
        {
            UserInfoResult getMe = mTelegramBot.GetsMe();

            ConsoleUtlis.PrintResult(getMe.Result);

            Assert.Multiple(() =>
            {
                Assert.True(getMe.Ok);
                Assert.AreEqual(getMe.Result.FirstName, "NetTelebotTestedBot");
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to group chat id.
        /// </summary>
        [Test]
        public void SendMessageToChatTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatGroupId, "Test");

            ConsoleUtlis.PrintResult(sendMessage.Result.Chat);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(sendMessage.Result.Chat.Id, mChatGroupId);
                Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.@group);
                Assert.IsTrue(sendMessage.Result.Chat.AllMembersAreAdministrators);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to supergroup chat id.
        /// </summary>
        [Test]
        public void SendMessageToSuperGroupTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatSuperGroupId, "Test");

            ConsoleUtlis.PrintResult(sendMessage.Result.Chat);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(sendMessage.Result.Chat.Id, mChatSuperGroupId);
                Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.supergroup);
                Assert.IsFalse(sendMessage.Result.Chat.AllMembersAreAdministrators);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to @shannelname chat id.
        /// </summary>
        [Test]
        public void SendMessageToPublicChannelTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage("@telebotTestChannel", "Test");

            ConsoleUtlis.PrintResult(sendMessage.Result.Chat);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<long>(sendMessage.Result.Chat.Id);
                Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.channel);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendLocation"/>.
        /// </summary>
        [Test]
        public void SendLocationTest()
        {
            const float latitude = 1.00000095f;
            const float longitude = 1.00000203f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatGroupId, latitude, longitude);

            ConsoleUtlis.PrintResult(sendLocation.Result.Location);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(sendLocation.Result.Location.Latitude, latitude);
                Assert.AreEqual(sendLocation.Result.Location.Longitude, longitude);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetChat"/>.
        /// </summary>

        [Test]
        public void GetChatFromGroupTest()
        {
            ChatInfoResult getChatResult = mTelegramBot.GetChat(mChatGroupId);

            ConsoleUtlis.PrintResult(getChatResult.Result);

            Assert.Multiple(() =>
            {
                Assert.True(getChatResult.Ok);
                Assert.AreEqual(getChatResult.Result.Id, mChatGroupId);
                Assert.AreEqual(getChatResult.Result.Type, ChatType.@group);
                Assert.AreEqual(getChatResult.Result.AllMembersAreAdministrators, true);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetChatMembersCount"/>.
        /// </summary>
        [Test]
        public void GetChatMemberCountTest()
        {
            IntegerResult getChatMemberCount = mTelegramBot.GetChatMembersCount(mChatGroupId);

            ConsoleUtlis.PrintResult(getChatMemberCount);

            Assert.Multiple(() =>
            {
                Assert.True(getChatMemberCount.Ok);
                Assert.AreEqual(3, getChatMemberCount.Result);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendPhoto"/> with new file.
        /// </summary>
        [Test]
        public void SendPhotoAsFileTest()
        {
            NewFile photo = new NewFile
            {
                FileContent = File.ReadAllBytes(GetProjectPath() + @"\Images\Logo\logo-500.png"),
                FileName = "logo-500.png"
            };

            SendMessageResult sendMessage = mTelegramBot.SendPhoto("@telebotTestChannel", photo);

            Assert.Multiple(() =>
            {
                Assert.NotNull(sendMessage.Result.Photo[0].FileId);
                Assert.NotNull(sendMessage.Result.Photo[0].FileSize);
                Assert.NotNull(sendMessage.Result.Photo[0].Height);
                Assert.NotNull(sendMessage.Result.Photo[0].Width);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendPhoto"/> with ExitingFile.
        /// </summary>
        [Test]
        public void SendPhotoAsFileIdTest()
        {
            ExistingFile existing = new ExistingFile
            {
                FileId = "AgADAgADaagxG-_buUmX76y6cGpluPA7Sw0ABJFnmSfjBBfrk5QPAAEC"
            };

            SendMessageResult sendMessage = mTelegramBot.SendPhoto("@telebotTestChannel", existing);

            Console.WriteLine(sendMessage.Result.Photo[0].FileId);

            Assert.AreEqual("AgADAgADaagxG-_buUmX76y6cGpluPA7Sw0ABJFnmSfjBBfrk5QPAAEC", sendMessage.Result.Photo[0].FileId);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendPhoto"/> with photo by url.
        /// </summary>
        [Test]
        public void SendPhotoAsUrlTest()
        {
            ExistingFile existing = new ExistingFile
            {
                Url = "https://proglib.io/wp-content/uploads/2017/07/telegram-bot-na-Python-s-ispolzovaniem-tolko-requests.jpg"
            };

            SendMessageResult sendMessage = mTelegramBot.SendPhoto("@telebotTestChannel", existing);

            Assert.AreEqual("AgADBAADEsg4GwoeZAcwyq9C0fVhKANXvRkABDMpTvt2GGzZ-2UEAAEC", sendMessage.Result.Photo[0].FileId);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetFile"/> with new file.
        /// </summary>
        [Test]
        public void GetFileTest()
        {
            const string fileId = "AgADBAADEsg4GwoeZAcwyq9C0fVhKANXvRkABDMpTvt2GGzZ-2UEAAEC";
            FileInfoResult sendMessage = mTelegramBot.GetFile(fileId);

            Assert.True(sendMessage.Ok);
            Assert.AreEqual(fileId, sendMessage.Result.FileId);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetChatAdministrators"/>.
        /// </summary>
        [Test]
        public void GetChatAdministratorTest()
        {
            ChatMembersInfoResult chatAdministrators = mTelegramBot.GetChatAdministrators("@telebotTestChannel");

            UserInfo user = mTelegramBot.GetsMe().Result;
            ChatMemberInfo result = chatAdministrators.Result[0];

            CheckChatMember(user, result);
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetChatMember"/>.
        /// </summary>
        [Test]
        public void GetChatMembersTest()
        {
            UserInfo user = mTelegramBot.GetsMe().Result;

            ChatMemberInfoResult chatMember = mTelegramBot.GetChatMember("@telebotTestChannel", user.Id);

            ChatMemberInfo result = chatMember.Result;

            CheckChatMember(user, result);
        }

        private static void CheckChatMember(UserInfo expectedUser, ChatMemberInfo actualMember)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedUser.Id, actualMember.User.Id);
                Assert.AreEqual(expectedUser.UserName, actualMember.User.UserName);
                Assert.AreEqual(expectedUser.FirstName, actualMember.User.FirstName);
                Assert.AreEqual(expectedUser.LastName, actualMember.User.LastName);

                Assert.False(actualMember.CanBeEdited);
                Assert.True(actualMember.CanChangeInfo);
                Assert.True(actualMember.CanPostMessages);
                Assert.True(actualMember.CanEditMessages);
                Assert.True(actualMember.CanDeleteMessages);
                Assert.True(actualMember.CanInviteUsers);
                Assert.True(actualMember.CanEditMessages);
                Assert.True(actualMember.CanRestrictMembers);
                Assert.False(actualMember.CanPinMessages);
                Assert.False(actualMember.CanPromoteMembers);
                Assert.False(actualMember.CanSendMessages);
                Assert.False(actualMember.CanSendMediaMessages);
                Assert.False(actualMember.CanSendOtherMessages);
                Assert.False(actualMember.CanAddWebPagePreviews);
            });
        }

        private static string GetProjectPath()
        {
            return  AppDomain.CurrentDomain.BaseDirectory.Replace(@"\NetTelebot.Tests\bin\Debug", string.Empty);
        }
    }
}
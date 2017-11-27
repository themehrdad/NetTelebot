using System;
using System.Linq;
using Mock4Net.Core;
using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Tests.MockServers;
using NetTelebot.Type;
using NetTelebot.Type.Keyboard;
using NetTelebot.Type.Payment;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.RequestToMockTest
{
    [TestFixture]
    internal class ClientTest
    {

        private const int mOkServerPort = 8091;
        private const int mBadServerPort = 8092;

        private readonly TelegramBotClient mBotOkResponse = new TelegramBotClient
        {
            Token = "Token",
            RestClient = new RestClient("http://localhost:" + mOkServerPort)
        };

        private readonly TelegramBotClient mBotBadResponse = new TelegramBotClient
        {
            Token = "Token",
            RestClient = new RestClient("http://localhost:" + mBadServerPort)
        };

        [OneTimeSetUp]
        public static void OnStart()
        {
            MockServer.Start(mOkServerPort, mBadServerPort);
        }

        [OneTimeTearDown]
        public static void OnStop()
        {
            MockServer.Stop();
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendMessage"/>.
        /// </summary>
        [Test]
        public void SendMessageTest()
        {
            mBotOkResponse.SendMessage(123, "123", ParseMode.HTML, false, false, 123, new ForceReplyMarkup());

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "text=123&parse_mode=HTML&" +
                                "disable_web_page_preview=False&" +
                                "disable_notification=False&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendMessage", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () => mBotBadResponse.SendMessage(123, "123", ParseMode.HTML, false, false, 123,
                        new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.ForwardMessage"/>.
        /// </summary>
        [Test]
        public void ForwardMessageTest()
        {
            mBotOkResponse.ForwardMessage(123, 123, 123, true);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/forwardMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "from_chat_id=123&" +
                                "disable_notification=True&" +
                                "message_id=123", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/forwardMessage", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.ForwardMessage(123, 123, 123, true));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendPhoto"/>.
        /// </summary>
        [Test]
        public void SendPhotoTest()
        {
            mBotOkResponse.SendPhoto(123, new ExistingFile {FileId = "123", Url = "url"}, "caption", false, 123,
                new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendPhoto").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "photo=123&" +
                                "caption=caption&" +
                                "disable_notification=False&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendPhoto", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.SendPhoto(123, new ExistingFile {FileId = "123"},
                    "caption", false, 123, new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendAudio"/>.
        /// </summary>
        [Test]
        public void SendAudioTest()
        {
            mBotOkResponse.SendAudio(123, new ExistingFile {FileId = "123"}, "caption", 123, "performer",
                "title", true, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendAudio").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "audio=123&" +
                                "caption=caption&" +
                                "duration=123&" +
                                "performer=performer&" +
                                "title=title&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendAudio", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () => mBotBadResponse.SendAudio(123, new ExistingFile {FileId = "123"}, "caption", 123, "performer",
                        "title", true, 123, new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendDocument"/>.
        /// </summary>
        [Test]
        public void SendDocumentTest()
        {
            mBotOkResponse.SendDocument(123, new ExistingFile {FileId = "123"}, "caption", true, 123,
                new ForceReplyMarkup());

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendDocument").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "document=123&" +
                                "caption=caption&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendDocument", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.SendDocument(123, new ExistingFile {FileId = "123"},
                    "caption", true, 123, new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendSticker"/>.
        /// </summary>
        [Test]
        public void SendStickerTest()
        {
            mBotOkResponse.SendSticker(123, new ExistingFile {FileId = "123"}, true, 123, new ForceReplyMarkup());

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendSticker").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "sticker=123&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendSticker", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.SendSticker(123, new ExistingFile {FileId = "123"},
                    true, 123, new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendVideo"/>.
        /// </summary>
        [Test]
        public void SendVideoTest()
        {
            mBotOkResponse.SendVideo(123, new ExistingFile {FileId = "123"}, 123, 123, 123, "caption", true, 123,
                new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendVideo").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "video=123&" +
                                "duration=123&" +
                                "width=123&" +
                                "height=123&" +
                                "caption=caption&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendVideo", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(() => mBotBadResponse.SendVideo(123, new ExistingFile {FileId = "123"},
                    123, 123, 123, "caption", true, 123, new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendVoice"/>.
        /// </summary>
        [Test]
        public void SendVoiceTest()
        {
            mBotOkResponse.SendVoice(123, new ExistingFile {FileId = "123"}, "TestCaption", 123, true, 123,
                new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendVoice").UsingPost());

            ConsoleUtlis.PrintResult(request);


            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "voice=123&" +
                                "caption=TestCaption&" +
                                "duration=123&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendVoice", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(
                    () =>
                        mBotBadResponse.SendVoice(123, new ExistingFile {FileId = "123"}, "TestCaption", 123, true, 123,
                            new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendVideoNote"/>.
        /// </summary>
        [Test]
        public void SendVideoNoteTest()
        {
            mBotOkResponse.SendVideoNote(123, new ExistingFile {FileId = "123"}, 123, 123, true, 123,
                new ForceReplyMarkup());

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendVideoNote").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "video_note=123&" +
                                "duration=123&" +
                                "length=123&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendVideoNote", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(() => mBotBadResponse.SendVideoNote(123, new ExistingFile {FileId = "123"},
                    123, 123, true, 123, new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendLocation"/>.
        /// </summary>
        [Test]
        public void SendLocationTest()
        {
            mBotOkResponse.SendLocation(123, 1.0f, 1.0f, true, 123, new ForceReplyMarkup());

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendLocation").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "latitude=1&" +
                                "longitude=1&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendLocation", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () => mBotBadResponse.SendLocation(123, 1.0f, 1.0f, true, 123, new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendVenue"/>.
        /// </summary>
        [Test]
        public void SendVenueTest()
        {
            mBotOkResponse.SendVenue(123, 0, 0, "TestTitle", "TestAddress", "TestFoursquareId", true, 123,
                new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendVenue").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "latitude=0&" +
                                "longitude=0&" +
                                "title=TestTitle&address=TestAddress&" +
                                "foursquare_id=TestFoursquareId&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendVenue", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () =>
                        mBotBadResponse.SendVenue(123, 0, 0, "TestTitle", "TestAddress", "TestFoursquareId", true, 123,
                            new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendContact"/>.
        /// </summary>
        [Test]
        public void SendContactTest()
        {
            mBotOkResponse.SendContact(123, "123", "firstName", "lastName", true, 123, new ForceReplyMarkup());

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendContact").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "phone_number=123&" +
                                "first_name=firstName&" +
                                "last_name=lastName&" +
                                "disable_notification=True&" +
                                "reply_to_message_id=123&" +
                                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D",
                    request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendContact", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () =>
                        mBotBadResponse.SendContact(123, "123", "firstName", "lastName", true, 123,
                            new ForceReplyMarkup()));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendChatAction"/>.
        /// </summary>
        [Test]
        public void SendChatActionTest()
        {
            //typing
            mBotOkResponse.SendChatAction(123, ChatActions.Typing);
            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=typing", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_photo
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_photo);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=upload_photo", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //record_video
            mBotOkResponse.SendChatAction(123, ChatActions.Record_video);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=record_video", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_video
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_video);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=upload_video", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //record_audio
            mBotOkResponse.SendChatAction(123, ChatActions.Record_audio);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=record_audio", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_audio
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_audio);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=upload_audio", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_document
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_document);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=upload_document", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //find_location
            mBotOkResponse.SendChatAction(123, ChatActions.Find_location);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=find_location", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //record_video_note
            mBotOkResponse.SendChatAction(123, ChatActions.Record_video_note);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=record_video_note", request.FirstOrDefault()?.Body);

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_video_note
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_video_note);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            ConsoleUtlis.PrintResult(request);
            Assert.AreEqual("chat_id=123&" +
                            "action=upload_video_note", request.FirstOrDefault()?.Body);


            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendChatAction");
            Assert.Throws<Exception>(() => mBotBadResponse.SendChatAction(123, ChatActions.Upload_video_note));
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.GetUserProfilePhotos"/>.
        /// </summary>
        [Test]
        public void GetUserProfilePhotosTest()
        {
            mBotOkResponse.GetUserProfilePhotos(123, 123, 10);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUserProfilePhotos").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("user_id=123&" +
                                "offset=123&" +
                                "limit=10", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/getUserProfilePhotos", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetUserProfilePhotos(123, 123, 10));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.KickChatMember"/>.
        /// </summary>
        [Test]
        public void KickChatMemberTest()
        {
            mBotOkResponse.KickChatMember(123, 123, new DateTime(2027, 07, 27));

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/kickChatMember").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "user_id=123&" +
                                "until_date=1816646400", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/kickChatMember", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.KickChatMember(123, 123, new DateTime(2027, 07, 27)));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.UnbanChatMember"/>.
        /// </summary>
        [Test]
        public void UnbanChatMemberTest()
        {
            mBotOkResponse.UnbanChatMember(123, 123);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/unbanChatMember").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123&" +
                                "user_id=123", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/unbanChatMember", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.UnbanChatMember(123, 123));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.LeaveChat"/>.
        /// </summary>
        [Test]
        public void LeaveChatTest()
        {
            mBotOkResponse.LeaveChat(123);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/leaveChat").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/leaveChat", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.LeaveChat(123));
            });
        }

        [Test]
        public void GetChatMembersCountTest()
        {
            mBotOkResponse.GetChatMembersCount(123);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getChatMembersCount").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/getChatMembersCount", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.LeaveChat(123));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.GetChat"/>.
        /// </summary>
        [Test]
        public void GetChatTest()
        {
            mBotOkResponse.GetChat(123);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getChat").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=123", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/getChat", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetChat(123));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.GetChat"/>.
        /// </summary>
        [Test]
        public void GetFileTest()
        {
            mBotOkResponse.GetFile("jksdfjlskdjlaf");

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getFile").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("file_id=jksdfjlskdjlaf", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/getFile", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetFile("jksdfjlskdjlaf"));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.GetChatAdministrators"/>.
        /// </summary>
        [Test]
        public void GetChatAdministratorsTest()
        {
            mBotOkResponse.GetChatAdministrators("testChatId");

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(
                    Requests.WithUrl("/botToken/getChatAdministrators").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=testChatId", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/getChatAdministrators", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetChatAdministrators("testChatId"));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.GetChatAdministrators"/>.
        /// </summary>
        [Test]
        public void AnswerCallbackQuery()
        {
            mBotOkResponse.AswerCallbackQuery("testCallbackQueryId", "TestText", true, "TestUrl", 123);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(
                    Requests.WithUrl("/botToken/answerCallbackQuery").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("callback_query_id=testCallbackQueryId&" +
                                "text=TestText&" +
                                "show_alert=True&" +
                                "url=TestUrl&" +
                                "cache_time=123", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/answerCallbackQuery", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () => mBotBadResponse.AswerCallbackQuery("testCallbackQueryId", "TestText", true, "TestUrl", 123));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.GetChatMember"/>.
        /// </summary>
        [Test]
        public void GetChatMemberTest()
        {
            mBotOkResponse.GetChatMember("testChatId", 123456);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getChatMember").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=testChatId&user_id=123456", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/getChatMember", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetChatMember("testChatId", 123456));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.AnswerShippingQuery"/>.
        /// </summary>
        [Test]
        public void AnswerShippingQueryTest()
        {
            ShippingOptionInfo shippingOption1 = new ShippingOptionInfo
            {
                Id = "idTest",
                Title = "titleTest",
                LabelPrice = new[]
                {
                    new LabeledPriceInfo {Label = "LableTest1", Amount = 123},
                    new LabeledPriceInfo {Label = "LabelTest2", Amount = 456}
                }
            };

            ShippingOptionInfo shippingOption2 = new ShippingOptionInfo
            {
                Id = "idTest",
                Title = "titleTest",
                LabelPrice = new[]
                {
                    new LabeledPriceInfo {Label = "LableTest3", Amount = 123},
                    new LabeledPriceInfo {Label = "LabelTest4", Amount = 456}
                }
            };

            ShippingOptionInfo[] shippingOption = {shippingOption1, shippingOption2};

            mBotOkResponse.AnswerShippingQuery("AnswerIdTest", false, shippingOption, "TestErrorMessage");

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/answerShippingQuery").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("shipping_query_id=AnswerIdTest&" +
                                "ok=False&" +
                                "shipping_options=%7B%0D%0A%20%20%22prices" +
                                "%22%3A%20%5B%0D%0A%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%22id" +
                                "%22%3A%20%22idTest%22%2C%0D%0A%20%20%20%20%20%20%22title" +
                                "%22%3A%20%22titleTest%22%2C%0D%0A%20%20%20%20%20%20%22prices" +
                                "%22%3A%20%5B%0D%0A%20%20%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%20%20%22label" +
                                "%22%3A%20%22LableTest1" +
                                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%20%20%22amount" +
                                "%22%3A%20123%0D%0A%20%20%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%20%20%22label" +
                                "%22%3A%20%22LabelTest2%22%2C%0D%0A%20%20%20%20%20%20%20%20%20%20%22amount" +
                                "%22%3A%20456%0D%0A%20%20%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%20%20%5D%0D%0A%20%20%20%20%7D%2C%0D%0A%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%22id" +
                                "%22%3A%20%22idTest%22%2C%0D%0A%20%20%20%20%20%20%22title%22%3A%20%22titleTest%22%2C%0D%0A%20%20%20%20%20%20%22prices" +
                                "%22%3A%20%5B%0D%0A%20%20%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%20%20%22label" +
                                "%22%3A%20%22LableTest3%22%2C%0D%0A%20%20%20%20%20%20%20%20%20%20%22amount" +
                                "%22%3A%20123%0D%0A%20%20%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%20%20%22label" +
                                "%22%3A%20%22LabelTest4%22%2C%0D%0A%20%20%20%20%20%20%20%20%20%20%22amount" +
                                "%22%3A%20456%0D%0A%20%20%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%20%20%5D%0D%0A%20%20%20%20%7D%0D%0A%20%20%5D%0D%0A%7D&" +
                                "error_message=TestErrorMessage", request.FirstOrDefault()?.Body);
                Assert.AreEqual("/botToken/answerShippingQuery", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () => mBotBadResponse.AnswerShippingQuery("AnswerIdTest", false, shippingOption, "TestErrorMessage"));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendInvoice"/>.
        /// </summary>
        [Test]
        public void SendInvoiceWithoutOptionalParametersTest()
        {
            MockServer.ServerOkResponse.ResetRequestLogs();

            var labelPrice = new[]
            {
                new LabeledPriceInfo {Label = "LableTest1", Amount = 123},
                new LabeledPriceInfo {Label = "LabelTest2", Amount = 456}
            };

            mBotOkResponse.SendInvoice("TestChatId", "TestTitle", "TestDescription", "TestPayload", "TestProviderToken",
                "TestStartParameter", Currency.USD, labelPrice);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendInvoice").UsingPost());
            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("chat_id=TestChatId&" +
                                "title=TestTitle&" +
                                "description=TestDescription&" +
                                "payload=TestPayload&" +
                                "provider_token=TestProviderToken&" +
                                "start_parameter=TestStartParameter&" +
                                "currency=USD&" +
                                "prices=%5B%0D%0A%20%20%7B%0D%0A%20%20%20%20%22label" +
                                "%22%3A%20%22LableTest1" +
                                "%22%2C%0D%0A%20%20%20%20%22amount" +
                                "%22%3A%20123" +
                                "%0D%0A%20%20%7D%2C%0D%0A%20%20%7B%0D%0A%20%20%20%20%22label" +
                                "%22%3A%20%22LabelTest2" +
                                "%22%2C%0D%0A%20%20%20%20%22amount" +
                                "%22%3A%20456%0D%0A%20%20%7D%0D%0A%5D&" +
                                "need_name=False&" +
                                "need_phone_number=False&" +
                                "need_email=False&" +
                                "need_shipping_address=False&" +
                                "is_flexible=False", request.FirstOrDefault()?.Body);
                Assert.AreEqual("/botToken/sendInvoice", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(
                    () =>
                        mBotBadResponse.SendInvoice("TestChatId", "TestTitle", "TestDescription", "TestPayload",
                            "TestProviderToken", "TestStartParameter", Currency.USD, labelPrice));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendInvoice"/>.
        /// </summary>
        [Test]
        public void SendInvoiceWithOptionalParametersTest()
        {
            MockServer.ServerOkResponse.ResetRequestLogs();

            var labelPrice = new[]
            {
                new LabeledPriceInfo {Label = "LableTest1", Amount = 123},
                new LabeledPriceInfo {Label = "LabelTest2", Amount = 456}
            };


            mBotOkResponse.SendInvoice("TestChatId", "TestTitle", "TestDescription", "TestPayload", "TestProviderToken",
                "TestStartParameter", Currency.USD, labelPrice, "TestPhotoUrl", 123, 456, 789, true, true, true, true,
                true, true, 123, new ForceReplyMarkup());

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendInvoice").UsingPost());
            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual("chat_id=TestChatId&" +
                            "title=TestTitle&" +
                            "description=TestDescription&" +
                            "payload=TestPayload&" +
                            "provider_token=TestProviderToken&" +
                            "start_parameter=TestStartParameter&" +
                            "currency=USD&" +
                            "prices=%5B%0D%0A%20%20%7B%0D%0A%20%20%20%20%22label" +
                            "%22%3A%20%22LableTest1" +
                            "%22%2C%0D%0A%20%20%20%20%22amount" +
                            "%22%3A%20123%0D%0A%20%20%7D%2C%0D%0A%20%20%7B%0D%0A%20%20%20%20%22label" +
                            "%22%3A%20%22LabelTest" +
                            "2%22%2C%0D%0A%20%20%20%20%22amount" +
                            "%22%3A%20456%0D%0A%20%20%7D%0D%0A%5D&photo_url=TestPhotoUrl&" +
                            "photo_size=123&" +
                            "photo_width=456&" +
                            "photo_height=789&" +
                            "need_name=True&" +
                            "need_phone_number=True&" +
                            "need_email=True&" +
                            "need_shipping_address=True&" +
                            "is_flexible=True&" +
                            "disable_notification=True&" +
                            "reply_to_message_id=123&" +
                            "reply_markup=%7B%0D%0A%20%20%22force_reply" +
                            "%22%3A%20true" +
                            "%0D%0A%7D", request.FirstOrDefault()?.Body);
            Assert.AreEqual("/botToken/sendInvoice", request.FirstOrDefault()?.Url);
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.AnswerPreCheckoutQuery"/>.
        /// </summary>
        [Test]
        public void AnswerPreCheckoutQueryTest()
        {
            mBotOkResponse.AnswerPreCheckoutQuery("TestPreCheckoutQueryId", true, "TestErrorMessage");

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(
                    Requests.WithUrl("/botToken/answerPreCheckoutQuery").UsingPost());
            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual("pre_checkout_query_id=TestPreCheckoutQueryId&" +
                            "ok=True&" +
                            "error_message=TestErrorMessage", request.FirstOrDefault()?.Body);
            Assert.AreEqual("/botToken/answerPreCheckoutQuery", request.FirstOrDefault()?.Url);

            Assert.Throws<Exception>(
                () => mBotBadResponse.AnswerPreCheckoutQuery("TestPreCheckoutQueryId", true, "TestErrorMessage"));
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.EditMessageText"/>.
        /// </summary>
        [Test]
        public void EditMessageTextTest()
        {
            mBotOkResponse.EditMessageText("TestText", "testChatId", 123, "testInlineMessageId", ParseMode.HTML, true,
                Keyboards.GetInlineKeyboard());

            var request = MockServer.ServerOkResponse.SearchLogsFor(
                Requests.WithUrl("/botToken/editMessageText").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual("text=TestText&" +
                            "chat_id=testChatId&" +
                            "message_id=123&" +
                            "inline_message_id=testInlineMessageId&" +
                            "parse_mode=HTML&" +
                            "disable_web_page_preview=True&" +
                            "reply_markup=%7B%0D%0A%20%20%22inline_keyboard" +
                            "%22%3A%20%5B%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                            "%22%3A%20%221%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                            "%22%3A%20%222%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%2C%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%" +
                            "20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%223%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%" +
                            "20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%224%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%0D%" +
                            "0A%20%20%5D%0D%0A%7D", request.FirstOrDefault()?.Body);
            Assert.AreEqual("/botToken/editMessageText", request.FirstOrDefault()?.Url);

            Assert.Throws<Exception>(
                () =>
                    mBotBadResponse.EditMessageText("TestText", "testChatId", 123, "testInlineMessageId", ParseMode.HTML,
                        true, Keyboards.GetInlineKeyboard()));
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.EditMessageCaption"/>.
        /// </summary>
        [Test]
        public void EditMessageCaptionTest()
        {
            mBotOkResponse.EditMessageCaption("TestChatId", 123, "TestInlineMessageId", "TestCaption",
                Keyboards.GetInlineKeyboard());

            var request = MockServer.ServerOkResponse.SearchLogsFor(
                Requests.WithUrl("/botToken/editMessageCaption").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual("chat_id=TestChatId&" +
                            "message_id=123&" +
                            "inline_message_id=TestInlineMessageId&" +
                            "caption=TestCaption&" +
                            "reply_markup=%7B%0D%0A%20%20%22inline_keyboard" +
                            "%22%3A%20%5B%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                            "%22%3A%20%221%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                            "%22%3A%20%222%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%2C%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B" +
                            "%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%223%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0" +
                            "A%20%20%20%20%20%20%20%20%22text%22%3A%20%224%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%0D%0A%20%20%5D%0D%" +
                            "0A%7D", request.FirstOrDefault()?.Body);
            Assert.AreEqual("/botToken/editMessageCaption", request.FirstOrDefault()?.Url);

            Assert.Throws<Exception>(
                () =>
                    mBotBadResponse.EditMessageCaption("TestChatId", 123, "TestInlineMessageId", "TestCaption", Keyboards.GetInlineKeyboard()));

        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.EditMessageReplyMarkup"/>.
        /// </summary>
        [Test]
        public void EditMessageEditMessageReplyMarkupTest()
        {
            mBotOkResponse.EditMessageReplyMarkup("TestChatId", 123, "TestInlineMessageId", Keyboards.GetInlineKeyboard());


            var request =
                MockServer.ServerOkResponse.SearchLogsFor(
                    Requests.WithUrl("/botToken/editMessageReplyMarkup").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual("chat_id=TestChatId&" +
                            "message_id=123&" +
                            "inline_message_id=TestInlineMessageId&" +
                            "reply_markup=%7B%0D%0A%20%20%22inline_keyboard" +
                            "%22%3A%20%5B%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                            "%22%3A%20%221%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                            "%22%3A%20%222%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%2C%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%" +
                            "7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%223%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%" +
                            "0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%224%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%0D%0A%20%20%" +
                            "5D%0D%0A%7D", request.FirstOrDefault()?.Body);
            Assert.AreEqual("/botToken/editMessageReplyMarkup", request.FirstOrDefault()?.Url);

            Assert.Throws<Exception>(
                () =>
                    mBotBadResponse.EditMessageReplyMarkup("TestChatId", 123, "TestInlineMessageId", Keyboards.GetInlineKeyboard()));
        }


        /// <summary>
        /// Test method <see cref="TelegramBotClient.DeleteMessage"/>.
        /// </summary>
        [Test]
        public void DeleteMessageTest()
        {
            mBotOkResponse.DeleteMessage("TestChatId", 123456);
            
            var request =
                MockServer.ServerOkResponse.SearchLogsFor(
                    Requests.WithUrl("/botToken/deleteMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual("chat_id=TestChatId&message_id=123456", request.FirstOrDefault()?.Body);
            Assert.AreEqual("/botToken/deleteMessage", request.FirstOrDefault()?.Url);

            Assert.Throws<Exception>(
                () =>
                    mBotBadResponse.DeleteMessage("TestChatId", 123456));
        }
    }
}

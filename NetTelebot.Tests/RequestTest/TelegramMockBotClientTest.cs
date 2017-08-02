using System;
using System.Collections.Generic;
using System.Linq;
using Mock4Net.Core;
using NetTelebot.BotEnum;
using NetTelebot.Tests.MockServerObject;
using NetTelebot.Type;
using NetTelebot.Type.Keyboard;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.RequestTest
{
    [TestFixture]
    internal class TelegramMockBotClientTest
    {
        private const int mOkServerPort = 8091;
        private const int mBadServerPort = 8092;

        private readonly TelegramBotClient mBotOkResponse = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:" + mOkServerPort) };
        private readonly TelegramBotClient mBotBadResponse = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:" + mBadServerPort) };

        [OneTimeSetUp]
        public void OnStart()
        {
            MockServer.Start(mOkServerPort, mBadServerPort);
        }

        [OneTimeTearDown]
        public void OnStop()
        {
            MockServer.Stop();
        }

        /// <summary>
        /// Sends the message test method <see cref="TelegramBotClient.GetMe"/>.
        /// </summary>
        [Test]
        public void GetMeTest()
        {
            mBotOkResponse.GetMe();
            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getMe").UsingPost());
          
            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/getMe");
            Assert.Throws<Exception> (() => mBotBadResponse.GetMe());
        }

        /// <summary>
        /// Sends the message test method <see cref="TelegramBotClient.SendMessage"/>.
        /// </summary>
        [Test]
        public void SendMessageTest()
        {
            mBotOkResponse.SendMessage(123, "123", ParseMode.HTML, false, false, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=123&parse_mode=HTML&" +
                "disable_web_page_preview=False&" +
                "disable_notification=False&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendMessage");
            Assert.Throws<Exception>(() => mBotBadResponse.SendMessage(123, "123", ParseMode.HTML, false, false, 123, new ForceReplyMarkup()));
        }

       

        /// <summary>
        /// Forward the message test method <see cref="TelegramBotClient.ForwardMessage"/>.
        /// </summary>
        [Test]
        public void ForwardMessageTest()
        {
            mBotOkResponse.ForwardMessage(123, 123 ,123, true);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/forwardMessage").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "from_chat_id=123&" +
                "disable_notification=True&" +
                "message_id=123");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/forwardMessage");
            Assert.Throws<Exception>(() => mBotBadResponse.ForwardMessage(123, 123, 123, true));
        }

        /// <summary>
        /// Sends the photo test method <see cref="TelegramBotClient.SendPhoto"/>.
        /// </summary>
        [Test]
        public void SendPhotoTest()
        {
            mBotOkResponse.SendPhoto(123, new ExistingFile { FileId = "123" }, "caption", false, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendPhoto").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "photo=123&" +
                "caption=caption&" +
                "disable_notification=False&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendPhoto");
            Assert.Throws<Exception>(() => mBotBadResponse.SendPhoto(123, new ExistingFile { FileId = "123" },
                "caption", false, 123, new ForceReplyMarkup()));
        }

        /// <summary>
        /// Sends the audio test method <see cref="TelegramBotClient.SendAudio"/>.
        /// </summary>
        [Test]
        public void SendAudioTest()
        {
            mBotOkResponse.SendAudio(123, new ExistingFile { FileId = "123" }, "caption", 123, "performer", 
                "title", true, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendAudio").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "audio=123&" +
                "caption=caption&" +
                "duration=123&" +
                "performer=performer&" +
                "title=title&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendAudio");
            Assert.Throws<Exception>(() => mBotBadResponse.SendAudio(123, new ExistingFile { FileId = "123" }, "caption", 123, "performer",
                "title", true, 123, new ForceReplyMarkup()));
        }

        /// <summary>
        /// Sends the document test method <see cref="TelegramBotClient.SendDocument"/>.
        /// </summary>
        [Test]
        public void SendDocumentTest()
        {
            mBotOkResponse.SendDocument(123, new ExistingFile { FileId = "123"}, "caption", true, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendDocument").UsingPost());

            PrintResult(request);
            
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "document=123&" +
                "caption=caption&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendDocument");
            Assert.Throws<Exception>(() => mBotBadResponse.SendDocument(123, new ExistingFile { FileId = "123" },
                "caption", true, 123, new ForceReplyMarkup()));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendSticker"/>.
        /// </summary>
        [Test]
        public void SendStickerTest()
        {
            mBotOkResponse.SendSticker(123, new ExistingFile {FileId = "123"}, true, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendSticker").UsingPost());

            PrintResult(request);
            
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "sticker=123&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendSticker");
            Assert.Throws<Exception>(() => mBotBadResponse.SendSticker(123, new ExistingFile { FileId = "123" },
                true, 123, new ForceReplyMarkup()));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendVideo"/>.
        /// </summary>
        [Test]
        public void SendVideoTest()
        {
            mBotOkResponse.SendVideo(123, new ExistingFile {FileId = "123"}, 123, 123, 123, "caption", true, 123,
                new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendVideo").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "video=123&" +
                "duration=123&" +
                "width=123&" +
                "height=123&" +
                "caption=caption&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendVideo");
            Assert.Throws<Exception>(() => mBotBadResponse.SendVideo(123, new ExistingFile { FileId = "123" },
                123, 123, 123, "caption", true, 123, new ForceReplyMarkup()));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendLocation"/>.
        /// </summary>
        [Test]
        public void SendLocationTest()
        {
            mBotOkResponse.SendLocation(123, 1.0f, 1.0f, true, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendLocation").UsingPost());

            PrintResult(request);
            
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "latitude=1&" +
                "longitude=1&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendLocation");
            Assert.Throws<Exception>(() => mBotBadResponse.SendLocation(123, 1.0f, 1.0f, true, 123, new ForceReplyMarkup()));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendContact"/>.
        /// </summary>
        [Test]
        public void SendContactTest()
        {
            mBotOkResponse.SendContact(123, "123", "firstName", "lastName", true, 123, new ForceReplyMarkup());

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendContact").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "phone_number=123&" +
                "first_name=firstName&" +
                "last_name=lastName&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendContact");
            Assert.Throws<Exception>(() => mBotBadResponse.SendContact(123, "123", "firstName", "lastName", true, 123, new ForceReplyMarkup()));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendChatAction"/>.
        /// </summary>
        [Test]
        public void SendChatActionTest()
        {
            //typing
            mBotOkResponse.SendChatAction(123, ChatActions.Typing);
            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=typing");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_photo
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_photo);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_photo");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //record_video
            mBotOkResponse.SendChatAction(123, ChatActions.Record_video);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=record_video");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_video
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_video);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_video");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //record_audio
            mBotOkResponse.SendChatAction(123, ChatActions.Record_audio);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=record_audio");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_audio
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_audio);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_audio");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_document
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_document);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_document");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //find_location
            mBotOkResponse.SendChatAction(123, ChatActions.Find_location);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=find_location");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //record_video_note
            mBotOkResponse.SendChatAction(123, ChatActions.Record_video_note);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=record_video_note");

            MockServer.ServerOkResponse.ResetRequestLogs();

            //upload_video_note
            mBotOkResponse.SendChatAction(123, ChatActions.Upload_video_note);
            request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_video_note");


            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendChatAction");
            Assert.Throws<Exception>(() => mBotBadResponse.SendChatAction(123, ChatActions.Upload_video_note));
        }
        
        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.GetUserProfilePhotos"/>.
        /// </summary>
        [Test]
        public void GetUserProfilePhotosTest()
        {
            mBotOkResponse.GetUserProfilePhotos(123, 123, 10);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUserProfilePhotos").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "user_id=123&" +
                "offset=123&" +
                "limit=10");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/getUserProfilePhotos");
            Assert.Throws<Exception>(() => mBotBadResponse.GetUserProfilePhotos(123, 123, 10));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.KickChatMember"/>.
        /// </summary>
        [Test]
        public void KickChatMemberTest()
        {
            mBotOkResponse.KickChatMember(123, 123, new DateTime(2027, 07, 27));

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/kickChatMember").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body, 
                "chat_id=123&" +
                "user_id=123&" +
                "until_date=1816646400");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/kickChatMember");
            Assert.Throws<Exception>(() => mBotBadResponse.KickChatMember(123, 123, new DateTime(2027, 07, 27)));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.UnbanChatMember"/>.
        /// </summary>
        [Test]
        public void UnbanChatMemberTest()
        {
            mBotOkResponse.UnbanChatMember(123, 123);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/unbanChatMember").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body, 
                "chat_id=123&" +
                "user_id=123");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/unbanChatMember");
            Assert.Throws<Exception>(() => mBotBadResponse.UnbanChatMember(123, 123));
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.LeaveChat"/>.
        /// </summary>
        [Test]
        public void LeaveChatTest()
        {
            mBotOkResponse.LeaveChat(123);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/leaveChat").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body, "chat_id=123");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/leaveChat");
            Assert.Throws<Exception>(() => mBotBadResponse.LeaveChat(123));
        }

        internal static void PrintResult(IEnumerable<Request> request)
        {
            Console.WriteLine(request.FirstOrDefault()?.Body);
            Console.WriteLine(request.FirstOrDefault()?.Url);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Mock4Net.Core;
using NUnit.Framework;
using RestSharp;


namespace NetTelebot.Tests
{
    [TestFixture]
    public class TelegramMockBotClientTest
    {
        private FluentMockServer server;

        private const string expectedBodyForSendMessage =
            @"{ ok: ""true"", result: { message_id: 123, date: 0, chat: { id: 123, type: ""private"" }}}";

        private const string expectedBodyForGetUserProfilePhotos =
            @"{ ok: ""true"", result: { total_count: 1, photos: [[ { file_id: ""123"", width: 123, height: 123 }, { file_id: ""456"", width: 456, height: 456 } ]] }}";

        private const string expectedBodyForGetMe =
            @"{ ok: ""true"", result: { id: ""123"", first_name: ""FirstName"", username: ""username"" }}";

        private readonly TelegramBotClient mBot = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:8090") };

        [OneTimeSetUp]
        public void OnStart()
        {
            server = FluentMockServer.Start(8090);

            server
                .Given(
                    Requests.WithUrl("/botToken/send*").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(expectedBodyForSendMessage)
                );

            server
                .Given(
                    Requests.WithUrl("/botToken/forwardMessage").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(expectedBodyForSendMessage)
                );

            server
                .Given(
                    Requests.WithUrl("/botToken/getUserProfilePhotos").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(expectedBodyForGetUserProfilePhotos)
                );

            server
                .Given(
                    Requests.WithUrl("/botToken/getMe").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(expectedBodyForGetMe)
                );
        }

        [OneTimeTearDown]
        public void OnStop()
        {
            server.Stop();
        }

        /// <summary>
        /// Sends the message test method <see cref="TelegramBotClient.GetMe"/>.
        /// </summary>
        [Test]
        public void GetMeTest()
        {
            mBot.GetMe();

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/getMe").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/getMe");
        }

        /// <summary>
        /// Sends the message test method <see cref="TelegramBotClient.SendMessage"/>.
        /// </summary>
        [Test]
        public void SendMessageTest()
        {
            mBot.SendMessage(123, "123", ParseMode.HTML, false, false, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body, 
                "chat_id=123&" +
                "text=123&" +
                "parse_mode=HTML&" +
                "disable_web_page_preview=False&" +
                "disable_notification=False&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendMessage");
        }

        /// <summary>
        /// Forward the message test method <see cref="TelegramBotClient.ForwardMessage"/>.
        /// </summary>
        [Test]
        public void ForwardMessageTest()
        {
            mBot.ForwardMessage(123, 123 ,123, true);

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/forwardMessage").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "from_chat_id=123&" +
                "disable_notification=True&" +
                "message_id=123");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/forwardMessage"); 
        }

        /// <summary>
        /// Sends the photo test method <see cref="TelegramBotClient.SendPhoto"/>.
        /// </summary>
        [Test]
        public void SendPhotoTest()
        {
            mBot.SendPhoto(123, new ExistingFile { FileId = "123" }, "caption", false, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendPhoto").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "photo=123&" +
                "caption=caption&" +
                "disable_notification=False&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendPhoto");
        }

        /// <summary>
        /// Sends the audio test method <see cref="TelegramBotClient.SendAudio"/>.
        /// </summary>
        [Test]
        public void SendAudioTest()
        {
            mBot.SendAudio(123, new ExistingFile { FileId = "123" }, "caption", 123, "performer", 
                "title", true, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendAudio").UsingPost());

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
        }

        /// <summary>
        /// Sends the document test method <see cref="TelegramBotClient.SendDocument"/>.
        /// </summary>
        [Test]
        public void SendDocumentTest()
        {
            mBot.SendDocument(123, new ExistingFile { FileId = "123"}, "caption", true, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendDocument").UsingPost());

            PrintResult(request);
            
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "document=123&" +
                "caption=caption&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendDocument");
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendSticker"/>.
        /// </summary>
        [Test]
        public void SendStickerTest()
        {
            mBot.SendSticker(123, new ExistingFile {FileId = "123"}, true, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendSticker").UsingPost());

            PrintResult(request);
            
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "sticker=123&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendSticker");
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendVideo"/>.
        /// </summary>
        [Test]
        public void SendVideoTest()
        {
            mBot.SendVideo(123, new ExistingFile {FileId = "123"}, 123, 123, 123, "caption", true, 123,
                new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendVideo").UsingPost());

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
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendLocation"/>.
        /// </summary>
        [Test]
        public void SendLocationTest()
        {
            mBot.SendLocation(123, 1.0f, 1.0f, true, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendLocation").UsingPost());

            PrintResult(request);
            
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "latitude=1&" +
                "longitude=1&" +
                "disable_notification=True&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendLocation");
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendContact"/>.
        /// </summary>
        [Test]
        public void SendContactTest()
        {
            mBot.SendContact(123, "123", "firstName", "lastName", true, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendContact").UsingPost());

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
        }

        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.SendChatAction"/>.
        /// </summary>
        [Test]
        public void SendChatActionTest()
        {
            //typing
            mBot.SendChatAction(123, ChatActions.Typing);
            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=typing");
            server.ResetRequestLogs();

            //upload_photo
            mBot.SendChatAction(123, ChatActions.Upload_photo);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_photo");
            server.ResetRequestLogs();

            //record_video
            mBot.SendChatAction(123, ChatActions.Record_video);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=record_video");
            server.ResetRequestLogs();

            //upload_video
            mBot.SendChatAction(123, ChatActions.Upload_video);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_video");
            server.ResetRequestLogs();

            //record_audio
            mBot.SendChatAction(123, ChatActions.Record_audio);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=record_audio");
            server.ResetRequestLogs();

            //upload_audio
            mBot.SendChatAction(123, ChatActions.Upload_audio);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_audio");
            server.ResetRequestLogs();

            //upload_document
            mBot.SendChatAction(123, ChatActions.Upload_document);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_document");
            server.ResetRequestLogs();

            //find_location
            mBot.SendChatAction(123, ChatActions.Find_location);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=find_location");
            server.ResetRequestLogs();

            //record_video_note
            mBot.SendChatAction(123, ChatActions.Record_video_note);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=record_video_note");
            server.ResetRequestLogs();

            //upload_video_note
            mBot.SendChatAction(123, ChatActions.Upload_video_note);
            request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendChatAction").UsingPost());
            PrintResult(request);
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "action=upload_video_note");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendChatAction");
        }
        
        /// <summary>
        /// Sends the sticker test method <see cref="TelegramBotClient.GetUserProfilePhotos"/>.
        /// </summary>
        [Test]
        public void GetUserProfilePhotosTest()
        {
            mBot.GetUserProfilePhotos(123, 123, 10);

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/getUserProfilePhotos").UsingPost());

            PrintResult(request);

            
            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "user_id=123&" +
                "offset=123&" +
                "limit=10");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/getUserProfilePhotos");
        }

        private static void PrintResult(IEnumerable<Request> request)
        {
            Console.WriteLine(request.FirstOrDefault()?.Body);
            Console.WriteLine(request.FirstOrDefault()?.Url);
        }
    }
}

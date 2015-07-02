using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace NetTelebot.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetMe()
        {
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0"
            };
            Console.Write(tbc.GetMe().UserName);
        }

        [TestMethod]
        public void TestGetUpdates()
        {
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0"
            };
            var updates = tbc.GetUpdates();
            Console.WriteLine(updates.Ok);
            Console.WriteLine(updates.Result.Length);
            if (updates.Result.Any())
            {
                foreach (var item in updates.Result)
                {
                    Console.WriteLine(item.UpdateId);
                    Console.WriteLine(item.Message.From.FirstName);
                    if (item.Message.Text != null)
                        Console.WriteLine(item.Message.Text);
                    if (item.Message.Photo != null)
                        Console.WriteLine(item.Message.Photo[0].FileId);
                    if (item.Message.Location != null)
                        Console.WriteLine(item.Message.Location.Latitude);
                    if (item.Message.Contact != null)
                        Console.WriteLine(item.Message.Contact.PhoneNumber);
                }
            }
        }

        [TestMethod]
        public void TestEvent()
        {
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
                CheckInterval = 1200,
            };
            tbc.UpdatesReceived += Tbc_UpdatesReceived;
            tbc.StartCheckingUpdates();
            var start = DateTime.Now;
            while (DateTime.Now < start.AddMinutes(1)) ;
        }

        private void Tbc_UpdatesReceived(object sender, TelegramUpdateEventArgs e)
        {
            foreach (var item in e.Updates)
            {
                Console.WriteLine("{0} : {1}", item.Message.From.FirstName,
                    item.Message.Text != null ? item.Message.Text :
                    item.Message.Photo != null ? item.Message.Photo.First().FileId :
                    item.Message.Location != null ? item.Message.Location.Latitude.ToString() :
                    item.Message.Contact != null ? item.Message.Contact.PhoneNumber : string.Empty);
            }
        }

        [TestMethod]
        public void TestSendMessage()
        {
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
                CheckInterval = 1200,
            };
            tbc.UpdatesReceived += Tbc_UpdatesReceived2;
            tbc.StartCheckingUpdates();
            var start = DateTime.Now;
            while (DateTime.Now < start.AddMinutes(2)) ;
        }

        private void Tbc_UpdatesReceived2(object sender, TelegramUpdateEventArgs e)
        {
            var line1 = new string[] { "A", "B" };
            var kb = new ReplyKeyboardMarkup()
            {
                Keyboard = new string[][] { line1 },
                OneTimeKeyboard = true,
            };
            var tbc = (TelegramBotClient)sender;
            foreach (var item in e.Updates)
            {
                if (item.Message.Text != null)
                    tbc.SendMessage(item.Message.Chat.Id, item.Message.Text, replyMarkup: kb);
                else if (item.Message.Photo != null)
                    tbc.SendPhoto(item.Message.Chat.Id,
                        new ExistingFile() { FileId = item.Message.Photo.First().FileId },
                        "OK",
                        item.Message.MessageId);
            }
        }

        [TestMethod]
        public void TestForwardMessage()
        {
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
                CheckInterval = 1200,
            };
            tbc.UpdatesReceived += Tbc_UpdatesReceived3;
            tbc.StartCheckingUpdates();
            var start = DateTime.Now;
            while (DateTime.Now < start.AddMinutes(2)) ;
        }

        private void Tbc_UpdatesReceived3(object sender, TelegramUpdateEventArgs e)
        {
            var tbc = (TelegramBotClient)sender;
            foreach (var item in e.Updates)
            {
                tbc.ForwardMessage(item.Message.Chat.Id, item.Message.Chat.Id, item.Message.MessageId);
            }
        }

        [TestMethod]
        public void TestSendNewPhoto()
        {
            var chatId = 72288276;
            var fileContent = File.ReadAllBytes(@"C:\Users\Mehrdad\Pictures\71302_orig.jpg");
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
            };
            tbc.SendPhoto(chatId, new NewFile() { FileContent = fileContent, FileName = "a.jpg" });
        }

        [TestMethod]
        public void TestGetUserProfilePhotos()
        {
            var userId = 72288276;
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
            };
            var pps = tbc.GetUserProfilePhotos(userId);
            foreach (var item in pps.Result.Photos)
            {
                foreach (var ps in item)
                {
                    Console.WriteLine("{0}: {1}X{2}", ps.FileId, ps.Width, ps.Height);
                }
            }
        }

        [TestMethod]
        public void TestKeyboard()
        {
            var line1 = new string[] { "A1", "B1" };
            var line2 = new string[] { "C1", "D1", "E1" };
            var kb = new ReplyKeyboardMarkup()
            {
                Keyboard = new string[][] { line1, line2 },
                //OneTimeKeyboard = true,
            };
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
            };
            Console.WriteLine(kb.GetJson());
            var userId = 72288276;
            tbc.SendMessage(userId, "Test 44", replyMarkup: kb);
        }

        [TestMethod]
        public void TestHideKeyboard()
        {
            var hk = new ReplyKeyboardHideMarkup()
            {
            };
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
            };
            Console.WriteLine(hk.GetJson());
            var userId = 72288276;
            tbc.SendMessage(userId, "Test 55", replyMarkup: hk);
        }

        [TestMethod]
        public void TestForceReply()
        {
            var fr = new ForceReplyMarkup()
            {
            };
            var tbc = new TelegramBotClient()
            {
                Token = "118879726:AAGLhweZ3NMAR4HKdD-GL1GwnVqLWCg7vt0",
            };
            Console.WriteLine(fr.GetJson());
            var userId = 72288276;
            tbc.SendMessage(userId, "Test 66", replyMarkup: fr);
        }
    }
}

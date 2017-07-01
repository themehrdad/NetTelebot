using System;
using NetTelebot.Tests.TypeTestObject;
using NUnit.Framework;
using Newtonsoft.Json.Linq;


namespace NetTelebot.Tests
{
    [TestFixture]
    internal class MessageInfoParserTest
    {
        [Test]
        public static void DeleteChatPhotoParserTest()
        {
            //check MessageInfo witout field [delete_chat_photo]
            dynamic DeleteChatPhoto = MinimumMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(DeleteChatPhoto);
            Assert.False(messageInfo.DeleteChatPhoto);
            
            //check MessageInfo with field [delete_chat_photo: true] 
            DeleteChatPhoto.delete_chat_photo = true;
            messageInfo = new MessageInfo(DeleteChatPhoto);
            Assert.True(messageInfo.DeleteChatPhoto);

            Console.WriteLine(DeleteChatPhoto);
        }

        [Test]
        public static void GroupChatCreatedParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic GroupChatCreated = MinimumMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(GroupChatCreated);
            Assert.False(messageInfo.GroupChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            GroupChatCreated.group_chat_created = true;
            messageInfo = new MessageInfo(GroupChatCreated);
            Assert.True(messageInfo.GroupChatCreated);

            Console.WriteLine(GroupChatCreated);
        }

        [Test]
        public static void SuperGroupChatCreatedParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic SuperGroupChatCreated = MinimumMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(SuperGroupChatCreated);
            Assert.False(messageInfo.SuperGroupChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            SuperGroupChatCreated.supergroup_chat_created = true;
            messageInfo = new MessageInfo(SuperGroupChatCreated);
            Assert.True(messageInfo.SuperGroupChatCreated);

            Console.WriteLine(SuperGroupChatCreated);
        }

        [Test]
        public static void ChannelChatCreatedParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic ChannelChatCreated = MinimumMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(ChannelChatCreated);
            Assert.False(messageInfo.ChannelChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            ChannelChatCreated.channel_chat_created = true;
            messageInfo = new MessageInfo(ChannelChatCreated);
            Assert.True(messageInfo.ChannelChatCreated);

            Console.WriteLine(ChannelChatCreated);
        }

        [Test]
        public static void MigrateToChatIdParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic MigrateToChatId = MinimumMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(MigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            MigrateToChatId.migrate_to_chat_id = 14881488;
            messageInfo = new MessageInfo(MigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 14881488);

            Console.WriteLine(MigrateToChatId);
        }

        [Test]
        public static void MigrateFromChatIdParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic MigrateFromChatId = MinimumMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(MigrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            MigrateFromChatId.migrate_from_chat_id = 14881488;
            messageInfo = new MessageInfo(MigrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 14881488);

            Console.WriteLine(MigrateFromChatId);
        }

        [Test]
        public static void MinMessageInfoTest()
        {
            dynamic minMessageInfoField = MinimumMessageInfoField();

            MessageInfo messageInfo = new MessageInfo(minMessageInfoField);
            
            Assert.AreEqual(messageInfo.MessageId, -1147483648);
            Assert.AreEqual(messageInfo.DateUnix, 0);
            Assert.AreEqual(messageInfo.Date, new DateTime(1970, 1, 1).ToLocalTime());
            Assert.AreEqual(messageInfo.Chat.Id, 1049413668);

            Console.WriteLine(minMessageInfoField);
        }


        /// <summary>
        /// Test for <see cref="MessageInfo.Sticker"/> parse field.
        /// </summary>
        [Test]
        public static void MessageInfoStickerTest()
        {
            //todo Do similar tests for all fields MessageInfo
            const string fileId = "100";
            const int width = 100;
            const int height = 100;
            const string emoji = "emoji";
            const int fileSize = 10;

            dynamic MessageInfoSticker = MinimumMessageInfoField();

            MessageInfoSticker.sticker = StickerInfoObject.GetObject(fileId, width, height, 
                PhotoSizeInfoObject.GetObject(fileId, width, height, fileSize), emoji, fileSize);

            MessageInfo messageInfo = new MessageInfo(MessageInfoSticker);

            //test MessageInfo.Sticker
            Assert.AreEqual(messageInfo.Sticker.FileId, fileId);
            Assert.AreEqual(messageInfo.Sticker.Width, width);
            Assert.AreEqual(messageInfo.Sticker.Height, height);
            Assert.AreEqual(messageInfo.Sticker.Emoji, emoji);
            Assert.AreEqual(messageInfo.Sticker.FileSize, fileSize);
            
            //test MessageInfo.Sticker.Thumb
            Assert.AreEqual(messageInfo.Sticker.Thumb.FileId, fileId);
            Assert.AreEqual(messageInfo.Sticker.Thumb.Width, width);
            Assert.AreEqual(messageInfo.Sticker.Thumb.Height, height);
            Assert.AreEqual(messageInfo.Sticker.Thumb.FileSize, fileSize);

            Console.WriteLine(MessageInfoSticker);

        }

        /// <summary>
        /// Minimum required object fields <see cref="MessageInfo.Chat"/>
        /// </summary>
        /// <returns>Minimum required object fields <see cref="UserInfo"/></returns>
        private static JObject MinimumChatField()
        {
            dynamic chat = new JObject();

            chat.id = 1049413668;
            chat.first_name = "Test";

            return chat;
        }

        /// <summary>
        /// Minimum required object fields <see cref="MessageInfo"/>
        /// </summary>
        /// <returns>Minimum required object fields <see cref="MessageInfo"/></returns>
        private static JObject MinimumMessageInfoField()
        {
            dynamic messageInfo = new JObject();

            messageInfo.message_id = -1147483648;
            messageInfo.date = 0;
            messageInfo.chat = MinimumChatField();

            return messageInfo;
        }
    }
}
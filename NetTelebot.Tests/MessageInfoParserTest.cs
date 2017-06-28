using System;
using NUnit.Framework;
using Newtonsoft.Json.Linq;


namespace NetTelebot.Tests
{
    [TestFixture]
    internal class MessageInfoParserTest
    {
        [Test]
        public void DeleteChatPhotoParserTest()
        {
            //check MessageInfo witout field [delete_chat_photo]
            dynamic DeleteChatPhoto = MinMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(DeleteChatPhoto);
            Assert.False(messageInfo.DeleteChatPhoto);
            
            //check MessageInfo with field [delete_chat_photo: true] 
            DeleteChatPhoto.delete_chat_photo = true;
            messageInfo = new MessageInfo(DeleteChatPhoto);
            Assert.True(messageInfo.DeleteChatPhoto);

            Console.WriteLine(DeleteChatPhoto);
        }

        [Test]
        public void GroupChatCreatedParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic GroupChatCreated = MinMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(GroupChatCreated);
            Assert.False(messageInfo.GroupChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            GroupChatCreated.group_chat_created = true;
            messageInfo = new MessageInfo(GroupChatCreated);
            Assert.True(messageInfo.GroupChatCreated);

            Console.WriteLine(GroupChatCreated);
        }

        [Test]
        public void SuperGroupChatCreatedParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic SuperGroupChatCreated = MinMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(SuperGroupChatCreated);
            Assert.False(messageInfo.SuperGroupChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            SuperGroupChatCreated.supergroup_chat_created = true;
            messageInfo = new MessageInfo(SuperGroupChatCreated);
            Assert.True(messageInfo.SuperGroupChatCreated);

            Console.WriteLine(SuperGroupChatCreated);
        }

        [Test]
        public void ChannelChatCreatedParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic ChannelChatCreated = MinMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(ChannelChatCreated);
            Assert.False(messageInfo.ChannelChatCreated);

            //check MessageInfo with field [group_chat_created: true] 
            ChannelChatCreated.channel_chat_created = true;
            messageInfo = new MessageInfo(ChannelChatCreated);
            Assert.True(messageInfo.ChannelChatCreated);

            Console.WriteLine(ChannelChatCreated);
        }

        [Test]
        public void MigrateToChatIdParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic MigrateToChatId = MinMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(MigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            MigrateToChatId.migrate_to_chat_id = 14881488;
            messageInfo = new MessageInfo(MigrateToChatId);
            Assert.AreEqual(messageInfo.MigrateToChatId, 14881488);

            Console.WriteLine(MigrateToChatId);
        }

        [Test]
        public void MigrateFromChatIdParserTest()
        {
            //check MessageInfo witout field [group_chat_created]
            dynamic MigrateFromChatId = MinMessageInfoField();
            MessageInfo messageInfo = new MessageInfo(MigrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 0);

            //check MessageInfo with field [group_chat_created: true] 
            MigrateFromChatId.migrate_from_chat_id = 14881488;
            messageInfo = new MessageInfo(MigrateFromChatId);
            Assert.AreEqual(messageInfo.MigrateFromChatId, 14881488);

            Console.WriteLine(MigrateFromChatId);
        }

        [Test]
        public void MinMessageInfoTest()
        {
            dynamic minMessageInfoField = MinMessageInfoField();

            MessageInfo messageInfo = new MessageInfo(minMessageInfoField);
            
            Assert.AreEqual(messageInfo.MessageId, -1147483648);
            Assert.AreEqual(messageInfo.DateUnix, 0);
            //todo check ToDateTime extension
            //Assert.AreEqual(messageInfo.Date, new DateTime(1970, 1, 1));
            Assert.AreEqual(messageInfo.Chat.Id, 1049413668);

            Console.WriteLine(minMessageInfoField);
        }

        /// <summary>
        /// Minimum required object fields <see cref="MessageInfo.Chat"/>
        /// </summary>
        /// <returns>Minimum required object fields <see cref="UserInfo"/></returns>
        private static JObject MinChatField()
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
        private static JObject MinMessageInfoField()
        {
            dynamic messageInfo = new JObject();

            messageInfo.message_id = -1147483648;
            messageInfo.date = 0;
            messageInfo.chat = MinChatField();

            return messageInfo;
        }

        private static int ConvertToUnixTimestamp()
        {
            return (int)(new DateTime(1980, 1, 1) - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
    
}
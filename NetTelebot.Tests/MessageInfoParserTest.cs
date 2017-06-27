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
            MessageInfo messageInfoTrue = new MessageInfo(DeleteChatPhoto);
            Assert.True(messageInfoTrue.DeleteChatPhoto);
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
            messageInfo.date = ConvertToUnixTimestamp();
            messageInfo.chat = MinChatField();

            return messageInfo;
        }

        private static int ConvertToUnixTimestamp()
        {
            return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
    
}
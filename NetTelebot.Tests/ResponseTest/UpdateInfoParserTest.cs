using System.Collections.Generic;
using NetTelebot.BotEnum;
using NetTelebot.Extension;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.PaymentObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class UpdateInfoParserTest
    {
        /// <summary>
        /// Test for <see cref="UpdateInfo"/> parse field with incoming <see cref="MessageInfo"/>.
        /// </summary>
        [Test]
        public static void UpdateInfoTest()
        {
            //field class UpdateInfo
            const int updateId = 123;

            //field class MessageInfo
            const int messageId = 123;
            const int date = 0;
            const int chatId = 123;
            const ChatType chatType = ChatType.channel;

            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);

            //check message
            dynamic updateInfoObject = UpdateInfoObject.GetObject(updateId, messageInfo);
            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            //common field
            Assert.AreEqual(updateInfo.UpdateId, updateId);

            AssertMessageInfo(new object[] { messageId, date, chatId, chatType }, updateInfo.Message);
            
            //check editedMessage
            updateInfoObject = UpdateInfoObject.GetObject(updateId, editedMessage: messageInfo);
            updateInfo = new UpdateInfo(updateInfoObject);

            AssertMessageInfo(new object[] { messageId, date, chatId, chatType }, updateInfo.EditedMessage);
            
            //check channelPost
            updateInfoObject = UpdateInfoObject.GetObject(updateId, channelPost: messageInfo);
            updateInfo = new UpdateInfo(updateInfoObject);

            AssertMessageInfo(new object[] { messageId, date, chatId, chatType }, updateInfo.ChannelPost);
            
            //check editedChannelPost
            updateInfoObject = UpdateInfoObject.GetObject(updateId, editedChannelPost: messageInfo);
            updateInfo = new UpdateInfo(updateInfoObject);

            AssertMessageInfo(new object[] { messageId, date, chatId, chatType }, updateInfo.EditedChannelPost);
        }

        private static void AssertMessageInfo(IReadOnlyList<object> expected, MessageInfo updatesResult)
        {
            Assert.AreEqual(expected[0], updatesResult.MessageId);
            Assert.AreEqual(expected[1], updatesResult.DateUnix);
            Assert.AreEqual(expected[2], updatesResult.Chat.Id);
            Assert.AreEqual(expected[3], updatesResult.Chat.Type);
        }

        [Test]
        public static void CallbackQueryTest()
        {
            //field class UpdateInfo
            const int updateId = 123;

            //field class UserInfo
            const int id = 123;
            const string idСallback = "123";
            const string firstName = "TestFirstName";
            const string lastName = "TestLastName";
            const string username = " TestUserName";
            const string languageCode = "TestLanguageCode";

            //field class MessageInfo
            const int messageId = 123;
            const int date = 0;
            const int chatId = 123;
            const ChatType chatType = ChatType.channel;

            //field class CallbackQueryInfo
            const string inlineMessageId = "123";
            const string chatInstance = "123";
            const string data = "TestData";
            const string gameShortName = "TestGameShortName";

            JObject userInfo = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);
            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);

            dynamic callbackQueryInfo = CallbackQueryInfoObject.GetObject(idСallback, userInfo, messageInfo, inlineMessageId,
                chatInstance, data, gameShortName);

            dynamic updateInfoObject = UpdateInfoObject.GetObject(updateId, callbackQuery: callbackQueryInfo);
            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            Assert.AreEqual(updateInfo.UpdateId, updateId);

            //UserInfo field
            Assert.AreEqual(updateInfo.CallbackQuery.From.Id, id);
            Assert.AreEqual(updateInfo.CallbackQuery.From.FirstName, firstName);
            Assert.AreEqual(updateInfo.CallbackQuery.From.LastName, lastName);
            Assert.AreEqual(updateInfo.CallbackQuery.From.UserName, username);
            Assert.AreEqual(updateInfo.CallbackQuery.From.LanguageCode, languageCode);

            //MessageInfo field
            Assert.AreEqual(updateInfo.CallbackQuery.Message.MessageId, messageId);
            Assert.AreEqual(updateInfo.CallbackQuery.Message.DateUnix, date);
            Assert.AreEqual(updateInfo.CallbackQuery.Message.Chat.Id, chatId);
            Assert.AreEqual(updateInfo.CallbackQuery.Message.Chat.Type, chatType);

            //CallbackQueryInfo field
            Assert.AreEqual(updateInfo.CallbackQuery.Id, idСallback);
            Assert.AreEqual(updateInfo.CallbackQuery.InlineMessageId, inlineMessageId);
            Assert.AreEqual(updateInfo.CallbackQuery.ChatInstance, chatInstance);
            Assert.AreEqual(updateInfo.CallbackQuery.Data, data);
            Assert.AreEqual(updateInfo.CallbackQuery.GameShortName, gameShortName);
        }

        [Test]
        public static void ShippingQueryTest()
        {
            //field class UpdateInfo
            const int updateId = 123;

            //field class UserInfo
            const int id = 123;
            const string firstName = "TestFirstName";
            const string lastName = "TestLastName";
            const string username = " TestUserName";
            const string languageCode = "TestLanguageCode";

            //field class ShippingAddressInfo
            const string countryCode = "AW";
            const string state = "TestState";
            const string city = "TestCity";
            const string streetLineOne = "TestStreetLineOne";
            const string streetLineTwo = "TestStreetLineTwo";
            const string postCode = "TestPostCode";

            //field class ShippingQueryInfo
            const string invoicePayload = "TestInvoicePayload";
            const string idShippingQuery = "TestId";

            JObject userInfo = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);
            JObject shippingAddress = ShippingAddressInfoObject.GetObject(countryCode, state, city, streetLineOne,
                streetLineTwo, postCode);

            JObject shippingQueryInfo = ShippingQueryInfoObject.GetObject(idShippingQuery, userInfo, invoicePayload,
                shippingAddress);

            JObject updateInfoObject = UpdateInfoObject.GetObject(updateId, shippingQuery: shippingQueryInfo);

            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            Assert.AreEqual(updateId, updateInfo.UpdateId);

            Assert.AreEqual(idShippingQuery, updateInfo.ShippingQuery.Id);
            Assert.AreEqual(invoicePayload, updateInfo.ShippingQuery.InvoicePayload);

            //field class UserInfo
            Assert.AreEqual(id, updateInfo.ShippingQuery.From.Id);
            Assert.AreEqual(firstName, updateInfo.ShippingQuery.From.FirstName);
            Assert.AreEqual(lastName, updateInfo.ShippingQuery.From.LastName);
            Assert.AreEqual(username, updateInfo.ShippingQuery.From.UserName);
            Assert.AreEqual(languageCode, updateInfo.ShippingQuery.From.LanguageCode);

            //field class ShippingAddressInfo
            Assert.AreEqual(countryCode.ToEnum<Countries>(), updateInfo.ShippingQuery.ShippingAddress.CountryCode);
            Assert.AreEqual(state, updateInfo.ShippingQuery.ShippingAddress.State);
            Assert.AreEqual(city, updateInfo.ShippingQuery.ShippingAddress.City);
            Assert.AreEqual(streetLineOne, updateInfo.ShippingQuery.ShippingAddress.StreetLineOne);
            Assert.AreEqual(streetLineTwo, updateInfo.ShippingQuery.ShippingAddress.StreetLineTwo);
            Assert.AreEqual(postCode, updateInfo.ShippingQuery.ShippingAddress.PostCode);
        }

        [Test]
        public static void PreCheckoutQueryTest()
        { 
            //field class UserInfo
            const int id = 123;
            const string firstName = "TestFirstName";
            const string lastName = "TestLastName";
            const string username = " TestUserName";
            const string languageCode = "TestLanguageCode";
            JObject userInfo = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            //field class ShippingAddressInfo
            const string countryCode = "AW";
            const string state = "TestState";
            const string city = "TestCity";
            const string streetLineOne = "TestStreetLineOne";
            const string streetLineTwo = "TestStreetLineTwo";
            const string postCode = "TestPostCode";

            JObject shippingAddress = ShippingAddressInfoObject.GetObject(countryCode, state, city, streetLineOne,
               streetLineTwo, postCode);

            //field class OrederInfo
            const string name = "TestName";
            const string phoneNumber = "TestPhoneNumber";
            const string email = "TestEmail";
            const int totalAmmount = 123;
            const string shippingOptionId = "TestShippingId";


            JObject orderInfo = OrderInfoObject.GetObject(name, phoneNumber, email, shippingAddress);

            //field class PreCheckoutQueryInfo
            const string preCheckoutId = "TestId";
            const string currency = "USD";
            const string invoicePayload = "TestInvoicePayload";

            JObject preCheckoutQueryInfo = PreCheckoutQueryInfoObject.GetObject(
                preCheckoutId, userInfo, currency, totalAmmount, invoicePayload, shippingOptionId, orderInfo);

            //field class UpdateInfo
            const int updateId = 123;

            JObject updateInfoObject = UpdateInfoObject.GetObject(updateId, preCheckoutQuery: preCheckoutQueryInfo);

            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            //filed PreCheckoutQuery
            Assert.AreEqual(updateId, updateInfo.UpdateId);
            Assert.AreEqual(preCheckoutId, updateInfo.PreCheckoutQuery.Id);
            Assert.AreEqual(invoicePayload, updateInfo.PreCheckoutQuery.InvoicePayload);
            Assert.AreEqual(shippingOptionId, updateInfo.PreCheckoutQuery.ShippingOptionId);

            //filed From
            Assert.AreEqual(id, updateInfo.PreCheckoutQuery.From.Id);
            Assert.AreEqual(firstName, updateInfo.PreCheckoutQuery.From.FirstName);
            Assert.AreEqual(lastName, updateInfo.PreCheckoutQuery.From.LastName);
            Assert.AreEqual(username, updateInfo.PreCheckoutQuery.From.UserName);
            Assert.AreEqual(languageCode, updateInfo.PreCheckoutQuery.From.LanguageCode);

            //field OrderInfo
            Assert.AreEqual(name, updateInfo.PreCheckoutQuery.OrderInfo.Name);
            Assert.AreEqual(phoneNumber, updateInfo.PreCheckoutQuery.OrderInfo.PnoneNumber);
            Assert.AreEqual(email, updateInfo.PreCheckoutQuery.OrderInfo.Email);

            //field ShippingAddress
            Assert.AreEqual(countryCode.ToEnum<Countries>(), updateInfo.PreCheckoutQuery.OrderInfo.ShippingAddress.CountryCode);
            Assert.AreEqual(state, updateInfo.PreCheckoutQuery.OrderInfo.ShippingAddress.State);
            Assert.AreEqual(city, updateInfo.PreCheckoutQuery.OrderInfo.ShippingAddress.City);
            Assert.AreEqual(streetLineOne, updateInfo.PreCheckoutQuery.OrderInfo.ShippingAddress.StreetLineOne);
            Assert.AreEqual(streetLineTwo, updateInfo.PreCheckoutQuery.OrderInfo.ShippingAddress.StreetLineTwo);
            Assert.AreEqual(postCode, updateInfo.PreCheckoutQuery.OrderInfo.ShippingAddress.PostCode);
        }
    }
}

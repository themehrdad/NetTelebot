using System.Collections.Generic;
using NetTelebot.BotEnum;
using NetTelebot.Extension;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.InlineModeObject;
using NetTelebot.Tests.TypeTestObject.PaymentObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class UpdateInfoParserTest
    {
        private const int mId = 123;
        private const bool mIsBot = true;
        private const string mFirstName = "TestFirstName";
        private const string mLastName = "TestLastName";
        private const string mUsername = " TestUserName";
        private const string mLanguageCode = "TestLanguageCode";

        private static JObject mCommonUserInfo { get; } = UserInfoObject.
            GetObject(mId, mIsBot, mFirstName, mLastName, mUsername, mLanguageCode);


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
        public static void InlineQueryTest()
        {
            //field class UpdateInfo
            const int updateId = 123;
            
            //field class Location
            const float longitude = 1;
            const float latitude = 1;

            JObject locationInfo = LocationInfoObject.GetObject(longitude, latitude);

            //field class InlineQueryInfo
            const string idInlineQuery = "TestIdInlineQuery";
            const string query = "TestQuery";
            const string offset = "TestOffset";

            JObject inlineQuery = InlineQueryInfoObject.GetObject(idInlineQuery, mCommonUserInfo, locationInfo, query, offset);

            JObject updateInfoObject = UpdateInfoObject.GetObject(updateId, inlineQuery: inlineQuery);

            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            //field class InlineQueryInfo
            Assert.AreEqual(idInlineQuery, updateInfo.InlineQuery.Id);
            Assert.AreEqual(query, updateInfo.InlineQuery.Query);
            Assert.AreEqual(offset, updateInfo.InlineQuery.Offset);

            //UserInfo field
            Assert.AreEqual(mId, updateInfo.InlineQuery.From.Id);
            Assert.AreEqual(mIsBot, updateInfo.InlineQuery.From.IsBot);
            Assert.AreEqual(mFirstName, updateInfo.InlineQuery.From.FirstName);
            Assert.AreEqual(mLastName, updateInfo.InlineQuery.From.LastName);
            Assert.AreEqual(mUsername, updateInfo.InlineQuery.From.UserName);
            Assert.AreEqual(mLanguageCode, updateInfo.InlineQuery.From.LanguageCode);

            //LocationInfo fiels
            Assert.AreEqual(latitude, updateInfo.InlineQuery.Location.Latitude);
            Assert.AreEqual(longitude, updateInfo.InlineQuery.Location.Longitude);
        }

        [Test]
        public static void ChosenInlineResultTest()
        {
            //field class UpdateInfo
            const int updateId = 123;
            
            //field class Location
            const float longitude = 1;
            const float latitude = 1;

            JObject locationInfo = LocationInfoObject.GetObject(longitude, latitude);

            //field class ChosenInlineResultInfo
            const string resultId = "TestResultId";
            const string inlineMessageId = "InlineMessageId";
            const string query = "TestQuery";

            JObject chosenInlineResult = ChosenInlineResultInfoObject.GetObject(resultId, mCommonUserInfo, locationInfo,
                inlineMessageId, query);

            JObject updateInfoObject = UpdateInfoObject.GetObject(updateId, chosenInlineResult: chosenInlineResult);

            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            //ChosenInlineResultInfo filed
            Assert.AreEqual(resultId, updateInfo.ChosenInlineResult.ResultId);
            Assert.AreEqual(inlineMessageId, updateInfo.ChosenInlineResult.InlineMessageId);
            Assert.AreEqual(query, updateInfo.ChosenInlineResult.Query);

            //UserInfo field
            Assert.AreEqual(mId, updateInfo.ChosenInlineResult.From.Id);
            Assert.AreEqual(mIsBot, updateInfo.ChosenInlineResult.From.IsBot);
            Assert.AreEqual(mFirstName, updateInfo.ChosenInlineResult.From.FirstName);
            Assert.AreEqual(mLastName, updateInfo.ChosenInlineResult.From.LastName);
            Assert.AreEqual(mUsername, updateInfo.ChosenInlineResult.From.UserName);
            Assert.AreEqual(mLanguageCode, updateInfo.ChosenInlineResult.From.LanguageCode);

            //LocationInfo fiels
            Assert.AreEqual(latitude, updateInfo.ChosenInlineResult.Location.Latitude);
            Assert.AreEqual(longitude, updateInfo.ChosenInlineResult.Location.Longitude);
        }


        [Test]
        public static void CallbackQueryTest()
        {
            //field class UpdateInfo
            const int updateId = 123;
            const string idСallback = "123";
            
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

            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);

            dynamic callbackQueryInfo = CallbackQueryInfoObject.GetObject(idСallback, mCommonUserInfo, messageInfo, inlineMessageId,
                chatInstance, data, gameShortName);

            dynamic updateInfoObject = UpdateInfoObject.GetObject(updateId, callbackQuery: callbackQueryInfo);

            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            Assert.AreEqual(updateInfo.UpdateId, updateId);

            //UserInfo field
            Assert.AreEqual(mId, updateInfo.CallbackQuery.From.Id);
            Assert.AreEqual(mIsBot, updateInfo.CallbackQuery.From.IsBot);
            Assert.AreEqual(mFirstName, updateInfo.CallbackQuery.From.FirstName);
            Assert.AreEqual(mLastName, updateInfo.CallbackQuery.From.LastName);
            Assert.AreEqual(mUsername, updateInfo.CallbackQuery.From.UserName);
            Assert.AreEqual(mLanguageCode, updateInfo.CallbackQuery.From.LanguageCode);

            //MessageInfo field
            Assert.AreEqual(messageId, updateInfo.CallbackQuery.Message.MessageId);
            Assert.AreEqual(date, updateInfo.CallbackQuery.Message.DateUnix);
            Assert.AreEqual(chatId, updateInfo.CallbackQuery.Message.Chat.Id);
            Assert.AreEqual(chatType, updateInfo.CallbackQuery.Message.Chat.Type);

            //CallbackQueryInfo field
            Assert.AreEqual(idСallback, updateInfo.CallbackQuery.Id);
            Assert.AreEqual(inlineMessageId, updateInfo.CallbackQuery.InlineMessageId);
            Assert.AreEqual(chatInstance, updateInfo.CallbackQuery.ChatInstance );
            Assert.AreEqual(data, updateInfo.CallbackQuery.Data);
            Assert.AreEqual(gameShortName, updateInfo.CallbackQuery.GameShortName);
        }

        [Test]
        public static void ShippingQueryTest()
        {
            //field class UpdateInfo
            const int updateId = 123;
           
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

            JObject shippingAddress = ShippingAddressInfoObject.GetObject(countryCode, state, city, streetLineOne,
                streetLineTwo, postCode);

            JObject shippingQueryInfo = ShippingQueryInfoObject.GetObject(idShippingQuery, mCommonUserInfo, invoicePayload,
                shippingAddress);

            JObject updateInfoObject = UpdateInfoObject.GetObject(updateId, shippingQuery: shippingQueryInfo);

            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            Assert.AreEqual(updateId, updateInfo.UpdateId);

            Assert.AreEqual(idShippingQuery, updateInfo.ShippingQuery.Id);
            Assert.AreEqual(invoicePayload, updateInfo.ShippingQuery.InvoicePayload);

            //field class UserInfo
            Assert.AreEqual(mId, updateInfo.ShippingQuery.From.Id);
            Assert.AreEqual(mIsBot, updateInfo.ShippingQuery.From.IsBot);
            Assert.AreEqual(mFirstName, updateInfo.ShippingQuery.From.FirstName);
            Assert.AreEqual(mLastName, updateInfo.ShippingQuery.From.LastName);
            Assert.AreEqual(mUsername, updateInfo.ShippingQuery.From.UserName);
            Assert.AreEqual(mLanguageCode, updateInfo.ShippingQuery.From.LanguageCode);

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
                preCheckoutId, mCommonUserInfo, currency, totalAmmount, invoicePayload, shippingOptionId, orderInfo);

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
            Assert.AreEqual(mId, updateInfo.PreCheckoutQuery.From.Id);
            Assert.AreEqual(mIsBot, updateInfo.PreCheckoutQuery.From.IsBot);
            Assert.AreEqual(mFirstName, updateInfo.PreCheckoutQuery.From.FirstName);
            Assert.AreEqual(mLastName, updateInfo.PreCheckoutQuery.From.LastName);
            Assert.AreEqual(mUsername, updateInfo.PreCheckoutQuery.From.UserName);
            Assert.AreEqual(mLanguageCode, updateInfo.PreCheckoutQuery.From.LanguageCode);

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

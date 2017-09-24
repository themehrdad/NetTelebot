using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.PaymentObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.MockServers
{
    internal static class ResponseStringGetUpdatesResult
    {
        #region Common Object

        /// <summary>
        /// Represent JSON string:
        /// 
        /// {
        ///  "message_id": 123,
        ///  "date": 0,
        ///  "chat": {
        ///    "id": 123,
        ///    "type": "private"
        ///  }
        ///}
        /// </summary>
        private static readonly JObject mExpectedBodyMessageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(123, 0,
            123, "private");

        //todo added JSON
        private static readonly JObject mExpectedBodyUserInfo = UserInfoObject.GetObject(123, "TestFirstName",
            "TestFirstName", "TestUserName", "TestLanguageCode");

        //todo added JSON
        private static readonly JObject mShippingAddress = ShippingAddressInfoObject.GetObject("countryCode", "state", "city",
            "streetLineOne", "streetLineTwo", "postCode");
        #endregion

        #region Message

        private static readonly JArray expectedBodyUpdateInfoWithMessage = UpdateInfoObject.GetObjectInArray(123,
            mExpectedBodyMessageInfo);

        /// <summary>
        /// Represent JSON string:
        /// 
        /// {
        ///  "ok": true,
        ///  "result": [
        ///    {
        ///      "update_id": 123,
        ///      "message": {
        ///        "message_id": 123,
        ///        "date": 0,
        ///        "chat": {
        ///          "id": 123,
        ///          "type": "private",
        ///       }
        ///     }
        ///    }
        ///  ]
        /// }
        /// </summary>
        internal static string ExpectedBodyWithObjectMessage { get; } =
            GetUpdatesResultObject.GetObject(true, expectedBodyUpdateInfoWithMessage).ToString();

        #endregion

        #region EditedMessage

        private static readonly JArray expectedBodyUpdateInfoWithEditedMessage = UpdateInfoObject.GetObjectInArray(123, editedMessage: mExpectedBodyMessageInfo);

        /// <summary>
        /// Represent JSON string:
        /// 
        /// {
        ///  "ok": true,
        ///  "result": [
        ///    {
        ///      "update_id": 123,
        ///      "edited_message": {
        ///        "message_id": 123,
        ///        "date": 0,
        ///        "chat": {
        ///          "id": 123,
        ///          "type": "private",
        ///        }
        ///      }
        ///    }
        ///  ]
        /// } 
        /// </summary>
        internal static string ExpectedBodyWithObjectEditMessage { get; } =
            GetUpdatesResultObject.GetObject(true, expectedBodyUpdateInfoWithEditedMessage).ToString();
        
        #endregion 

        #region ChannelPost

        private static readonly JArray expectedBodyUpdateInfoWithChannelPost = UpdateInfoObject.GetObjectInArray(123,
            channelPost: mExpectedBodyMessageInfo);

        /// <summary>
        /// Represent JSON string:
        /// 
        /// {
        ///  "ok": true,
        ///  "result": [
        ///    {
        ///      "update_id": 123,
        ///      "channel_post": {
        ///        "message_id": 123,
        ///        "date": 0,
        ///        "chat": {
        ///          "id": 123,
        ///          "type": "private",
        ///        }
        ///      }
        ///    }
        ///  ]
        /// }
        /// </summary>
        internal static string ExpectedBodyWithObjectChannelPost { get; } =
            GetUpdatesResultObject.GetObject(true, expectedBodyUpdateInfoWithChannelPost).ToString();

        #endregion

        #region EditedShannelPost

        private static readonly JArray expectedBodyUpdateInfoWithEditedChannelPost = UpdateInfoObject.GetObjectInArray(123, editedChannelPost: mExpectedBodyMessageInfo);

        /// <summary>
        /// Represent JSON string:
        /// 
        /// {
        /// "ok": true,
        /// "result": [
        ///   {
        ///     "update_id": 123,
        ///     "edited_channel_post": {
        ///       "message_id": 123,
        ///       "date": 0,
        ///       "chat": {
        ///         "id": 123,
        ///         "type": "private",
        ///       }
        ///     }
        ///   }
        ///  ]
        /// }
        /// </summary>
        internal static string ExpectedBodyWithObjectEditedChannelPost { get; } =
            GetUpdatesResultObject.GetObject(true, expectedBodyUpdateInfoWithEditedChannelPost).ToString();

        #endregion

        #region CallbackQuery

        private static readonly JObject callbackQueryInfo = CallbackQueryInfoObject.GetObject("123", mExpectedBodyUserInfo, mExpectedBodyMessageInfo, "123",
            "123", "TestData", "TestGameShortName");

        private static readonly JArray expectedBodyUpdateInfoWithCallbackQuery = UpdateInfoObject.GetObjectInArray(123,
            callbackQuery: callbackQueryInfo);

        /// <summary>
        /// Represent JSON string:
        /// 
        /// {
        ///  "ok": true,
        ///  "result": [
        ///    {
        ///      "update_id": 123,
        ///      "callback_query": {
        ///        "id": "123",
        ///        "from": {
        ///          "id": 123,
        ///          "first_name": "TestFirstName",
        ///          "last_name": "TestFirstName",
        ///          "username": "TestUserName",
        ///          "language_code": "TestLanguageCode"
        ///        },
        ///        "message": {
        ///          "message_id": 123,
        ///          "date": 0,
        ///          "chat": {
        ///            "id": 123,
        ///            "type": "private",
        ///          }
        ///        },
        ///        "inline_message_id": "123",
        ///        "chat_instance": "123",
        ///        "data": "TestData",
        ///        "game_short_name": "TestGameShortName"
        ///      }
        ///    }
        ///  ]
        /// }
        /// </summary>
        internal static string ExpectedBodyWithObjectCallbackQuery { get; } =
            GetUpdatesResultObject.GetObject(true, expectedBodyUpdateInfoWithCallbackQuery).ToString();

        #endregion

        #region ShippingQuery
        private static readonly JObject shippinqQuery =
            ShippingQueryInfoObject.GetObject("123", mExpectedBodyUserInfo, "TestInvoicePayload", mShippingAddress);

        private static readonly JArray expectedBodyUpdateInfoWithShippinqQuery
            = UpdateInfoObject.GetObjectInArray(123, shippingQuery: shippinqQuery);

        /// <summary>
        /// Represent JSON string:
        /// 
        /// {
        ///  "ok": true,
        ///  "result": [
        ///    {
        ///      "update_id": 123,
        ///      "shipping_query": {
        ///        "id": "123",
        ///        "from": {
        ///          "id": 123,
        ///          "first_name": "TestFirstName",
        ///          "last_name": "TestFirstName",
        ///          "username": "TestUserName",
        ///          "language_code": "TestLanguageCode"
        ///        },
        ///        "invoice_payload": "TestInvoicePayload",
        ///        "shipping_address": {
        ///          "country_code": "countryCode",
        ///          "state": "state",
        ///          "city": "city",
        ///          "street_line1": "streetLineOne",
        ///          "street_line2": "streetLineTwo",
        ///          "post_code": "postCode"
        ///        }
        ///      }
        ///    }
        ///  ]
        /// }
        /// </summary>
        internal static string ExpectedBodyWithObjectShippingQuery { get; } =
             GetUpdatesResultObject.GetObject(true, expectedBodyUpdateInfoWithShippinqQuery).ToString();
        #endregion

        #region PreCheckoutQuery
        //todo
        #endregion
    }
}

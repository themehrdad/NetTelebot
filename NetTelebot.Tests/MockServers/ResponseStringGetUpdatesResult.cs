using NetTelebot.Tests.TypeTestObject;
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
        private static readonly JObject expectedBodyMessageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(123, 0,
            123, "private");

        #endregion

        #region Message

        private static readonly JObject expectedBodyUpdateInfoWithMessage = UpdateInfoObject.GetObject(123,
            expectedBodyMessageInfo);

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
            GetUpdatesResultObject.GetObject(true, new JArray(expectedBodyUpdateInfoWithMessage)).ToString();

        #endregion

        #region EditedMessage

        private static readonly JObject expectedBodyUpdateInfoWithEditedMessage = UpdateInfoObject.GetObject(123, editedMessage: expectedBodyMessageInfo);

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
            GetUpdatesResultObject.GetObject(true, new JArray(expectedBodyUpdateInfoWithEditedMessage)).ToString();
        
        #endregion 

        #region ChannelPost

        private static readonly JObject expectedBodyUpdateInfoWithChannelPost = UpdateInfoObject.GetObject(123,
            channelPost: expectedBodyMessageInfo);

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
            GetUpdatesResultObject.GetObject(true, new JArray(expectedBodyUpdateInfoWithChannelPost)).ToString();

        #endregion

        #region EditedShannelPost

        private static readonly JObject expectedBodyUpdateInfoWithEditedChannelPost = UpdateInfoObject.GetObject(123, editedChannelPost: expectedBodyMessageInfo);

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
            GetUpdatesResultObject.GetObject(true, new JArray(expectedBodyUpdateInfoWithEditedChannelPost)).ToString();

        #endregion

        #region CallbackQuery

        private static readonly JObject expectedBodyUserInfo = UserInfoObject.GetObject(123, "TestFirstName",
            "TestFirstName", "TestUserName", "TestLanguageCode");
        
        private static readonly JObject callbackQueryInfo = CallbackQueryInfoObject.GetObject("123", expectedBodyUserInfo, expectedBodyMessageInfo, "123",
            "123", "TestData", "TestGameShortName");

        private static readonly JObject expectedBodyUpdateInfoWithCallbackQuery = UpdateInfoObject.GetObject(123,
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
            GetUpdatesResultObject.GetObject(true, new JArray(expectedBodyUpdateInfoWithCallbackQuery)).ToString();

        #endregion
    }
}

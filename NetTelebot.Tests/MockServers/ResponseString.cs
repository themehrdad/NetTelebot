using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.MockServers
{
    /// <summary>
    /// This class represent response string for <see cref="MockServer"/>
    /// </summary>
    internal static class ResponseString
    {
        #region CommonObject

        private static readonly JObject commonUserInfoObject = new JObject(
            UserInfoObject.GetObject(123, true, "FirstName", "LastName", "Username", "languageCode"));

        #endregion
        /// <summary>
        /// The expected body for SendMessageResult.
        /// Represent JSON string:
        /// 
        /// { "ok": true,
        ///   "result": {
        ///         "message_id": 123,
        ///         "date": 0,
        ///         "chat": {
        ///             "id": 123,
        ///             "type": "private"
        ///         }}}
        /// </summary>
        internal static string ExpectedBodyForSendMessageResult { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(MessageInfoObject.GetMandatoryFieldsMessageInfo(123, 0, 123, "private").Properties())))
            .ToString();

        /// <summary>
        /// The expected body for GetUserProfilePhotos.
        /// Represent JSON string:
        /// 
        /// { "ok": true,
        ///   "result": {
        ///         "total_count": 1,
        ///         "photos": [[
        ///         {
        ///             "file_id": 123,
        ///             "width": 123,
        ///             "height": 123
        ///         },
        ///         {
        ///             "file_id": 456,
        ///             "width": 456,
        ///             "height": 456
        ///         }
        ///         ]]}}
        /// </summary>
        internal static string ExpectedBodyForGetUserProfilePhotos { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(
                    new JProperty("total_count", 1),
                    new JProperty("photos",
                        GetJarrayOfJarry(
                            new JArray(
                                new JObject(PhotoSizeInfoObject.GetObject("123", 123, 123, 123).Properties()),
                                new JObject(PhotoSizeInfoObject.GetObject("123", 123, 123, 123).Properties())).ToString())))))
            .ToString();

        /// <summary>
        /// Gets the expected body for GetMe.
        /// Represent JSON string:
        /// 
        /// { "ok": true,
        ///   "result": {
        ///         "id": 123,
        ///         "is_bot": "true",
        ///         "first_name": "FirstName",
        ///         "username": "Username" }}
        /// </summary>
        internal static string ExpectedBodyForGetMe { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(commonUserInfoObject))).ToString();

        /// <summary>
        /// The expected body for GetChat.
        /// Represent JSON string:
        /// 
        /// { "ok": true, 
        ///   "result": { 
        ///         "id": 123,
        ///         "is_bot": "true", 
        ///         "type": "private", 
        ///         "title": "TestTitle", 
        ///         "username": "TestUsename", 
        ///         "first_name": "TestFirsName", 
        ///         "last_name": "TestLastName", 
        ///         "all_members_are_administrators": true }}
        /// </summary>
        internal static string ExpectedBodyForGetChat { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(
                    ChatInfoObject.GetObject(123, "private", "Title", "Username", "FirstName", "LastName", true,
                        description: "description").Properties()))).ToString();

        /// <summary>
        /// The expected body for BooleanResult.
        /// Represent JSON string:
        /// 
        /// { "ok": true, "result": true}
        /// </summary>
        internal static string ExpectedBodyForBooleanResult { get; } = new JObject(
            BooleanResultObject.GetObject(true, true)).ToString();
            
        /// <summary>
        /// The expected body for BooleanResult.
        /// Represent JSON string:
        /// 
        /// { "ok": true, "result": 123}
        /// </summary>
        internal static string ExpectedBodyForIntegerResult { get; } = new JObject(
            IntegerResultObject.GetObject(true, 123).Properties()).ToString();

        /// <summary>
        /// Expected body for GetFile.
        /// Represent JSON string:
        /// 
        /// { "ok": true,
        ///   "result": {
        ///         "file_id": "sdfslkajdflksadjf",
        ///         "file_size": 123456789123456789,
        ///         "file_path": "/file/path/to/file" }}
        /// </summary>
        internal static string ExpectedBodyForGetFile { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(
                    FileInfoObject.GetObject("fileId", 123456, "file/path").Properties()))).ToString();

        /// <summary>
        /// Expected body forGetChatAdministrators.
        /// Represent JSON string:
        /// 
        /// { "ok": true,
        ///   "result": [{
        ///      "user": {
        ///        "id": 123,
        ///        "is_bot": "true",
        ///        "first_name": "FirstName",
        ///        "last_name": "LastName",
        ///        "username": "UserName",
        ///        "language_code": "LanguageCode"
        ///      },
        ///      "status": "member"
        ///    }]}
        /// </summary>
        internal static string ExpectedBodyForGetChatAdministrators { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JArray(
                    new JObject(ChatMemberInfoObject.GetObject(commonUserInfoObject, "member").Properties())))).ToString();

        /// <summary>
        /// Expected body forGetChatAdministrators.
        /// Represent JSON string:
        /// 
        /// { "ok": true,
        ///   "result": {
        ///      "user": {
        ///        "id": 123,
        ///        "is_bot": "true",
        ///        "first_name": "FirstName",
        ///        "last_name": "LastName",
        ///        "username": "UserName",
        ///        "language_code": "LanguageCode"
        ///      },
        ///      "status": "member"
        ///    }}
        /// </summary>
        internal static string ExpectedBodyForGetChatMember { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(ChatMemberInfoObject.GetObject(commonUserInfoObject, "member").Properties()))).ToString();

        /// <summary>
        /// The expected body for bad response.
        /// Represent JSON string:
        ///  
        /// { "ok": false, "error_code": 401, "description": "Unauthorized" }
        /// </summary>
        internal static string ExpectedBodyForBadResponse { get; } = new JObject(
            new JProperty("ok", false),
            new JProperty("error_code", 401),
            new JProperty("description", "Unauthorized")).ToString();

        private static JArray GetJarrayOfJarry(string jArray)
        {
            return JArray.Parse($"[{jArray}]");
        }
    }
}

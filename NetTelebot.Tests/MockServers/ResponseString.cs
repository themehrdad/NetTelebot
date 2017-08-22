using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.MockServers
{
    /// <summary>
    /// This class represent response string for <see cref="MockServer"/>
    /// </summary>
    internal static class ResponseString
    {
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
                new JObject(
                    new JProperty("message_id", 123),
                    new JProperty("date", 0),
                    new JProperty("chat",
                        new JObject(
                            new JProperty("id", 123),
                            new JProperty("type", "private")))))).ToString();

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
                                new JObject(
                                    new JProperty("file_id", 123),
                                    new JProperty("width", 123),
                                    new JProperty("height", 123)),
                                new JObject(
                                    new JProperty("file_id", 456),
                                    new JProperty("width", 456),
                                    new JProperty("height", 456))).ToString()))))).ToString();

        /// <summary>
        /// Gets the expected body for GetMe.
        /// Represent JSON string:
        /// 
        /// { "ok": true,
        ///   "result": {
        ///         "id": 123,
        ///         "first_name": "FirstName",
        ///         "username": "Username" }}
        /// </summary>
        internal static string ExpectedBodyForGetMe { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(
                    new JProperty("id", 123),
                    new JProperty("first_name", "FirstName"),
                    new JProperty("username", "Username")))).ToString();

        /// <summary>
        /// The expected body for GetChat.
        /// Represent JSON string:
        /// 
        /// { "ok": true, 
        ///   "result": { 
        ///         "id": 123, 
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
                    new JProperty("id", 123),
                    new JProperty("type", "private"),
                    new JProperty("title", "TestTitle"),
                    new JProperty("username", "TestUsename"),
                    new JProperty("first_name", "TestFirsName"),
                    new JProperty("last_name", "TestLastName"),
                    new JProperty("all_members_are_administrators", true)))).ToString();

        /// <summary>
        /// The expected body for BooleanResult.
        /// Represent JSON string:
        /// 
        /// { "ok": true, "result": true}
        /// </summary>
        internal static string ExpectedBodyForBooleanResult { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result", true)).ToString();

        /// <summary>
        /// The expected body for BooleanResult.
        /// Represent JSON string:
        /// 
        /// { "ok": true, "result": 123}
        /// </summary>
        internal static string ExpectedBodyForIntegerResult { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result", 123)).ToString();

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

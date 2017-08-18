using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.MockServer
{
    internal class ResponseString
    {
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

        //todo remade this
        internal static string ExpectedBodyForGetUserProfilePhotos { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(
                    new JProperty("total_count", 1),
                    new JProperty("photos",
                        new JArray(
                            new JArray(
                                new JObject(
                                    new JProperty("file_id", 123),
                                    new JProperty("width", 123),
                                    new JProperty("height", 123)),
                                new JObject(
                                    new JProperty("file_id", 456),
                                    new JProperty("width", 456),
                                    new JProperty("height", 456)))))))).ToString();

        internal static string ExpectedBodyForGetMe => mExpectedBodyForGetMe;

        internal static string ExpectedBodyForGetChat => mExpectedBodyForGetChat;

        internal static string ExpectedBodyForBooleanResult => mExpectedBodyForBooleanResult;

        internal static string ExpectedBodyForBadResponse => mExpectedBodyForBadResponse;

        internal const string mExpectedBodyForGetUserProfilePhotos =
            @"{ ok: ""true"", result: { total_count: 1, photos: [[ { file_id: ""123"", width: 123, height: 123 }, { file_id: ""456"", width: 456, height: 456 } ]] }}";

        internal const string mExpectedBodyForGetMe =
            @"{ ok: ""true"", result: { id: ""123"", first_name: ""FirstName"", username: ""username"" }}";

        internal const string mExpectedBodyForGetChat = @"{ ok: ""true"", result: { id: ""123"", type: ""private"",
            title: ""TestTitle"", username: ""TestUsername"", first_name: ""TestFirstname"", last_name: ""TestLastName"",
            all_members_are_administrators: ""true"" }}";

        internal const string mExpectedBodyForBooleanResult = @"{ ok: ""true"", result: ""true"" }";

        internal const string mExpectedBodyForBadResponse = @"{ ok: ""false"", error_code: 401, description: ""Unauthorized"")";
    }
}

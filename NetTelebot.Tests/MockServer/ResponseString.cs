namespace NetTelebot.Tests.MockServerObject
{
    internal static class ResponseString
    {
        internal const string mExpectedBodyForSendMessageResult =
            @"{ ok: ""true"", result: { message_id: 123, date: 0, chat: { id: 123, type: ""private"" }}}";

        internal const string mExpectedBodyForGetUserProfilePhotos =
            @"{ ok: ""true"", result: { total_count: 1, photos: [[ { file_id: ""123"", width: 123, height: 123 }, { file_id: ""456"", width: 456, height: 456 } ]] }}";

        internal const string mExpectedBodyForGetMe =
            @"{ ok: ""true"", result: { id: ""123"", first_name: ""FirstName"", username: ""username"" }}";

        internal const string mExpectedBodyForBooleanResult = @"{ ok: ""true"", result: ""true"" }";

        internal const string mExpectedBodyForBadResponse = @"{ ok: ""false"", error_code: 401, description: ""Unauthorized"")";
    }
}

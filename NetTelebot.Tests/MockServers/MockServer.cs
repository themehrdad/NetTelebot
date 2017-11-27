using Mock4Net.Core;

namespace NetTelebot.Tests.MockServers
{
    internal static class MockServer
    {
        internal static FluentMockServer ServerOkResponse { get; private set; }
        internal static FluentMockServer ServerBadResponse { get; private set; }

        internal static void Start(int? portOkResponse = null, int? portBadResponse = null)
        {
            if (portOkResponse != null)
                ServerOkResponse = FluentMockServer.Start(portOkResponse.Value);
            if (portBadResponse != null)
                ServerBadResponse = FluentMockServer.Start(portBadResponse.Value);

            AddNewRouter("/botToken/sendChatAction", ResponseString.ExpectedBodyForBooleanResult);
            AddNewRouter("/botToken/send*", ResponseString.ExpectedBodyForSendMessageResult);
            AddNewRouter("/botToken/forwardMessage", ResponseString.ExpectedBodyForSendMessageResult);
            AddNewRouter("/botToken/getUserProfilePhotos", ResponseString.ExpectedBodyForGetUserProfilePhotos);
            AddNewRouter("/botToken/kickChatMember", ResponseString.ExpectedBodyForBooleanResult);
            AddNewRouter("/botToken/unbanChatMember", ResponseString.ExpectedBodyForBooleanResult);
            AddNewRouter("/botToken/getMe", ResponseString.ExpectedBodyForGetMe);
            AddNewRouter("/botToken/leaveChat", ResponseString.ExpectedBodyForBooleanResult);
            AddNewRouter("/botToken/getChatMembersCount", ResponseString.ExpectedBodyForIntegerResult);
            AddNewRouter("/botToken/getChat", ResponseString.ExpectedBodyForGetChat);
            AddNewRouter("/botToken/getFile", ResponseString.ExpectedBodyForGetFile);
            AddNewRouter("/botToken/getChatAdministrators", ResponseString.ExpectedBodyForGetChatAdministrators);
            AddNewRouter("/botToken/getChatMember", ResponseString.ExpectedBodyForGetChatMember);
            AddNewRouter("/botToken/answerCallbackQuery", ResponseString.ExpectedBodyForBooleanResult);
            AddNewRouter("/botToken/answerShippingQuery", ResponseString.ExpectedBodyForBooleanResult);
            AddNewRouter("/botToken/answerPreCheckoutQuery", ResponseString.ExpectedBodyForBooleanResult);
            AddNewRouter("/botToken/editMessageText", ResponseString.ExpectedBodyForSendMessageResult);
            AddNewRouter("/botToken/editMessageCaption", ResponseString.ExpectedBodyForSendMessageResult);
            AddNewRouter("/botToken/editMessageReplyMarkup", ResponseString.ExpectedBodyForSendMessageResult);
            AddNewRouter("/botToken/deleteMessage", ResponseString.ExpectedBodyForBooleanResult);

            AddNewRouter("/", ResponseString.ExpectedBodyForBadResponse, ServerBadResponse, 401);
        }

        internal static void AddNewRouter(string url, string responseString, FluentMockServer server = null, int? statusCode = null)
        {
            if (statusCode == null)
                statusCode = 200;

            if (server == null)
                server = ServerOkResponse;

            server?
                .Given(
                    Requests.WithUrl(url).UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode((int) statusCode)
                        .WithBody(responseString)
                );
        }

        internal static void Stop()
        {
            ServerOkResponse?.Stop();
            ServerBadResponse?.Stop();
        }
    }
}

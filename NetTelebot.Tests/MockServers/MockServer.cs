using Mock4Net.Core;

namespace NetTelebot.Tests.MockServers
{
    internal static class MockServer
    {
        internal static FluentMockServer ServerOkResponse { get; private set; }
        internal static FluentMockServer ServerBadResponse { get; private set; }

        public static void Start(int? portOkResponse = null, int? portBadResponse = null)
        {
            if (portOkResponse != null)
                ServerOkResponse = FluentMockServer.Start(portOkResponse.Value);
            if (portBadResponse != null)
                ServerBadResponse = FluentMockServer.Start(portBadResponse.Value);

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/sendChatAction").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForBooleanResult)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/send*").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForSendMessageResult)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/forwardMessage").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForSendMessageResult)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/getUserProfilePhotos").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForGetUserProfilePhotos)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/kickChatMember").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForBooleanResult)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/unbanChatMember").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForBooleanResult)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/getMe").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForGetMe)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/leaveChat").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForBooleanResult)
                );

            ServerOkResponse?
                .Given(
                    Requests.WithUrl("/botToken/getChat").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(ResponseString.ExpectedBodyForGetChat)
                );

            ServerBadResponse?
                .Given(
                    Requests.WithUrl("/*").UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode(401)
                        .WithBody(ResponseString.ExpectedBodyForBadResponse)
                );
        }

        public static void Stop()
        {
            ServerOkResponse?.Stop();
            ServerBadResponse?.Stop();
        }

    }
}

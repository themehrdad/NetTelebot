using System;
using System.Net;
using NetTelebot.Result;
using RestSharp;

namespace NetTelebot
{
    /* About tests
     * Аfter adding the method to the class, you need to add the following tests:
     *  
     * NetTelebot.Tests.RequestToMockTest.[ClassName]
     * 
     * [ClassName] = TelegramBotClientTest if you want to test the method
     * [ClassName] = TelegramBotGetUpdatesTest if you are testing for updates
     * [ClassName] = TelegramBotInlineKeyboardTest or TelegramBotKeyboardTest if you test keyboard.
     * [ClassName] = TelegramBotEventHandlerTest if you test event handler
     * 
     * Also you can check how the written added methods work in the namespace classes NetTelebot.Tests.RequestToTelegramTest.
     * There are requests to the telegram servers
     */

    /* About this partial class
     * 
     * Part of the class for common methods, variables, and so on.. 
     *  
     */

    public partial class TelegramBotClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramBotClient"/> class.
        /// </summary>
        public TelegramBotClient()
        {
            CheckInterval = 1000;
            RestClient = new RestClient("https://api.telegram.org");
        }

        /// <summary>
        /// Interval time in milliseconds to get latest messages sent to your bot.
        /// </summary>
        public int CheckInterval { get; set; }

        /// <summary>
        /// Your bot token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the REST client
        /// </summary>
        internal RestClient RestClient { private get; set; }

        private object ExecuteRequest<T>(IRestRequest request) where T : class
        {
            IRestResponse response = RestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (typeof(T) == typeof(SendMessageResult))
                    return new SendMessageResult(response.Content);

                if (typeof(T) == typeof(BooleanResult))
                    return new BooleanResult(response.Content);

                if (typeof(T) == typeof(UserInfoResult))
                    return new UserInfoResult(response.Content);

                if (typeof(T) == typeof(GetUserProfilePhotosResult))
                    return new GetUserProfilePhotosResult(response.Content);

                if (typeof(T) == typeof(GetUpdatesResult))
                    return new GetUpdatesResult(response.Content);

                if (typeof(T) == typeof(ChatInfoResult))
                    return new ChatInfoResult(response.Content);

                if (typeof(T) == typeof(IntegerResult))
                    return new IntegerResult(response.Content);

                if (typeof(T) == typeof(FileInfoResult))
                    return new FileInfoResult(response.Content);

                if (typeof(T) == typeof(ChatMembersInfoResult))
                    return new ChatMembersInfoResult(response.Content);

                if (typeof(T) == typeof(ChatMemberInfoResult))
                    return new ChatMemberInfoResult(response.Content);
            }

            throw new Exception(response.StatusDescription);
        }
    }
}

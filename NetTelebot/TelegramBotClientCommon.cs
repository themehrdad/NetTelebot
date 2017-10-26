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

        #region TelegramBotClientUpdatingMessagesUri
        private const string mEditMessageTextUri = "/bot{0}/editMessageText";
        #endregion

        #region TelegramBotClientMethodsUri
        private const string mGetMeUri = "/bot{0}/getMe";
        private const string mGetUpdatesUri = "/bot{0}/getUpdates";
        private const string mSendMessageUri = "/bot{0}/sendMessage";
        private const string mForwardMessageUri = "/bot{0}/forwardMessage";
        private const string mSendPhotoUri = "/bot{0}/sendPhoto";
        private const string mSendAudioUri = "/bot{0}/sendAudio";
        private const string mSendDocumentUri = "/bot{0}/sendDocument";
        private const string mSendStickerUri = "/bot{0}/sendSticker";
        private const string mSendVideoUri = "/bot{0}/sendVideo";
        private const string mSendVoiceUri = "/bot{0}/sendVoice";
        private const string mSendVideoNoteUri = "/bot{0}/sendVideoNote";
        private const string mSendLocationUri = "/bot{0}/sendLocation";
        private const string mSendVenueUri = "/bot{0}/sendVenue";
        private const string mSendContactUri = "/bot{0}/sendContact";
        private const string mSendChatActionUri = "/bot{0}/sendChatAction";
        private const string mGetUserProfilePhotosUri = "/bot{0}/getUserProfilePhotos";
        private const string mGetFileUri = "/bot{0}/getFile";
        private const string mKickChatMemberUri = "/bot{0}/kickChatMember";
        private const string mUnbanChatMemberUri = "/bot{0}/unbanChatMember";
        private const string mLeaveChatUri = "/bot{0}/leaveChat";
        private const string mGetChatUri = "/bot{0}/getChat";
        private const string mGetChatAdministratorsUri = "/bot{0}/getChatAdministrators";
        private const string mGetChatMembersCountUri = "/bot{0}/getChatMembersCount";
        private const string mGetChatMemberUri = "/bot{0}/getChatMember";
        private const string mAnswerCallbackQueryUri = "/bot{0}/answerCallbackQuery";
        #endregion

        #region TelegramBotClientPaymentUri
        private const string mAnswerShippingQueryUri = "/bot{0}/answerShippingQuery";
        private const string mSendInvoiceUri = "/bot{0}/sendInvoice";
        private const string mAnswerPreCheckoutQuery = "/bot{0}/answerPreCheckoutQuery";
        #endregion

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

using System;
using System.Linq;
using System.Net;
using System.Threading;
using NetTelebot.Result;
using NetTelebot.Type;
using RestSharp;

namespace NetTelebot
{
    /* About tests
     * After adding the class field, you need to add the following tests:
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
     * In this part of the class, only methods for handling updates, declaring variables and events.
     * 
     */

    /// <summary>
    /// The main class to use Telegram Bot API. 
    /// Get an instance of this class and set the Token property and start calling methods.
    /// </summary>
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
        /// Your bot token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the REST client. Used in integartion test.
        /// </summary>
        internal RestClient RestClient { private get; set; }

        /// <summary>
        /// Interval time in milliseconds to get latest messages sent to your bot.
        /// </summary>
        public int CheckInterval { get; set; }

        private Timer mUpdateTimer;
        private int mLastUpdateId;

        /// <summary>
        /// Occurs when [get updates error].
        /// </summary>
        public event UnhandledExceptionEventHandler GetUpdatesError;

        /// <summary>
        /// Whenever a message is sent to your bot, this event will be raised.
        /// </summary>
        public event EventHandler<TelegramUpdateEventArgs> UpdatesReceived;

        /// <summary>
        /// Gets first 100 messages sent to your bot.
        /// </summary>
        /// <returns>Returns a class containing messages sent to your bot</returns>
        public GetUpdatesResult GetUpdates()
        {
            return GetUpdatesInternal(null, null);
        }

        /// <summary>
        /// Gets maximum 100 messages sent to your bot, starting from update_id set by offset
        /// </summary>
        /// <param name="offset">First update_id to be downloaded</param>
        /// <returns>On success, the sent <see cref="GetUpdatesResult"/> is returned.</returns>
        public GetUpdatesResult GetUpdates(int offset)
        {
            return GetUpdatesInternal(offset, null);
        }

        /// <summary>
        /// Gets messages sent to your bot, starting from update_id set by offset, maximum number is set by limit
        /// </summary>
        /// <param name="offset">First update_id to be downloaded</param>
        /// <param name="limit">Maximum number of messages to receive. It cannot be more than 100</param>
        /// <returns>On success, the sent <see cref="GetUpdatesResult"/> is returned.</returns>
        public GetUpdatesResult GetUpdates(int offset, byte limit)
        {
            return GetUpdatesInternal(offset, limit);
        }

        /// <summary>
        /// Gets messages sent to your bot, from the begining and maximum number of limit set as parameter
        /// </summary>
        /// <param name="limit">Maximum number of messages to receive. It cannot be more than 100</param>
        /// <returns>Returns a class containing messages sent to your bot</returns>
        public GetUpdatesResult GetUpdates(byte limit)
        {
            return GetUpdatesInternal(null, limit);
        }

        //todo refact this
        private GetUpdatesResult GetUpdatesInternal(int? offset, byte? limit)
        {
            CheckToken();

            RestRequest request = new RestRequest(string.Format(mGetUpdatesUri, Token), Method.POST);

            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.Value.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.Value.ToString());

            return ExecuteRequest<GetUpdatesResult>(request) as GetUpdatesResult;
        }

        /// <summary>
        /// Called when [get updates error].
        /// </summary>
        /// <param name="exception">The exception.</param>
        protected virtual void OnGetUpdatesError(Exception exception)
        {
            GetUpdatesError?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
        }

        private void CheckToken()
        {
            if (Token == null)
                throw new Exception("Token is null");
        }

        /// <summary>
        /// Checks new updates (sent messages to your bot) automatically. Set CheckInterval property and handle UpdatesReceived event.
        /// </summary>
        public void StartCheckingUpdates()
        {
            CheckToken();

            if (mUpdateTimer == null)
            {
                mUpdateTimer = new Timer(UpdateTimerCallback, null, CheckInterval, Timeout.Infinite);
            }
            else
            {
                mUpdateTimer.Change(CheckInterval, Timeout.Infinite);
            }
        }

        /// <summary>
        /// Stops automatic checking updates
        /// </summary>
        public void StopCheckUpdates()
        {
            mUpdateTimer?.Dispose();
            mUpdateTimer = null;
        }

        private void UpdateTimerCallback(object state)
        {
            GetUpdatesResult updates = null;
            var getUpdatesSuccess = false;

            try
            {
                updates = mLastUpdateId == 0
                    ? GetUpdates()
                    : GetUpdates(mLastUpdateId + 1);

                getUpdatesSuccess = true;
            }
            catch (Exception ex)
            {
                OnGetUpdatesError(ex);
            }

            if (getUpdatesSuccess)

                if (updates.Ok && updates.Result != null && updates.Result.Any())
                {
                    mLastUpdateId = updates.Result.Last().UpdateId;
                    OnUpdatesReceived(updates.Result);
                }

            mUpdateTimer?.Change(CheckInterval, Timeout.Infinite);
        }

        /// <summary>
        /// Called when updates received.
        /// </summary>
        /// <param name="updates">The updates</param>
        protected virtual void OnUpdatesReceived(UpdateInfo[] updates)
        {
            TelegramUpdateEventArgs args = new TelegramUpdateEventArgs(updates);
            UpdatesReceived?.Invoke(this, args);
        }

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

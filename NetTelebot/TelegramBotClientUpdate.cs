using System;
using System.Linq;
using System.Threading;
using NetTelebot.BotEnum;
using NetTelebot.Extension;
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
     * Part of the class, only methods for handling updates.
     * 
     */

    /// <summary>
    /// The main class to use Telegram Bot API. 
    /// Get an instance of this class and set the Token property and start calling methods.
    /// </summary>
    public partial class TelegramBotClient
    {
        private const string mGetUpdatesUri = "/bot{0}/getUpdates";

        private Timer mUpdateTimer;
        private int mLastUpdateId;

        /// <summary>
        /// Occurs when updates error.
        /// </summary>
        public event UnhandledExceptionEventHandler GetUpdatesError;

        /// <summary>
        /// Whenever a message is sent to your bot, this event will be raised.
        /// </summary>
        public event EventHandler<TelegramUpdateEventArgs> UpdatesReceived;

        /// <summary>
        /// Use this method to receive incoming updates using long polling
        /// </summary>
        /// <param name="offset">Identifier of the first update to be returned. 
        /// Must be greater by one than the highest among the identifiers of previously received updates. 
        /// By default, updates starting with the earliest unconfirmed update are returned. 
        /// An update is considered confirmed as soon as getUpdates is called with an offset higher than its update_id. 
        /// The negative offset can be specified to retrieve updates starting from -offset update from the end of the updates queue. 
        /// All previous updates will forgotten.</param>
        /// <returns>
        /// On success, the sent <see cref="GetUpdatesResult"/> is returned.
        /// </returns>
        [Obsolete("Please use named arguments. Example: GetUpdates(offset:1). In the next version, overloaded methods will be removed")]
        public GetUpdatesResult GetUpdates(int offset)
        {
            return GetUpdates(offset, null);
        }

        /// <summary>
        /// Use this method to receive incoming updates using long polling
        /// </summary>
        /// <param name="limit">Limits the number of updates to be retrieved. 
        /// Values between 1—100 are accepted. Defaults to 100.</param>
        /// <returns>
        /// On success, the sent <see cref="GetUpdatesResult" /> is returned.
        /// </returns>
        [Obsolete("Please use named arguments. Example: GetUpdates(limit:10). In the next version, overloaded methods will be removed")]
        public GetUpdatesResult GetUpdates(byte limit)
        {
            return GetUpdates(null, limit);
        }

        /// <summary>
        /// Use this method to receive incoming updates using long polling
        /// </summary>
        /// <param name="timeout">Timeout in seconds for long polling. Defaults to 0, i.e. usual short polling. 
        /// Should be positive, short polling should be used for testing purposes only.</param>
        /// <returns>
        /// On success, the sent <see cref="GetUpdatesResult" /> is returned.
        /// </returns>
        [Obsolete("Please use named arguments. Example: GetUpdates(timeout:10). In the next version, overloaded methods will be removed")]
        public GetUpdatesResult GetUpdates(long timeout)
        {
            //todo test this (mock + real)
            return GetUpdates(null, null, timeout);
        }

        /// <summary>
        /// Use this method to receive incoming updates using long polling
        /// </summary>
        /// <param name="allowedUpdates">List the types of updates you want your bot to receive. 
        /// Specify an empty list to receive all updates regardless of type (default). If not specified, the previous setting will be used.</param>
        /// <returns>
        /// On success, the sent <see cref="GetUpdatesResult" /> is returned.
        /// </returns>
        [Obsolete("Please use named arguments. Example: GetUpdates(allowedUpdates:new[]{AllowedUpdates.Message}). In the next version, overloaded methods will be removed")]
        public GetUpdatesResult GetUpdates(AllowedUpdates[] allowedUpdates)
        {
            //todo test this (real)
            return GetUpdates(null, null, null, allowedUpdates);
        }

        /// <summary>
        /// Use this method to receive incoming updates using long polling
        /// </summary>
        /// <param name="offset">Identifier of the first update to be returned. 
        /// Must be greater by one than the highest among the identifiers of previously received updates. 
        /// By default, updates starting with the earliest unconfirmed update are returned. 
        /// An update is considered confirmed as soon as getUpdates is called with an offset higher than its update_id. 
        /// The negative offset can be specified to retrieve updates starting from -offset update from the end of the updates queue. 
        /// All previous updates will forgotten.</param>
        /// <param name="limit">Limits the number of updates to be retrieved. Values between 1—100 are accepted. Defaults to 100.</param>
        /// <returns>
        /// On success, the sent <see cref="GetUpdatesResult" /> is returned.
        /// </returns>
        [Obsolete("Please use named arguments. Example: GetUpdates(offset:1, limit:10). In the next version, overloaded methods will be removed")]
        public GetUpdatesResult GetUpdates(int offset, byte limit)
        {
            return GetUpdates(offset, limit, null);
        }

        /// <summary>
        /// Use this method to receive incoming updates using long polling
        /// </summary>
        /// <param name="offset">Identifier of the first update to be returned. 
        /// Must be greater by one than the highest among the identifiers of previously received updates. 
        /// By default, updates starting with the earliest unconfirmed update are returned. 
        /// An update is considered confirmed as soon as getUpdates is called with an offset higher than its update_id. 
        /// The negative offset can be specified to retrieve updates starting from -offset update from the end of the updates queue. 
        /// All previous updates will forgotten.</param>
        /// <param name="limit">Limits the number of updates to be retrieved. 
        /// Values between 1—100 are accepted. Defaults to 100.</param>
        /// <param name="timeout">Timeout in seconds for long polling. Defaults to 0, i.e. usual short polling. 
        /// Should be positive, short polling should be used for testing purposes only.</param>
        /// <param name="allowedUpdates">List the types of updates you want your bot to receive. 
        /// Specify an empty list to receive all updates regardless of type (default). 
        /// If not specified, the previous setting will be used.</param>
        /// <returns>
        /// On success, the sent <see cref="GetUpdatesResult" /> is returned.
        /// </returns>
        public GetUpdatesResult GetUpdates(int? offset = null, byte? limit = null, long? timeout = null, AllowedUpdates[] allowedUpdates = null)
        {
            CheckToken();

            RestRequest request = new RestRequest(string.Format(mGetUpdatesUri, Token), Method.POST);

            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.Value.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.Value.ToString());
            if (timeout.HasValue)
                request.AddQueryParameter("timeout", timeout.Value.ToString());
            if (allowedUpdates != null)
                request.AddQueryParameter("allowed_update", allowedUpdates.ToJarray());

            return ExecuteRequest<GetUpdatesResult>(request) as GetUpdatesResult;
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

        /// <summary>
        /// Called when updates received.
        /// </summary>
        /// <param name="updates">The updates</param>
        protected virtual void OnUpdatesReceived(UpdateInfo[] updates)
        {
            TelegramUpdateEventArgs args = new TelegramUpdateEventArgs(updates);
            UpdatesReceived?.Invoke(this, args);
        }

        /// <summary>
        /// Called when updates error.
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

        private void UpdateTimerCallback(object state)
        {
            try
            {
                GetUpdatesResult updates = mLastUpdateId == 0
                    ? GetUpdates()
                    : GetUpdates(offset:mLastUpdateId + 1);

                UpdateReceived(updates);
            }
            catch (Exception ex)
            {
                OnGetUpdatesError(ex);
            }

            mUpdateTimer?.Change(CheckInterval, Timeout.Infinite);
        }

        private void UpdateReceived(GetUpdatesResult updates)
        {
            if (!updates.Ok ||
                updates.Result == null ||
                !updates.Result.Any())
                return;
            
            mLastUpdateId = updates.Result.Last().UpdateId;
            OnUpdatesReceived(updates.Result);
        }
    }
}

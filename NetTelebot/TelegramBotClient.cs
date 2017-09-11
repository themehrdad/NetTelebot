using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using NetTelebot.BotEnum;
using NetTelebot.Interface;
using NetTelebot.Result;
using NetTelebot.Type;
using NetTelebot.Extension;


#if DEBUG
[assembly: InternalsVisibleTo("NetTelebot.Tests")]
#endif

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

    /// <summary>
    /// The main class to use Telegram Bot API. Get an instance of this class and set the Token property and start calling methods.
    /// </summary>
    public class TelegramBotClient
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

        private const string getMeUri = "/bot{0}/getMe";
        private const string getUpdatesUri = "/bot{0}/getUpdates";
        private const string sendMessageUri = "/bot{0}/sendMessage";
        private const string forwardMessageUri = "/bot{0}/forwardMessage";
        private const string sendPhotoUri = "/bot{0}/sendPhoto";
        private const string sendAudioUri = "/bot{0}/sendAudio";
        private const string sendDocumentUri = "/bot{0}/sendDocument";
        private const string sendStickerUri = "/bot{0}/sendSticker";
        private const string sendVideoUri = "/bot{0}/sendVideo";
        private const string sendVoiceUri = "/bot{0}/sendVoice";
        private const string sendVideoNoteUri = "/bot{0}/sendVideoNote";
        private const string sendLocationUri = "/bot{0}/sendLocation";
        private const string sendVenueUri = "/bot{0}/sendVenue";
        private const string sendContactUri = "/bot{0}/sendContact";
        private const string sendChatActionUri = "/bot{0}/sendChatAction";
        private const string getUserProfilePhotosUri = "/bot{0}/getUserProfilePhotos";
        private const string getFileUri = "/bot{0}/getFile";
        private const string kickChatMemberUri = "/bot{0}/kickChatMember";
        private const string unbanChatMemberUri = "/bot{0}/unbanChatMember";
        private const string leaveChatUri = "/bot{0}/leaveChat";
        private const string getChatUri = "/bot{0}/getChat";
        private const string getChatAdministratorsUri = "/bot{0}/getChatAdministrators";
        private const string getChatMembersCountUri = "/bot{0}/getChatMembersCount";
        private const string getChatMemberUri = "/bot{0}/getChatMember";
        private const string answerCallbackQueryUri = "/bot{0}/getChatMember";

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

        private GetUpdatesResult GetUpdatesInternal(int? offset, byte? limit)
        {
            CheckToken();

            RestRequest request = new RestRequest(string.Format(getUpdatesUri, Token), Method.POST);

            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.Value.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.Value.ToString());

            return ExecuteRequest<GetUpdatesResult>(request) as GetUpdatesResult;
        }

        private RestRequest NewRestRequest(string uri)
        {
            RestRequest request = new RestRequest(string.Format(uri, Token), Method.POST);

            return request;
        }

        /// <summary>
        /// Called when [get updates error].
        /// </summary>
        /// <param name="exception">The exception.</param>
        protected virtual void OnGetUpdatesError(Exception exception)
        {
            GetUpdatesError?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
        }

        /// <summary>
        /// Gets information about your bot. You can call this method as a ping
        /// </summary>
        public UserInfoResult GetsMe()
        {
            return ExecuteRequest<UserInfoResult>(NewRestRequest(getMeUri)) as UserInfoResult;
        }

        /// <summary>
        /// Use this method to send text messages. See <see href="https://core.telegram.org/bots/api#sendmessage">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="text">Text of the message to be sent</param>
        /// <param name="parseMode">Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message</param>
        /// <param name="disableNotification">Sends the message silently. iOS users will not receive a notification, Android users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. 
        /// A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned.</returns>
        public SendMessageResult SendMessage(object chatId, string text,
            ParseMode? parseMode = null,
            bool? disableWebPagePreview = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendMessageUri);
            
            request.AddParameter("chat_id", chatId);
            request.AddParameter("text", text);
            if (parseMode != null)
                request.AddParameter("parse_mode", parseMode.Value);
            if (disableWebPagePreview.HasValue)
                request.AddParameter("disable_web_page_preview", disableWebPagePreview.Value);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId.HasValue)
                request.AddParameter("reply_to_message_id", replyToMessageId.Value);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to forward messages of any kind. See <see href="https://core.telegram.org/bots/api#forwardmessage">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="fromChatId">Unique identifier for the chat where the original message was sent — User or GroupChat id</param>
        /// <param name="messageId">Unique message identifier</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned.</returns>
        public SendMessageResult ForwardMessage(object chatId, int fromChatId, 
            int messageId,
            bool? disableNotification = null)
        {
            RestRequest request = NewRestRequest(forwardMessageUri);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("from_chat_id", fromChatId);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            request.AddParameter("message_id", messageId);

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send photos. See <see href="https://core.telegram.org/bots/api#sendphoto">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="photo">Photo to send. You can either pass a file_id as String to resend a photo that is already on the Telegram servers (using ExistingFile class),
        /// or upload a new photo using multipart/form-data. (Using NewFile class)</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="disableNotification">Sends the message silently. iOS users will not receive a notification, Android users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. 
        /// A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned.</returns>
        public SendMessageResult SendPhoto(object chatId, IFile photo,
            string caption = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendPhotoUri);
            request.AddParameter("chat_id", chatId);
            ExistingFile file = photo as ExistingFile;
            if (file != null)
            {
                ExistingFile existingFile = file;
                request.AddParameter("photo", existingFile.FileId);
            }
            else
            {
                NewFile newFile = (NewFile)photo;
                request.AddFile("photo", newFile.FileContent, newFile.FileName);
            }
            if (!string.IsNullOrEmpty(caption))
                request.AddParameter("caption", caption);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message.
        /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). 
        /// Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// See <see href="https://core.telegram.org/bots/api#sendaudio">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="audio">Audio file to send. You can either pass a file_id as String to resend an audio that is already on the Telegram servers,
        /// or upload a new audio file using multipart/form-data.</param>
        /// <param name="caption">Audio caption, 0-200 characters</param>
        /// <param name="duration">Duration of the audio in seconds</param> 
        /// <param name="performer">Duration of the audio in seconds</param>
        /// <param name="title">Track name</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param> 
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. 
        /// A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned.</returns>
        public SendMessageResult SendAudio(object chatId, IFile audio,
            string caption = null,
            int? duration = null,
            string performer = null,
            string title = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendAudioUri);
            request.AddParameter("chat_id", chatId);

            ExistingFile file = audio as ExistingFile;
            if (file != null)
            {
                ExistingFile existingFile = file;
                request.AddParameter("audio", existingFile.FileId);
            }
            else
            {
                NewFile newFile = (NewFile)audio;
                request.AddFile("audio", newFile.FileContent, newFile.FileName);
            }

            if (!string.IsNullOrEmpty(caption))
                request.AddParameter("caption", caption);
            if (duration != null)
                request.AddParameter("duration", duration);
            if (!string.IsNullOrEmpty(performer))
                request.AddParameter("performer", performer);
            if (!string.IsNullOrEmpty(title))
                request.AddParameter("title", title);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send general files. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// See <see href="https://core.telegram.org/bots/api#senddocument">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="document">File to send. You can either pass a file_id as String to resend a file that is already on the Telegram servers,
        /// or upload a new file using multipart/form-data.</param>
        /// <param name="caption">Document caption (may also be used when resending documents by file_id), 0-200 characters</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param> 
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned.</returns>
        public SendMessageResult SendDocument(object chatId, IFile document,
            string caption = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendDocumentUri);
            request.AddParameter("chat_id", chatId);

            ExistingFile file = document as ExistingFile;
            if (file != null)
            {
                ExistingFile existingFile = file;
                request.AddParameter("document", existingFile.FileId);
            }
            else
            {
                NewFile newFile = (NewFile)document;
                request.AddFile("document", newFile.FileContent, newFile.FileName);
            }

            if (!string.IsNullOrEmpty(caption))
                request.AddParameter("caption", caption);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send .webp stickers. See <see href="https://core.telegram.org/bots/api#sendsticker">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="sticker">Sticker to send. You can either pass a file_id as String to resend a sticker that is 
        /// already on the Telegram servers, or upload a new sticker using multipart/form-data.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param> 
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="MessageInfo"/> is returned.</returns>
        public SendMessageResult SendSticker(object chatId, IFile sticker,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendStickerUri);
            request.AddParameter("chat_id", chatId);

            ExistingFile file = sticker as ExistingFile;

            if (file != null)
            {
                ExistingFile existingFile = file;
                request.AddParameter("sticker", existingFile.FileId);
            }
            else
            {
                NewFile newFile = (NewFile)sticker;
                request.AddFile("sticker", newFile.FileContent, newFile.FileName);
            }

            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document). 
        /// Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future. See <see href="https://core.telegram.org/bots/api#sendvideo"></see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="video">Video to send. You can either pass a file_id as String to resend a video that is already on the Telegram servers,
        /// or upload a new video file using multipart/form-data.</param>
        /// <param name="duration">Optional. Duration of sent video in seconds</param>
        /// <param name="width">Optional. Video width</param> 
        /// <param name="height">Video height</param>
        /// <param name="caption">Optional. Video caption (may also be used when resending videos by file_id), 0-200 characters</param>
        /// <param name="disableNotification">Optional. Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="MessageInfo"/> is returned.</returns>
        public SendMessageResult SendVideo(object chatId, IFile video,
            int? duration = null,
            int? width = null,
            int? height = null,
            string caption = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendVideoUri);
            request.AddParameter("chat_id", chatId);

            ExistingFile file = video as ExistingFile;

            if (file != null)
            {
                ExistingFile existingFile = file;
                request.AddParameter("video", existingFile.FileId);
            }
            else
            {
                NewFile newFile = (NewFile)video;
                request.AddFile("video", newFile.FileContent, newFile.FileName);
            }

            if (duration != null)
                request.AddParameter("duration", duration);
            if (width != null)
                request.AddParameter("width", width);
            if (height != null)
                request.AddParameter("height", height);
            if (!string.IsNullOrEmpty(caption))
                request.AddParameter("caption", caption);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        //todo sendVoice (https://core.telegram.org/bots/api#sendvoice)

        /// <summary>
        /// As of v.4.0, Telegram clients support rounded square mp4 videos of up to 1 minute long.
        /// Use this method to send video messages.
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="videoNote">Video note to send. Pass a file_id as String to send a video note that exists on the Telegram servers (recommended) 
        /// or upload a new video using multipart/form-data. 
        /// Sending video notes by a URL is currently unsupported</param>
        /// <param name="duration">Optional. Duration of sent video in seconds</param>
        /// <param name="length">Optional. Video width and height</param>
        /// <param name="disableNotification">Optional. Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. 
        /// A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="MessageInfo"/> is returned</returns>
        public SendMessageResult SendVideoNote(object chatId, IFile videoNote,
            int? duration = null,
            int? length = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendVideoNoteUri);
            request.AddParameter("chat_id", chatId);

            ExistingFile file = videoNote as ExistingFile;

            if (file != null)
            {
                ExistingFile existingFile = file;
                request.AddParameter("video_note", existingFile.FileId);
            }
            else
            {
                NewFile newFile = (NewFile) videoNote;
                request.AddFile("video_note", newFile.FileContent, newFile.FileName);
            }

            if (duration != null)
                request.AddParameter("duration", duration);
            if (length != null)
                request.AddParameter("length", length);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send point on the map.
        /// See <see href="https://core.telegram.org/bots/api#sendlocation">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="latitude">Latitude of location</param>
        /// <param name="longitude">Longitude of location</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="MessageInfo"/> is returned.</returns>
        public SendMessageResult SendLocation(object chatId, float latitude, float longitude,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendLocationUri);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("latitude", latitude);
            request.AddParameter("longitude", longitude);

            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send information about a venue.
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="latitude">Latitude of the venue</param>
        /// <param name="longitude">Longitude of the venue</param>
        /// <param name="title">Name of the venue</param>
        /// <param name="address">Address of the venue</param>
        /// <param name="foursquareId">Foursquare identifier of the venue</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for an 
        /// inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned</returns>
        public SendMessageResult SendVenue(object chatId, float latitude, float longitude, string title, string address, 
            string foursquareId = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendVenueUri);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("latitude", latitude);
            request.AddParameter("longitude", longitude);
            request.AddParameter("title", title);
            request.AddParameter("address", address);

            if (!string.IsNullOrEmpty(foursquareId))
                request.AddParameter("foursquare_id", foursquareId);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to send phone contacts. See <see href="https://core.telegram.org/bots/api#sendcontact">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="phoneNumber">Contact's phone number</param>
        /// <param name="firstName">Contact's first name</param>
        /// <param name="lastName">Contact's last name</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard,
        /// instructions to remove keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent <see cref="MessageInfo"/> is returned.</returns>
        public SendMessageResult SendContact(object chatId, string phoneNumber, string firstName,
            string lastName = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(sendContactUri);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("phone_number", phoneNumber);
            request.AddParameter("first_name", firstName);

            if (!string.IsNullOrEmpty(lastName))
                request.AddParameter("last_name", lastName);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            
            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method when you need to tell the user that something is happening on the bot's side. 
        /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
        /// See <see href="https://core.telegram.org/bots/api#sendchataction">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="action">Type of action to broadcast. Choose one, depending on what the user is about to receive: 
        /// typing for text messages, upload_photo for photos, record_video or upload_video for videos, 
        /// record_audio or upload_audio for audio files, upload_document for general files, find_location for location data.</param>
        public BooleanResult SendChatAction(object chatId, ChatActions action)
        {
            RestRequest request = NewRestRequest(sendChatActionUri);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("action", action.ToString().ToLower());

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// Use this method to get a list of profile pictures for a user.
        /// See <see href="https://core.telegram.org/bots/api#getuserprofilephotos">API</see>
        /// </summary>
        /// <param name="userId">Unique identifier of the target user</param>
        /// <param name="offset">Sequential number of the first photo to be returned. By default, all photos are returned.</param>
        /// <param name="limit">Limits the number of photos to be retrieved. Values between 1—100 are accepted. Defaults to 100.</param>
        /// <returns><see cref="UserProfilePhotosInfo"/></returns>
        public GetUserProfilePhotosResult GetUserProfilePhotos(int userId, int? offset = null, byte? limit = null)
        {
            RestRequest request = NewRestRequest(getUserProfilePhotosUri);

            request.AddParameter("user_id", userId);
            if (offset.HasValue)
                request.AddParameter("offset", offset.Value);
            if (limit.HasValue)
                request.AddParameter("limit", limit.Value);

            return ExecuteRequest<GetUserProfilePhotosResult>(request) as GetUserProfilePhotosResult;
        }

        //todo getFile (https://core.telegram.org/bots/api#getfile)

        /// <summary>
        /// Use this method to kick a user from a group, a supergroup or a channel. 
        /// In the case of supergroups and channels, the user will not be able to return to the group on their own using invite links, etc., 
        /// unless unbanned first. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. 
        /// See <see href="https://core.telegram.org/bots/api#kickchatmember">API</see> 
        /// </summary>
        /// <param name="chatId">Unique identifier for the target group or username of the target supergroup or channel</param>
        /// <param name="userId">Unique identifier of the target user</param>
        /// <param name="untilDate">Date when the user will be unbanned. 
        /// If user is banned for more than 366 days or less than 30 seconds from the current time they are considered to be banned forever</param>
        /// <returns>Returns True on success, false otherwise</returns>
        public BooleanResult KickChatMember(object chatId, int userId, DateTime untilDate)
        {
            RestRequest request = NewRestRequest(kickChatMemberUri);

            request.AddParameter("chat_id", chatId);
            request.AddParameter("user_id", userId);
            request.AddParameter("until_date", untilDate.ToUnixTime());

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// Use this method to unban a previously kicked user in a supergroup or channel. 
        /// The user will not return to the group or channel automatically, but will be able to join via link, etc. 
        /// The bot must be an administrator for this to work.
        /// See <see href="https://core.telegram.org/bots/api#unbanchatmember">API</see> 
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="userId">Unique identifier of the target user</param>
        /// <returns>Returns True on success, false otherwise</returns>
        public BooleanResult UnbanChatMember(object chatId, int userId)
        {
            RestRequest request = NewRestRequest(unbanChatMemberUri);

            request.AddParameter("chat_id", chatId);
            request.AddParameter("user_id", userId);

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// Use this method for your bot to leave a group, supergroup or channel.
        /// See <see href="https://core.telegram.org/bots/api#leavechat">API</see> 
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat</param>
        /// <returns>Returns True on success, false otherwise</returns>
        public BooleanResult LeaveChat(object chatId)
        {
            RestRequest request = NewRestRequest(leaveChatUri);

            request.AddParameter("chat_id", chatId);

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }
        
        /// <summary>
        /// Use this method to get up to date information about the chat (current name of the user for one-on-one conversations, current username of a user, group or channel, etc.). 
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <returns>Returns a <see cref="ChatInfoResult"/> object on success.</returns>
        public ChatInfoResult GetChat(object chatId)
        {
            RestRequest request = NewRestRequest(getChatUri);

            request.AddParameter("chat_id", chatId);

            return ExecuteRequest<ChatInfoResult>(request) as ChatInfoResult;
        }

        //todo getChatAdministrators (https://core.telegram.org/bots/api#getchatadministrators)
        //todo getChatMembersCount (https://core.telegram.org/bots/api#getchatmemberscount)


        /// <summary>
        /// Use this method to get the number of members in a chat. Returns <see cref="IntegerResult"/> on success
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public IntegerResult GetChatMembersCount(object chatId)
        {
            RestRequest request = NewRestRequest(getChatMembersCountUri);

            request.AddParameter("chat_id", chatId);

            return ExecuteRequest<IntegerResult>(request) as IntegerResult;
        }

        //todo getChatMember (https://core.telegram.org/bots/api#getchatmember)
        //todo answerCallbackQuery (https://core.telegram.org/bots/api#answercallbackquery)
        //todo Inline mode methods (https://core.telegram.org/bots/api#inline-mode-methods)

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
        /// Called when [updates received].
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
                if (typeof(T) == typeof (SendMessageResult))
                    return new SendMessageResult(response.Content);

                if (typeof (T) == typeof (BooleanResult))
                    return new BooleanResult(response.Content);

                if (typeof(T) == typeof(UserInfoResult))
                    return new UserInfoResult(response.Content);

                if (typeof(T) == typeof (GetUserProfilePhotosResult))
                    return new GetUserProfilePhotosResult(response.Content);

                if (typeof(T) == typeof (GetUpdatesResult))
                    return new GetUpdatesResult(response.Content);

                if (typeof(T) == typeof (ChatInfoResult))
                    return new ChatInfoResult(response.Content);

                if (typeof(T) == typeof (IntegerResult))
                    return new IntegerResult(response.Content);
            }

            throw new Exception(response.StatusDescription);
        }
    }
}

using RestSharp;
using System;
using System.Runtime.CompilerServices;
using NetTelebot.BotEnum;
using NetTelebot.Interface;
using NetTelebot.Result;
using NetTelebot.Type;
using NetTelebot.Extension;
using NetTelebot.Type.Payment;


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

    /* About this partial class
     * 
     * in this part of the class, only the methods that work with the api telegram.
     * 
     */

    public partial class TelegramBotClient
    {
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
        private const string mAnswerShippingQueryUri = "/bot{0}/answerShippingQuery";
        private const string mSendInvoiceUri = "/bot{0}/sendInvoice";

        private RestRequest NewRestRequest(string uri)
        {
            RestRequest request = new RestRequest(string.Format(uri, Token), Method.POST);

            return request;
        }

        /// <summary>
        /// Gets information about your bot. You can call this method as a ping
        /// </summary>
        public UserInfoResult GetsMe()
        {
            return ExecuteRequest<UserInfoResult>(NewRestRequest(mGetMeUri)) as UserInfoResult;
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
            RestRequest request = NewRestRequest(mSendMessageUri);

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
            RestRequest request = NewRestRequest(mForwardMessageUri);
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
            RestRequest request = NewRestRequest(mSendPhotoUri);
            request.AddParameter("chat_id", chatId);
            request = AddFile(photo, request, "photo");

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
            RestRequest request = NewRestRequest(mSendAudioUri);
            request.AddParameter("chat_id", chatId);
            request = AddFile(audio, request, "audio");

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
            RestRequest request = NewRestRequest(mSendDocumentUri);
            request.AddParameter("chat_id", chatId);
            request = AddFile(document, request, "document");

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
            RestRequest request = NewRestRequest(mSendStickerUri);
            request.AddParameter("chat_id", chatId);
            request = AddFile(sticker, request, "sticker");

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
            RestRequest request = NewRestRequest(mSendVideoUri);
            request.AddParameter("chat_id", chatId);
            request = AddFile(video, request, "video");

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

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. 
        /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Audio or Document).
        /// On success, the sent Message is returned. Bots can currently send voice messages of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="voice">Audio file to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), 
        /// pass an HTTP URL as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data</param>
        /// <param name="caption">Voice message caption, 0-200 characters </param>
        /// <param name="duration">Duration of the voice message in seconds </param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, 
        /// instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns></returns>
        public SendMessageResult SendVoice(object chatId, IFile voice,
            string caption = null,
            int? duration = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(mSendVoiceUri);
            request.AddParameter("chat_id", chatId);
            request = AddFile(voice, request, "voice");

            if (!string.IsNullOrEmpty(caption))
                request.AddParameter("caption", caption);
            if (duration != null)
                request.AddParameter("duration", duration);
            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

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
            RestRequest request = NewRestRequest(mSendVideoNoteUri);
            request.AddParameter("chat_id", chatId);
            request = AddFile(videoNote, request, "video_note");

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
            RestRequest request = NewRestRequest(mSendLocationUri);
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
            RestRequest request = NewRestRequest(mSendVenueUri);
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
            RestRequest request = NewRestRequest(mSendContactUri);
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
            RestRequest request = NewRestRequest(mSendChatActionUri);
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
            RestRequest request = NewRestRequest(mGetUserProfilePhotosUri);

            request.AddParameter("user_id", userId);
            if (offset.HasValue)
                request.AddParameter("offset", offset.Value);
            if (limit.HasValue)
                request.AddParameter("limit", limit.Value);

            return ExecuteRequest<GetUserProfilePhotosResult>(request) as GetUserProfilePhotosResult;
        }

        /// <summary>
        /// Use this method to get basic info about a file and prepare it for downloading.
        /// For the moment, bots can download files of up to 20MB in size. 
        /// The file can then be downloaded via the link https://api.telegram.org/file/botToken/file_path, where file_path is taken from the response. 
        /// It is guaranteed that the link will be valid for at least 1 hour. When the link expires, a new one can be requested by calling getFile again.
        /// </summary>
        /// <param name="fileId">File identifier to get info about</param>
        /// <returns>On success, a <see cref="FileInfo"/> is returned.</returns>
        public FileInfoResult GetFile(string fileId)
        {
            RestRequest request = NewRestRequest(mGetFileUri);

            request.AddParameter("file_id", fileId);
            return ExecuteRequest<FileInfoResult>(request) as FileInfoResult;
        }

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
            RestRequest request = NewRestRequest(mKickChatMemberUri);

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
            RestRequest request = NewRestRequest(mUnbanChatMemberUri);

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
            RestRequest request = NewRestRequest(mLeaveChatUri);

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
            RestRequest request = NewRestRequest(mGetChatUri);

            request.AddParameter("chat_id", chatId);

            return ExecuteRequest<ChatInfoResult>(request) as ChatInfoResult;
        }

        /// <summary>
        /// Use this method to get a list of administrators in a chat. 
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns>On success, returns an Array of <see cref="ChatMemberInfo"/> objects that contains information about all chat
        /// administrators except other bots. If the chat is a group or a supergroup and no administrators were appointed, only the creator will be returned.</returns>
        public ChatMembersInfoResult GetChatAdministrators(object chatId)
        {
            RestRequest request = NewRestRequest(mGetChatAdministratorsUri);

            request.AddParameter("chat_id", chatId);

            return ExecuteRequest<ChatMembersInfoResult>(request) as ChatMembersInfoResult;
        }

        /// <summary>
        /// Use this method to get the number of members in a chat. 
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <returns>Returns <see cref="IntegerResult"/> on success</returns>
        public IntegerResult GetChatMembersCount(object chatId)
        {
            RestRequest request = NewRestRequest(mGetChatMembersCountUri);

            request.AddParameter("chat_id", chatId);

            return ExecuteRequest<IntegerResult>(request) as IntegerResult;
        }

        /// <summary>
        /// Use this method to get information about a member of a chat. 
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <param name="userId">Unique identifier of the target user</param>
        /// <returns>Returns a <see cref="ChatMemberInfo"/> object on success.</returns>
        public ChatMemberInfoResult GetChatMember(object chatId, int userId)
        {
            RestRequest request = NewRestRequest(mGetChatMemberUri);

            request.AddParameter("chat_id", chatId);
            request.AddParameter("user_id", userId);

            return ExecuteRequest<ChatMemberInfoResult>(request) as ChatMemberInfoResult;
        }

        /// <summary>
        /// Use this method to send answers to callback queries sent from inline keyboards. 
        /// The answer will be displayed to the user as a notification at the top of the chat screen or as an alert. 
        /// 
        /// Note: Alternatively, the user can be redirected to the specified Game URL. 
        /// For this option to work, you must first create a game for your bot via @Botfather and accept the terms. 
        /// Otherwise, you may use links like t.me/your_bot?start=XXXX that open your bot with a parameter.
        /// </summary>
        /// <param name="callbackQueryId">Unique identifier for the query to be answered</param>
        /// <param name="text">Text of the notification. If not specified, nothing will be shown to the user, 0-200 characters</param>
        /// <param name="showAlert">If true, an alert will be shown by the client instead of a notification at the top of the chat screen. Defaults to false.</param>
        /// <param name="url">URL that will be opened by the user's client. If you have created a Game and accepted the conditions via @Botfather, 
        /// specify the URL that opens your game – note that this will only work if the query comes from a callback_game button. 
        /// Otherwise, you may use links like t.me/your_bot?start=XXXX that open your bot with a parameter.</param>
        /// <param name="cacheTime">The maximum amount of time in seconds that the result of the callback query may be cached client-side. 
        /// Telegram apps will support caching starting in version 3.14. Defaults to 0.</param>
        /// <returns>On success, True is returned.</returns>
        public BooleanResult AswerCallbackQuery(string callbackQueryId,
            string text = null,
            bool? showAlert = null,
            string url = null,
            int? cacheTime = null)
        {
            RestRequest request = NewRestRequest(mAnswerCallbackQueryUri);

            request.AddParameter("callback_query_id", callbackQueryId);

            if (!string.IsNullOrEmpty(text))
                request.AddParameter("text", text);
            if (showAlert.HasValue)
                request.AddParameter("show_alert", showAlert.Value);
            if (!string.IsNullOrEmpty(url))
                request.AddParameter("url", url);
            if (cacheTime != null)
                request.AddParameter("cache_time", cacheTime);

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// If you sent an invoice requesting a shipping address and the parameter is_flexible was specified, 
        /// the Bot API will send an <see href="https://core.telegram.org/bots/api#update">Update</see> with a shipping_query field to the bot. 
        /// Use this method to reply to shipping queries.
        /// </summary>
        /// <param name="shippingQueryId">Unique identifier for the query to be answered</param>
        /// <param name="ok">Specify True if delivery to the specified address is possible and False if there are any problems 
        /// (for example, if delivery to the specified address is not possible)</param>
        /// <param name="shippingOption">Required if ok is True. 
        /// A JSON-serialized array of available shipping options.</param>
        /// <param name="errorMessage">Required if ok is False. 
        /// Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable'). 
        /// Telegram will display this message to the user.</param>
        /// <returns>On success, True is returned.</returns>
        public BooleanResult AnswerShippingQuery(string shippingQueryId, bool ok, 
            ShippingOptionInfo[] shippingOption = null, 
            string errorMessage = null)
        {
            RestRequest request = NewRestRequest(mAnswerShippingQueryUri);

            request.AddParameter("shipping_query_id", shippingQueryId);
            request.AddParameter("ok", ok);

            if(shippingOption != null)
                request.AddParameter("shipping_options", ShippingOptionInfo.GetJson(shippingOption));
            if (errorMessage != null)
                request.AddParameter("error_message", errorMessage);

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// Use this method to send invoices. See <see href="https://core.telegram.org/bots/api#sendinvoice">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target private chat</param>
        /// <param name="title">Product name, 1-32 characters</param>
        /// <param name="description">Product description, 1-255 characters</param>
        /// <param name="payload">Bot-defined invoice payload, 1-128 bytes. 
        /// This will not be displayed to the user, use for your internal processes.</param>
        /// <param name="providerToken">Payments provider token, obtained via Botfather</param>
        /// <param name="startParameter">Unique deep-linking parameter that can be used to generate this invoice when used as a start parameter</param>
        /// <param name="currency">Three-letter ISO 4217 currency code</param>
        /// <param name="labeledPrice">Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)</param>
        /// <param name="photoUrl">URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service. 
        /// People like it better when they see what they are paying for.</param>
        /// <param name="photoSize">Photo size</param>
        /// <param name="photoWidth">Photo width</param>
        /// <param name="photoHeight">Photo height</param>
        /// <param name="needName">Pass True, if you require the user's full name to complete the order</param>
        /// <param name="needPhoneNumber">Pass True, if you require the user's phone number to complete the order</param>
        /// <param name="needEmail">Pass True, if you require the user's email to complete the order</param>
        /// <param name="needShippingAdress">Pass True, if you require the user's shipping address to complete the order</param>
        /// <param name="isFlexible">Pass True, if the final price depends on the shipping method</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">A JSON-serialized object for an inline keyboard. 
        /// If empty, one 'Pay total price' button will be shown. If not empty, the first button must be a Pay button.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned.</returns>
        public SendMessageResult SendInvoice(string chatId, 
            string title, 
            string description,
            string payload, 
            string providerToken, 
            string startParameter, 
            Currency currency, 
            LabeledPriceInfo[] labeledPrice,
            string photoUrl = null, 
            int? photoSize = null, 
            int? photoWidth = null, 
            int? photoHeight = null,
            bool? needName = null, 
            bool? needPhoneNumber = null,  
            bool? needEmail = null, 
            bool? needShippingAdress = null,
            bool? isFlexible = null, 
            bool? disableNotification = null, 
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(mSendInvoiceUri);

            request.AddParameter("chat_id", chatId);
            request.AddParameter("title", title);
            request.AddParameter("description", description);
            request.AddParameter("payload", payload);
            request.AddParameter("provider_token", providerToken);
            request.AddParameter("start_parameter", startParameter);
            request.AddParameter("currency", currency.ToString());
            request.AddParameter("prices", LabeledPriceInfo.GetJsonArray(labeledPrice));

            if (photoUrl != null)
                request.AddParameter("photo_url", photoUrl);
            if (photoSize != null)
                request.AddParameter("photo_size", photoSize);
            if (photoWidth != null)
                request.AddParameter("photo_width", photoWidth);
            if (photoHeight != null)
                request.AddParameter("photo_height", photoHeight);

            request.AddParameter("need_name", needName ?? false);
            request.AddParameter("need_phone_number", needPhoneNumber ?? false);
            request.AddParameter("need_email", needEmail ?? false);
            request.AddParameter("need_shipping_address", needShippingAdress ?? false);
            request.AddParameter("is_flexible", isFlexible ?? false);

            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        //todo Inline mode methods (https://core.telegram.org/bots/api#inline-mode-methods)

        private static RestRequest AddFile(IFile iFile, RestRequest request, string name)
        {
            ExistingFile file = iFile as ExistingFile;

            if (file?.FileId != null)
            {
                request.AddParameter(name, file.FileId);
            }
            else if(file?.Url != null)
            {
                request.AddParameter(name, file.Url);
            }
            else
            {
                NewFile newFile = (NewFile)iFile;
                request.AddFile(name, newFile.FileContent, newFile.FileName);
            }

            return request;
        }
    }
}

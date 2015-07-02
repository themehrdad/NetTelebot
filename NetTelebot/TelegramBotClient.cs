using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class TelegramBotClient
    {
        public string Token { get; set; }
        public int CheckInterval { get; set; } = 1000;
        private const string getMeUri = "/bot{0}/getMe";
        private const string getUpdatesUri = "/bot{0}/getUpdates";
        private const string sendMessageUri = "/bot{0}/sendMessage";
        private const string forwardMessageUri = "/bot{0}/forwardMessage";
        private const string sendPhotoUri = "/bot{0}/sendPhoto";
        private const string sendAudioUri = "/bot{0}/sendAudio";
        private const string sendDocumentUri = "/bot{0}/sendDocument";
        private const string sendStickerUri = "/bot{0}/sendSticker";
        private const string sendVideoUri = "/bot{0}/sendVideo";
        private const string sendLocationUri = "/bot{0}/sendLocation";
        private const string sendChatActionUri = "/bot{0}/sendChatAction";
        private const string getUserProfilePhotosUri = "/bot{0}/getUserProfilePhotos";

        private RestClient restClient = new RestClient("https://api.telegram.org");
        private Timer updateTimer;
        private int lastUpdateId = 0;
        public event EventHandler<TelegramUpdateEventArgs> UpdatesReceived;

        public MeInfo GetMe()
        {
            var request = new RestRequest(string.Format(getMeUri, Token), Method.GET);
            var response = restClient.Execute(request);
            return new MeInfo(response.Content);
        }


        public GetUpdatesResult GetUpdates()
        {
            return GetUpdatesInternal(null, null);
        }

        public GetUpdatesResult GetUpdates(int offset)
        {
            return GetUpdatesInternal(offset, null);
        }

        public GetUpdatesResult GetUpdates(int offset, byte limit)
        {
            return GetUpdatesInternal(offset, limit);
        }

        public GetUpdatesResult GetUpdates(byte limit)
        {
            return GetUpdatesInternal(null, limit);
        }

        private GetUpdatesResult GetUpdatesInternal(int? offset, byte? limit)
        {
            var request = new RestRequest(string.Format(getUpdatesUri, Token), Method.GET);
            if (offset.HasValue)
                request.AddQueryParameter("offset", offset.Value.ToString());
            if (limit.HasValue)
                request.AddQueryParameter("limit", limit.Value.ToString());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new GetUpdatesResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult SendMessage(int chatId, string text,
            bool? disableWebPagePreview = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            var request = new RestRequest(string.Format(sendMessageUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("text", text);
            if (disableWebPagePreview.HasValue)
                request.AddParameter("disable_web_page_preview", disableWebPagePreview.Value);
            if (replyToMessageId.HasValue)
                request.AddParameter("reply_to_message_id", replyToMessageId.Value);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult ForwardMessage(int chatId, int fromChatId, int messageId)
        {
            var request = new RestRequest(string.Format(forwardMessageUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("from_chat_id", fromChatId);
            request.AddParameter("message_id", messageId);
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult SendPhoto(int chatId, IFile photo,
            string caption = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            var request = new RestRequest(string.Format(sendPhotoUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            if (photo is ExistingFile)
            {
                var existingFile = (ExistingFile)photo;
                request.AddParameter("photo", existingFile.FileId);
            }
            else
            {
                var newFile = (NewFile)photo;
                request.AddFile("photo", newFile.FileContent, newFile.FileName);
            }
            if (!string.IsNullOrEmpty(caption))
                request.AddParameter("caption", caption);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult SendAudio(int chatId, IFile audio,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            var request = new RestRequest(string.Format(sendAudioUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            if (audio is ExistingFile)
            {
                var existingFile = (ExistingFile)audio;
                request.AddParameter("audio", existingFile.FileId);
            }
            else
            {
                var newFile = (NewFile)audio;
                request.AddFile("audio", newFile.FileContent, newFile.FileName);
            }
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult SendDocument(int chatId, IFile document,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            var request = new RestRequest(string.Format(sendDocumentUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            if (document is ExistingFile)
            {
                var existingFile = (ExistingFile)document;
                request.AddParameter("document", existingFile.FileId);
            }
            else
            {
                var newFile = (NewFile)document;
                request.AddFile("document", newFile.FileContent, newFile.FileName);
            }
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult SendSticker(int chatId, IFile sticker,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            var request = new RestRequest(string.Format(sendStickerUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            if (sticker is ExistingFile)
            {
                var existingFile = (ExistingFile)sticker;
                request.AddParameter("sticker", existingFile.FileId);
            }
            else
            {
                var newFile = (NewFile)sticker;
                request.AddFile("sticker", newFile.FileContent, newFile.FileName);
            }
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult SendVideio(int chatId, IFile video,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            var request = new RestRequest(string.Format(sendVideoUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            if (video is ExistingFile)
            {
                var existingFile = (ExistingFile)video;
                request.AddParameter("video", existingFile.FileId);
            }
            else
            {
                var newFile = (NewFile)video;
                request.AddFile("video", newFile.FileContent, newFile.FileName);
            }
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public SendMessageResult SendLocation(int chatId, float latitude, float longitude,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            var request = new RestRequest(string.Format(sendLocationUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("latitude", latitude);
            request.AddParameter("longitude", longitude);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new SendMessageResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }

        public void SendChatAction(int chatId, ChatActions action)
        {
            var request = new RestRequest(string.Format(sendChatActionUri, Token), Method.POST);
            request.AddParameter("chat_id", chatId);
            request.AddParameter("action", action.ToString().ToLower());
            var response = restClient.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response.StatusDescription);
        }

        public GetUserProfilePhotosResult GetUserProfilePhotos(int userId, int? offset=null, byte? limit=null)
        {
            var request = new RestRequest(string.Format(getUserProfilePhotosUri, Token), Method.POST);
            request.AddParameter("user_id", userId);
            if (offset.HasValue)
                request.AddParameter("offset", offset.Value);
            if (limit.HasValue)
                request.AddParameter("limit", limit.Value);
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return new GetUserProfilePhotosResult(response.Content);
            else
                throw new Exception(response.StatusDescription);
        }
        public void StartCheckingUpdates()
        {
            if (updateTimer == null)
            {
                updateTimer = new Timer(updateTimer_Callback, null, CheckInterval, Timeout.Infinite);
            }
            else
            {
                updateTimer.Change(CheckInterval, Timeout.Infinite);
            }
        }

        public void StopCheckUpdates()
        {
            updateTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void updateTimer_Callback(object state)
        {
            GetUpdatesResult updates = null;
            if (lastUpdateId == 0)
            {
                updates = GetUpdates();
            }
            else
            {
                updates = GetUpdates(lastUpdateId + 1);
            }
            if (updates.Ok && updates.Result != null && updates.Result.Any())
            {
                lastUpdateId = updates.Result.Last().UpdateId;
                OnUpdatesReceived(updates.Result);
            }
            updateTimer.Change(CheckInterval, Timeout.Infinite);
        }

        protected virtual void OnUpdatesReceived(UpdateInfo[] updates)
        {
            var args = new TelegramUpdateEventArgs(updates);
            if (UpdatesReceived != null)
            {
                UpdatesReceived(this, args);
            }
        }
    }
}

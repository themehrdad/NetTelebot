using NetTelebot.Interface;
using NetTelebot.Result;
using NetTelebot.Type;
using NetTelebot.Type.Sticker;
using Newtonsoft.Json;
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
     * Part of the class, for work with sticker methods.
     * See API https://core.telegram.org/bots/api#stickers
     * 
     */

    public partial class TelegramBotClient
    {
        private const string mSendStickerUri = "/bot{0}/sendSticker";
        private const string mGetStickerSetUri = "/bot{0}/getStickerSet";
        private const string mAddStickerToSet = "/bot{0}/addStickerToSet";
        private const string mSetStickerPositionInSetUri = "/bot{0}/setStickerPositionInSet";
        private const string mDeleteStickerFromSetUri = "/bot{0}/deleteStickerFromSet";

        /// <summary>
        /// Use this method to send .webp stickers. 
        /// See <see href="https://core.telegram.org/bots/api#sendsticker">API</see>
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
        /// Use this method to get a sticker set
        /// See <see href="https://core.telegram.org/bots/api#getstickerset">API</see>
        /// </summary>
        /// <param name="name">Name of the sticker set</param>
        /// <returns>On success, a <see cref="StickerSetInfoResult"/> is returned.</returns>
        public StickerSetInfoResult GetStickerSet(string name)
        {
            RestRequest request = NewRestRequest(mGetStickerSetUri);

            request.AddParameter("name", name);

            return ExecuteRequest<StickerSetInfoResult>(request) as StickerSetInfoResult; 
        }

        /// <summary>
        /// Use this method to add a new sticker to a set created by the bot.
        /// See <see href="https://core.telegram.org/bots/api#addstickertoset">API</see>
        /// </summary>
        /// <param name="userId">User identifier of sticker set owner</param>
        /// <param name="name">Sticker set name</param>
        /// <param name="pngSticker">Png image with the sticker, must be up to 512 kilobytes in size, 
        /// dimensions must not exceed 512px, and either width or height must be exactly 512px. 
        /// Pass a file_id as a String to send a file that already exists on the Telegram servers, 
        /// pass an HTTP URL as a String for Telegram to get a file from the Internet, 
        /// or upload a new one using multipart/form-data.</param>
        /// <param name="emojis">One or more emoji corresponding to the sticker</param>
        /// <param name="maskPosition">A JSON-serialized object for position where the mask should be placed on faces</param>
        /// <returns>True on success.</returns>
        public BooleanResult AddStickerToSet(int userId, string name, 
            IFile pngSticker, 
            string emojis, 
            MaskPositionInfo maskPosition = null)
        {
            RestRequest request = NewRestRequest(mAddStickerToSet);

            request.AddParameter("userId", userId);
            request.AddParameter("name", name);
            request = AddFile(pngSticker, request, "png_sticker");
            request.AddParameter("emojis", emojis);

            if (maskPosition != null)
                request.AddParameter("mask_position", JsonConvert.SerializeObject(maskPosition));

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// Use this method to move a sticker in a set created by the bot to a specific position.
        /// See <see href="https://core.telegram.org/bots/api#setstickerpositioninset">API</see>
        /// </summary>
        /// <param name="sticker">File identifier of the sticker</param>
        /// <param name="position">New sticker position in the set, zero-based</param>
        /// <returns>True on success</returns>
        public BooleanResult SetStickerPositionInSet(string sticker, int position)
        {
            RestRequest request = NewRestRequest(mSetStickerPositionInSetUri);

            request.AddParameter("sticker", sticker);
            request.AddParameter("position", position);

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// Use this method to delete a sticker from a set created by the bot.
        /// See <see href="https://core.telegram.org/bots/api#deletestickerfromset">API</see>
        /// </summary>
        /// <param name="sticker">File identifier of the sticker </param>
        /// <returns>True on success</returns>
        public BooleanResult DeleteStickerFromSet(string sticker)
        {
            RestRequest request = NewRestRequest(mDeleteStickerFromSetUri);

            request.AddParameter("sticker", sticker);

            return  ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }
    }
}

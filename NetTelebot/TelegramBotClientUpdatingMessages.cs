using NetTelebot.BotEnum;
using NetTelebot.Interface;
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
     * Part of the class for UpdatingMessages methods. 
     * See API https://core.telegram.org/bots/api#updating-messages
     * 
     * Note
     * The following methods allow you to change an existing message in the message history instead of sending a new one with a result of an action. 
     * This is most useful for messages with inline keyboards using callback queries, 
     * but can also help reduce clutter in conversations with regular chat bots.
     *  
     */

    public partial class TelegramBotClient
    {
        private const string mEditMessageTextUri = "/bot{0}/editMessageText";

        /// <summary>
        /// Use this method to edit text and game messages sent by the bot or via the bot (for inline bots).
        /// See <see href="https://core.telegram.org/bots/api#editmessagetext">API</see>
        /// </summary>
        /// <param name="text">New text of the message</param>
        /// <param name="chatId">Required if inline_message_id is not specified. 
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="messageId">Required if inline_message_id is not specified. Identifier of the sent message</param>
        /// <param name="inlineMessageId">Required if chat_id and message_id are not specified. Identifier of the inline message</param>
        /// <param name="parseMode">Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic, 
        /// fixed-width text or inline URLs in your bot's message.</param>
        /// <param name="disableWebPagePreview">Optional. Disables link previews for links in this message.</param>
        /// <param name="replyMarkup">A JSON-serialized object for an inline keyboard. 
        /// Please note, that it is currently only possible to edit messages without reply_markup or with inline keyboards.</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned</returns>
        public SendMessageResult EditMessageText(string text, object chatId = null, int? messageId = null,
            string inlineMessageId = null, ParseMode? parseMode = null, bool? disableWebPagePreview = null,
            IInlineKeyboardMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(mEditMessageTextUri);

            request.AddParameter("text", text);

            if (chatId != null)
                request.AddParameter("chat_id", chatId);
            if (messageId != null)
                request.AddParameter("message_id", messageId);
            if (inlineMessageId != null)
                request.AddParameter("inline_message_id", inlineMessageId);
            if (parseMode != null)
                request.AddParameter("parse_mode", parseMode.Value);
            if (disableWebPagePreview.HasValue)
                request.AddParameter("disable_web_page_preview", disableWebPagePreview.Value);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Use this method to edit captions of messages sent by the bot or via the bot (for inline bots). 
        /// See <see href="https://core.telegram.org/bots/api#editmessagecaption">API</see>
        /// </summary>
        /// <param name="chatId">Required if inline_message_id is not specified. Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="messageId">Required if inline_message_id is not specified. Identifier of the sent message</param>
        /// <param name="inlineMessageId">Required if chat_id and message_id are not specified. Identifier of the inline message</param>
        /// <param name="caption">New caption of the message</param>
        /// <param name="replyMarkup">A JSON-serialized object for an inline keyboard.</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
        public SendMessageResult EditMessageCaption(object chatId = null, int? messageId = null, 
            string inlineMessageId = null, string caption = null, IInlineKeyboardMarkup replyMarkup = null)
        {
            //todo test this
            RestRequest request = NewRestRequest(mEditMessageTextUri);

            if (chatId != null)
                request.AddParameter("chat_id", chatId);
            if (messageId != null)
                request.AddParameter("message_id", messageId);
            if (inlineMessageId != null)
                request.AddParameter("inline_message_id", inlineMessageId);
            if (caption != null)
                request.AddParameter("caption", caption);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }
    }
}

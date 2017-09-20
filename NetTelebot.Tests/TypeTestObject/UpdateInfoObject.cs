using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class UpdateInfoObject
    {
        /// <summary>
        /// This object represents an incoming update.
        /// At most one of the optional parameters can be present in any given update.
        /// See <see href="https://core.telegram.org/bots/api#update">API</see>
        /// </summary>
        /// <param name="updateId">The update‘s unique identifier. 
        /// Update identifiers start from a certain positive number and increase sequentially. 
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.</param>
        /// <param name="message">Optional. New incoming message of any kind — text, photo, sticker, etc.</param>
        /// <param name="editedMessage">Optional. New version of a message that is known to the bot and was edited</param>
        /// <param name="channelPost">Optional. New incoming channel post of any kind — text, photo, sticker, etc.</param>
        /// <param name="editedChannelPost">Optional. New version of a channel post that is known to the bot and was edited</param>
        /// <param name="chosenInlineResult">Optional. The result of an inline query that was chosen by a user and sent to their chat partner.</param>
        /// <param name="callbackQuery">Optional. New incoming callback query</param>
        /// <param name="inlineQuery">Optional. New incoming inline query</param>
        /// <param name="shippingQuery">Optional. New incoming shipping query. Only for invoices with flexible price</param>
        /// <param name="preCheckoutQuery">Optional. New incoming pre-checkout query. Contains full information about checkout</param>
        /// <returns><see cref="UpdateInfo"/></returns>
        internal static JObject GetObject(int updateId, 
            JObject message = null, 
            JObject editedMessage = null, 
            JObject channelPost = null, 
            JObject editedChannelPost = null, 
            JObject inlineQuery = null,
            JObject chosenInlineResult = null,
            JObject callbackQuery = null,
            JObject shippingQuery = null,
            JObject preCheckoutQuery = null)
        {
            dynamic updateInfo = new JObject();

            updateInfo.update_id = updateId;

            if (message != null)
                updateInfo.message = message;
            if (editedMessage != null)
                updateInfo.edited_message = editedMessage;
            if (channelPost != null)
                updateInfo.channel_post = channelPost;
            if (editedChannelPost != null)
                updateInfo.edited_channel_post = editedChannelPost;
            if (inlineQuery != null)
                updateInfo.inline_query = inlineQuery;
            if (chosenInlineResult != null)
                updateInfo.chosen_inline_result = chosenInlineResult;
            if (callbackQuery != null)
                updateInfo.callback_query = callbackQuery;
            if (shippingQuery != null)
                updateInfo.shipping_query = shippingQuery;
            if (preCheckoutQuery != null)
                updateInfo.pre_checkout_query = preCheckoutQuery;

            return updateInfo;
        }

        /// <summary>
        /// Gets the incoming object in array.
        /// See <see href="https://core.telegram.org/bots/api#update">API</see>
        /// </summary>
        /// <param name="updateId">The update‘s unique identifier. 
        /// Update identifiers start from a certain positive number and increase sequentially. 
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.</param>
        /// <param name="message">Optional. New incoming message of any kind — text, photo, sticker, etc.</param>
        /// <param name="editedMessage">Optional. New version of a message that is known to the bot and was edited</param>
        /// <param name="channelPost">Optional. New incoming channel post of any kind — text, photo, sticker, etc.</param>
        /// <param name="editedChannelPost">Optional. New version of a channel post that is known to the bot and was edited</param>
        /// <param name="chosenInlineResult">Optional. The result of an inline query that was chosen by a user and sent to their chat partner.</param>
        /// <param name="callbackQuery">Optional. New incoming callback query</param>
        /// <param name="inlineQuery">Optional. New incoming inline query</param>
        /// <param name="shippingQuery">Optional. New incoming shipping query. Only for invoices with flexible price</param>
        /// <param name="preCheckoutQuery">Optional. New incoming pre-checkout query. Contains full information about checkout</param>
        /// <returns>One object <see cref="UpdateInfo"/> in JArray</returns>
        internal static JArray GetObjectInArray(int updateId,
            JObject message = null,
            JObject editedMessage = null,
            JObject channelPost = null,
            JObject editedChannelPost = null,
            JObject inlineQuery = null,
            JObject chosenInlineResult = null,
            JObject callbackQuery = null,
            JObject shippingQuery = null,
            JObject preCheckoutQuery = null)
        {
            JObject objects = GetObject(updateId, message, editedMessage, channelPost, editedChannelPost,
                inlineQuery, chosenInlineResult, callbackQuery, shippingQuery, preCheckoutQuery);
            return new JArray(objects);
        }
    }
}

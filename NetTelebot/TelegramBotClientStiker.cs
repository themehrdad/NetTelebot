using NetTelebot.Result;
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
        private const string mGetStickerSet = "/bot{0}/getStickerSet";
        private const string mDeleteStickerFromSet = "/bot{0}/deleteStickerFromSet";

        /// <summary>
        /// Use this method to get a sticker set
        /// </summary>
        /// <param name="name">Name of the sticker set</param>
        /// <returns>On success, a <see cref="StickerSetInfoResult"/> is returned.</returns>
        public StickerSetInfoResult GetStickerSet(string name)
        {
            RestRequest request = NewRestRequest(mGetStickerSet);

            request.AddParameter("name", name);

            return ExecuteRequest<StickerSetInfoResult>(request) as StickerSetInfoResult; 
        }

        /// <summary>
        /// Use this method to delete a sticker from a set created by the bot. 
        /// </summary>
        /// <param name="sticker">File identifier of the sticker </param>
        /// <returns>True on success</returns>
        public BooleanResult DeleteStickerFromSet(string sticker)
        {
            RestRequest request = NewRestRequest(mDeleteStickerFromSet);

            request.AddParameter("sticker", sticker);

            return  ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }
    }
}

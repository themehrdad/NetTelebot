using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class StickerInfoObject
    {
        /// <summary>
        /// This object represents a sticker for test. See <see href="https://core.telegram.org/bots/api#sticker">API</see>
        /// </summary>
        /// <param name="fileId">Unique identifier for this file. Json field [file_id].</param>
        /// <param name="width">Sticker width. Json field [width].</param>
        /// <param name="height">Sticker height. Json field [height].</param>
        /// <param name="photoSizeInfo">Optional. Sticker thumbnail in .webp or .jpg format. 
        /// To simulate <see cref="PhotoSizeInfo"/> use <see cref="PhotoSizeInfoObject"/>. Json field [thumb].</param>
        /// <param name="emoji">Optional. Emoji associated with the sticker.</param>
        /// <param name="fileSize">Optional. File size.</param>
        /// <returns><see cref="StickerInfo"/></returns>
        internal static JObject GetObject(string fileId, int width, int height, JObject photoSizeInfo, string emoji, int fileSize)
        {
            dynamic stickerInfo = new JObject();

            stickerInfo.file_id = fileId;
            stickerInfo.width = width;
            stickerInfo.height = height;
            stickerInfo.thumb = photoSizeInfo;
            stickerInfo.emoji = emoji;
            stickerInfo.file_size = fileSize;

            return stickerInfo;
        }

        
        
        
        
        
        
    }
}

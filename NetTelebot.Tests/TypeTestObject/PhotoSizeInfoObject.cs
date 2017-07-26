using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class PhotoSizeInfoObject
    {

        /// <summary>
        /// This object represents one size of a photo or a file / sticker thumbnail. See <see href="https://core.telegram.org/bots/api#photosize"/>
        /// </summary>
        /// <param name="fileId">Unique identifier for this file</param>
        /// <param name="width">Photo width</param>
        /// <param name="height">Photo height</param>
        /// <param name="fileSize">Optional. File size</param>
        /// <returns><see cref="PhotoSizeInfo"/></returns>
        internal static JObject GetObject(string fileId, int width, int height, int fileSize)
        {
            dynamic photoSizeInfo = new JObject();
            
            photoSizeInfo.file_id = fileId;
            photoSizeInfo.width = width;
            photoSizeInfo.height = height;
            photoSizeInfo.file_size = fileSize;

            return photoSizeInfo;
        }
    }
}

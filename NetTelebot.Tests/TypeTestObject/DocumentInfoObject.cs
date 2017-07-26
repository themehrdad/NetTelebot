using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class DocumentInfoObject
    {
        /// <summary>
        /// This object represents a general file (as opposed to photos, voice messages and audio files).
        /// See <see href="https://core.telegram.org/bots/api#document">API</see>
        /// </summary>
        /// <param name="fileId">Unique file identifier</param>
        /// <param name="photoSizeInfo">Optional. Document thumbnail as defined by sender</param>
        /// <param name="fileName">Optional. Original filename as defined by sender</param>
        /// <param name="mimeTypes">Optional. MIME type of the file as defined by sender</param>
        /// <param name="fileSize">Optional. File size</param>
        /// <returns><see cref="MessageInfo.Document"/></returns>
        internal static JObject GetObject(string fileId, JObject photoSizeInfo, 
            string fileName, string mimeTypes, int fileSize)
        {
            dynamic documentInfo = new JObject();

            documentInfo.file_id = fileId;
            documentInfo.thumb = photoSizeInfo;
            documentInfo.file_name = fileName;
            documentInfo.mime_type = mimeTypes;
            documentInfo.file_size = fileSize;

            return documentInfo;
        }

    }
}
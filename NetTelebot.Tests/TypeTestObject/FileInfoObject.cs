using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class FileInfoObject
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <param name="fileId">Unique identifier for this file</param>
        /// <param name="fileSize">Optional. File size, if known </param>
        /// <param name="filePath">Optional. File path. Use https://api.telegram.org/file/bottoken/file_path to get the file.</param>
        /// <returns></returns>
        internal static JObject GetObject(string fileId, int fileSize, string filePath)
        {
            dynamic fileInfo = new JObject();

            fileInfo.file_id = fileId;
            fileInfo.file_size = fileSize;
            fileInfo.file_path = filePath;
            
            return fileInfo;
        }
    }
}

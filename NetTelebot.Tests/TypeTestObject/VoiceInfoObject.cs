using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class VoiceInfoObject
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <param name="fileId">Unique identifier for this file.</param>
        /// <param name="duration">Duration of the audio in seconds as defined by sender</param>
        /// <param name="mimeTypes">Optional. MIME type of the file as defined by sender</param>
        /// <param name="fileSize">Optional. File size</param>
        /// <returns></returns>
        internal static JObject GetObject(string fileId, int duration, string mimeTypes, int fileSize)
        {
            dynamic audioInfo = new JObject();

            audioInfo.file_id = fileId;
            audioInfo.duration = duration;
            audioInfo.mime_type = mimeTypes;
            audioInfo.file_size = fileSize;

            return audioInfo;
        }
    }
}

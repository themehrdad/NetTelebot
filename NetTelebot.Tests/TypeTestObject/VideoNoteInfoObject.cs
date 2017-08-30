using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class VideoNoteInfoObject
    {
        /// <summary>
        /// This object represents a video message (available in Telegram apps as of v.4.0).
        /// See <see href="https://core.telegram.org/bots/api#videonote">API</see>
        /// </summary>
        /// <param name="fileId">Unique identifier for this file</param>
        /// <param name="length">Video width and height as defined by sender</param>
        /// <param name="duration">Duration of the video in seconds as defined by sender</param>
        /// <param name="photoSizeInfo">Optional. Video thumbnail</param>
        /// <param name="fileSize">Optional. File size</param>
        /// <returns></returns>
        internal static JObject GetObject(string fileId, int length, int duration, 
            JObject photoSizeInfo , int fileSize)
        {
            dynamic videoNoteInfo = new JObject();

            videoNoteInfo.file_id = fileId;
            videoNoteInfo.length = length;
            videoNoteInfo.duration = duration;
            videoNoteInfo.thumb = photoSizeInfo;
            videoNoteInfo.file_size = fileSize;

            return videoNoteInfo;
        }
    }
}

using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class VideoInfoObject
    {
        /// <summary>
        /// This object represents a video file. 
        /// See <see href="https://core.telegram.org/bots/api#video">API</see>
        /// </summary>
        /// <param name="fileId">Unique identifier for this file</param>
        /// <param name="width">Video width as defined by sender</param>
        /// <param name="height">Video height as defined by sender</param>
        /// <param name="duration">Duration of the video in seconds as defined by sender</param>
        /// <param name="photoSizeInfo">Optional. Video thumbnail</param>
        /// <param name="mimeType">Optional. Mime type of a file as defined by sender</param>
        /// <param name="fileSize">Optional. File size</param>
        /// <returns><see cref="VideoInfo"/></returns>
        internal static JObject GetObject(string fileId, int width, int height,
            int duration, JObject photoSizeInfo, string mimeType, int fileSize)
        {
            dynamic videoInfo = new JObject();

            videoInfo.file_id = fileId;
            videoInfo.width = width;
            videoInfo.height = height;
            videoInfo.duration = duration;
            videoInfo.thumb = photoSizeInfo;
            videoInfo.mime_type = mimeType;
            videoInfo.file_size = fileSize;

            return videoInfo;
        }
    }
}

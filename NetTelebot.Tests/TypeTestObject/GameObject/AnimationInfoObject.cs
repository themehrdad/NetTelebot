using NetTelebot.Type.Games;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.GameObject
{
    internal static class AnimationInfoObject
    {
        /// <summary>
        /// You can provide an animation for your game so that it looks stylish in chats (check out Lumberjack for an example). 
        /// This object represents an animation file to be displayed in the message containing a game.
        /// See <see href="https://core.telegram.org/bots/api#animation">API</see>
        /// </summary>
        /// <param name="fileId">Unique file identifier</param>
        /// <param name="photoSizeInfo">Optional. Animation thumbnail as defined by sender</param>
        /// <param name="fileName">Optional. Original animation filename as defined by sender</param>
        /// <param name="mimeTypes">Optional. MIME type of the file as defined by sender</param>
        /// <param name="fileSize">Optional. File size</param>
        /// <returns><see cref="AnimationInfo"/></returns>
        internal static JObject GetObject(string fileId, JObject photoSizeInfo, 
            string fileName, string mimeTypes, int fileSize)
        {
            dynamic animationInfo = new JObject();

            animationInfo.file_id = fileId;
            animationInfo.thumb = photoSizeInfo;
            animationInfo.file_name = fileName;
            animationInfo.mime_type = mimeTypes;
            animationInfo.file_size = fileSize;

            return animationInfo;
        }
    }
}

using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class AudioInfoObject
    {
        /// <summary>
        /// This object represents an audio file to be treated as music by the Telegram clients. 
        /// See <see href="https://core.telegram.org/bots/api#audio">API</see>
        /// </summary>
        /// <param name="fileId">Unique identifier for this file</param>
        /// <param name="duration">Duration of the audio in seconds as defined by sender</param>
        /// <param name="performer">Optional. Performer of the audio as defined by sender or by audio tags</param>
        /// <param name="title">Optional. Title of the audio as defined by sender or by audio tags</param>
        /// <param name="mimeTypes">Optional. MIME type of the file as defined by sender</param>
        /// <param name="fileSize">Optional. File size</param>
        /// <returns><see cref="AudioInfo"/></returns>
        internal static JObject GetObject(string fileId, int duration, string performer,
            string title, string mimeTypes, int fileSize)
        {
            dynamic audioInfo = new JObject();

            audioInfo.file_id = fileId;
            audioInfo.duration = duration;
            audioInfo.performer = performer;
            audioInfo.title = title;
            audioInfo.mime_type = mimeTypes;
            audioInfo.file_size = fileSize;
            
            return audioInfo;
        }
    }
}
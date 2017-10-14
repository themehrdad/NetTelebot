using NetTelebot.Interface;

namespace NetTelebot.Type
{
    /// <summary>
    /// There are two ways to send files (photos, stickers, audio, media, etc.):
    /// 1. If the file is already stored somewhere on the Telegram servers, you don't need to reupload it: 
    /// each file object has a file_id field, simply pass this file_id as a parameter instead of uploading. There are no limits for files sent this way.
    /// 2. Provide Telegram with an HTTP URL for the file to be sent.Telegram will download and send the file. 5 MB max size for photos and 20 MB max for other types of content.
    /// </summary>
    public class ExistingFile : IFile
    {
        /// <summary>
        /// Sending by file_id
        /// 1. It is not possible to change the file type when resending by file_id.I.e.a video can't be sent as a photo, a photo can't be sent as a document, etc. 
        /// 2. It is not possible to resend thumbnails.
        /// 3. Resending a photo by file_id will send all of its sizes.
        /// 4. file_id is unique for each individual bot and can't be transferred from one bot to another.
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Sending by URL
        /// 1. When sending by URL the target file must have the correct MIME type(e.g., audio/mpeg for sendAudio, etc.).
        /// 2. In sendDocument, sending by URL will currently only work for gif, pdf and zip files.
        /// 3. To use sendVoice, the file must have the type audio/ogg and be no more than 1MB in size. 1–20MB voice notes will be sent as files.
        /// 4. Other configurations may work but we can't guarantee that they will.
        /// </summary>
        public string Url { get; set; }
    }
}

using NetTelebot.Interface;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents the identifier of the file on Telegram servers
    /// </summary>
    public class ExistingFile : IFile
    {
        /// <summary>
        /// File identifier to get info about
        /// </summary>
        public string FileId { get; set; }
    }
}

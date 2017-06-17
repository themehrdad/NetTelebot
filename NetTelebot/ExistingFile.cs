namespace NetTelebot
{
    /// <summary>
    /// This object represents the identifier of the file on Telegram servers
    /// </summary>
    public class ExistingFile : IFile
    {
        public string FileId { get; set; }
    }
}

namespace NetTelebot
{
    /// <summary>
    /// This object represents the contents of a file to be uploaded. 
    /// </summary>
    public class NewFile : IFile
    {
        public byte[] FileContent { get; set; }
        public string FileName { get; set; }
    }
}

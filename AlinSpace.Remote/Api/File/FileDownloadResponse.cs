namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the file download response.
    /// </summary>
    public class FileDownloadResponse : Response
    {
        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        public byte[]? FileData { get; set; }
    }
} 

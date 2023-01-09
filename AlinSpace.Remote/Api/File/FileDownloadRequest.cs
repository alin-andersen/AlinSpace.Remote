namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the file download request.
    /// </summary>
    public class FileDownloadRequest : Request
    {
        /// <summary>
        /// Gets or sets the file offset.
        /// </summary>
        public int FileOffset { get; set; }

        /// <summary>
        /// Gets or sets the file chunk size.
        /// </summary>
        public int FileChunkSize { get; set; }
    }
}

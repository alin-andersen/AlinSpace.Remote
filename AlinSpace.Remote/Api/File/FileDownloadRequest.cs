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
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the file chunk size.
        /// </summary>
        public int ChunkSize { get; set; }
    }
}

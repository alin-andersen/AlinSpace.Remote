namespace AlinSpace.Remote
{
    public static class FileLoader
    {
        public static async Task UploadAsync(
            string pathToFile, 
            Func<FileSlice, CancellationToken, Task> upload, 
            int sliceSize = Chunk.SizeOf2097152, 
            CancellationToken cancellationToken = default)
        {
            using var filestream = new FileStream(
                path: pathToFile,
                mode: FileMode.Open,
                access: FileAccess.Read,
                share: FileShare.Read,
                bufferSize: sliceSize);

            var fileSlice = new FileSlice();

            // Get total file size.
            filestream.Seek(0, SeekOrigin.End);
            fileSlice.TotalFileSize = (int)filestream.Position;
            filestream.Seek(0, SeekOrigin.Begin);

            // Create buffer.
            var buffer = new byte[sliceSize];

            while (true)
            {
                var bytesRead = await filestream.ReadAsync(buffer, fileSlice.Offset, sliceSize, cancellationToken);

                if (bytesRead == 0)
                    break;

                fileSlice.Length = bytesRead;

                // Partial slice.
                if (bytesRead < fileSlice.Length)
                {
                    var newBuffer = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, newBuffer, 0, newBuffer.Length);
                    
                    fileSlice.Data = buffer;
                    await upload(fileSlice, cancellationToken);

                    return;
                }

                // Full slice.
                fileSlice.Data = buffer;
                await upload(fileSlice, cancellationToken);
            }
        }

        //public static Task DownloadAsync(string pathToFile, Func<FileSlice, Task> download, int sliceSize = Chunk.SizeOf2097152)
        //{

        //}
    }
}

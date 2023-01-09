namespace AlinSpace.Remote.Server
{
    public static class FileResponseExtensions
    {
        //public static async Task ReadChunkAsync(
        //    this FileDownloadResponse response, 
        //    FileRequest request, 
        //    string pathToFile)
        //{
        //    using var fileStream = new FileStream(
        //        path: pathToFile,
        //        mode: FileMode.Open,
        //        access: FileAccess.Read,
        //        share: FileShare.Read,
        //        bufferSize: request.FileChunkSize);

        //    var buffer = new byte[request.FileOffset];

        //    var bytesRead = await fileStream.ReadAsync(buffer, request.FileOffset, request.FileChunkSize);

        //    if (bytesRead < 0)
        //    {
        //        throw new Exception();
        //    }

        //    // Set file size.
        //    fileStream.Seek(0, SeekOrigin.End);
        //    response.FileSize = (int)fileStream.Position;

        //    // Set file data.
        //    if (bytesRead < request.FileOffset)
        //    {
        //        var newBuffer = new byte[bytesRead];
        //        Buffer.BlockCopy(buffer, 0, newBuffer, 0, newBuffer.Length);
                
        //        response.FileData = newBuffer;
        //    }
        //    else
        //    {
        //        response.FileData = buffer;
        //    }
        //}
    }
}

namespace AlinSpace.Remote
{
    public static class FileSlicePointerExtensions
    {
        //public static async Task ReadSliceAsync(
        //    this FileSlicePointer pointer, 
        //    FileSlice slice,
        //    string pathToFile)
        //{
        //    using var fileStream = new FileStream(
        //        path: pathToFile,
        //        mode: FileMode.Open,
        //        access: FileAccess.Read,
        //        share: FileShare.Read,
        //        bufferSize: pointer.Length);

        //    var buffer = new byte[pointer.Offset];

        //    var bytesRead = await fileStream.ReadAsync(buffer, pointer.Offset, pointer.Length);

        //    if (bytesRead < 0)
        //    {
        //        throw new Exception();
        //    }

        //    // Set file size.
        //    fileStream.Seek(0, SeekOrigin.End);
        //    slice.FileSize = (int)fileStream.Position;

        //    // Set file data.
        //    if (bytesRead < pointer.Length)
        //    {
        //        var newBuffer = new byte[bytesRead];
        //        Buffer.BlockCopy(buffer, 0, newBuffer, 0, newBuffer.Length);
              
        //        slice.Data = newBuffer;
        //    }
        //    else
        //    {
        //        slice.Data = buffer;
        //    }
        //}
    }
}

namespace AlinSpace.Remote
{
    public static class FileSliceExtensions
    {
        public static async Task<FileSlicePointer> WriteSliceAsync(
            this FileSlice slice,
            string pathToFile,
            CancellationToken cancellationToken = default)
        {
            using var fileStream = new FileStream(
                path: pathToFile,
                mode: FileMode.OpenOrCreate,
                access: FileAccess.Write,
                share: FileShare.Write,
                bufferSize: 0);

            if (slice.Offset + slice.Length >= slice.TotalFileSize)
                throw new Exception("Slice is going outside of the file.");

            await fileStream.WriteAsync(slice.Data, slice.Offset, slice.Length, cancellationToken);

            return slice;
        }
    }
}

namespace AlinSpace.Remote
{
    public class FileSlice : FileSlicePointer
    {
        public int TotalFileSize { get; set; }

        public byte[] Data { get; set; }
    }
}

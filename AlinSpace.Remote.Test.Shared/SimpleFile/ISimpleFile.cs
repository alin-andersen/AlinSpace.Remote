using Refit;

namespace AlinSpace.Remote.Test.Shared
{
    public interface ISimpleFile
    {
        [Post("/api/file/simple")]
        Task<SimpleFileUploadResponse> UploadAsync(SimpleFileUploadRequest request, CancellationToken cancellationToken = default);
    }
}
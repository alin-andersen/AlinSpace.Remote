using AlinSpace.Remote.Server;
using AlinSpace.Remote.Test.Shared;

namespace AlinSpace.Remote.TestServer.AspNetCore
{
    public class SimpleFile : ISimpleFile
    {
        public async Task<SimpleFileUploadResponse> UploadAsync(SimpleFileUploadRequest request, CancellationToken cancellationToken = default)
        {
            return await RequestResponseHandler.New<SimpleFileUploadRequest, SimpleFileUploadResponse>(request)
                .HandleAsync(async (request, response, cancellationToken) =>
                {
                    if (request.File != null)
                    {
                        response.File = await request.File.WriteSliceAsync("test.txt");
                    }
                });
        }
    }
}

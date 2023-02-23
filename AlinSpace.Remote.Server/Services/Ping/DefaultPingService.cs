﻿namespace AlinSpace.Remote.Server
{
    public class DefaultPingService : IPing
    {
        public Task<PingResponse> PingAsync(PingRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
                .New<PingRequest, PingResponse>(request, cancellationToken: cancellationToken)
                .HandleAsync((request, response, cancellationToken) =>
                {
#if DEBUG
                    Console.WriteLine($"[{typeof(DefaultPingService)}] PingAsync: {request.Content}");
#endif
                    response.Content = request.Content;
                    return Task.CompletedTask;
                });
        }
    }
}

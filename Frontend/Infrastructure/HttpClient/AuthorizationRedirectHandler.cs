using System.Net;
using PCMasterFrontend.Infrastructure.Exceptions;

namespace PCMasterFrontend.Infrastructure.HttpClient;

public class AuthorizationRedirectHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[AuthorizationRedirectHandler] Sending request: {request.Method} {request.RequestUri}");
        Console.WriteLine($"[AuthorizationRedirectHandler] Auth header: {request.Headers.Authorization}");
        var response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine($"[AuthorizationRedirectHandler] Response: {(int)response.StatusCode} {response.StatusCode}");

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            var endpoint = request.RequestUri?.PathAndQuery;
            throw new ForbiddenAccessException(endpoint);
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            Console.WriteLine("[AuthorizationRedirectHandler] Unauthorized detected!");
            throw new UnauthorizedApiAccessException();
        }

        return response;
    }
}

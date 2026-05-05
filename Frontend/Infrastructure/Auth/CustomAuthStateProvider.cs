using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using PCMasterFrontend.Infrastructure.HttpClient;

namespace PCMasterFrontend.Infrastructure.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly TokenStorage _tokenStorage;
    private readonly IApiClient _apiClient;

    public CustomAuthStateProvider(TokenStorage tokenStorage, IApiClient apiClient)
    {
        _tokenStorage = tokenStorage;
        _apiClient = apiClient;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _tokenStorage.GetTokenAsync();
        var username = await _tokenStorage.GetUsernameAsync();

        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(username))
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            _apiClient.ClearAuthToken();
            return new AuthenticationState(anonymous);
        }

        _apiClient.SetAuthToken(token);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim("token", token)
        };
        var identity = new ClaimsIdentity(claims, "jwt");
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    public async Task LoginAsync(string token, string username)
    {
        await _tokenStorage.SetTokenAsync(token);
        await _tokenStorage.SetUsernameAsync(username);
        _apiClient.SetAuthToken(token);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await _tokenStorage.RemoveTokenAsync();
        await _tokenStorage.RemoveUsernameAsync();
        _apiClient.ClearAuthToken();
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}

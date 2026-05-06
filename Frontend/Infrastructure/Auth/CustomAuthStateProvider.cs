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
        var roles = await _tokenStorage.GetRolesAsync();

        Console.WriteLine($"[CustomAuthStateProvider] GetAuthenticationStateAsync:");
        Console.WriteLine($"  Token present: {!string.IsNullOrEmpty(token)}");
        Console.WriteLine($"  Username: {username}");
        Console.WriteLine($"  Roles: {string.Join(", ", roles)}");

        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(username))
        {
            Console.WriteLine("[CustomAuthStateProvider] No token/username, clearing auth");
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            _apiClient.ClearAuthToken();
            return new AuthenticationState(anonymous);
        }

        _apiClient.SetAuthToken(token);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim("token", token)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var identity = new ClaimsIdentity(claims, "jwt");
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    public async Task LoginAsync(string token, string username, List<string> roles)
    {
        Console.WriteLine($"[CustomAuthStateProvider] LoginAsync:");
        Console.WriteLine($"  Token: {(string.IsNullOrEmpty(token) ? "EMPTY" : token.Substring(0, Math.Min(20, token.Length)) + "...")}");
        Console.WriteLine($"  Username: {username}");
        Console.WriteLine($"  Roles: {string.Join(", ", roles)}");
        await _tokenStorage.SetTokenAsync(token);
        await _tokenStorage.SetUsernameAsync(username);
        await _tokenStorage.SetRolesAsync(roles);
        _apiClient.SetAuthToken(token);
        Console.WriteLine("[CustomAuthStateProvider] NotifyAuthenticationStateChanged");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await _tokenStorage.RemoveTokenAsync();
        await _tokenStorage.RemoveUsernameAsync();
        await _tokenStorage.RemoveRolesAsync();
        _apiClient.ClearAuthToken();
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}

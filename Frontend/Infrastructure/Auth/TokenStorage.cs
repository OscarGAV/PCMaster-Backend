using Microsoft.JSInterop;

namespace PCMasterFrontend.Infrastructure.Auth;

public class TokenStorage
{
    private readonly IJSRuntime _jsRuntime;
    private const string TokenKey = "pcmaster_auth_token";
    private const string UsernameKey = "pcmaster_username";
    private const string RolesKey = "pcmaster_roles";

    public TokenStorage(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", TokenKey);
    }

    public async Task SetTokenAsync(string token)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
    }

    public async Task RemoveTokenAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
    }

    public async Task<string?> GetUsernameAsync()
    {
        return await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", UsernameKey);
    }

    public async Task SetUsernameAsync(string username)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UsernameKey, username);
    }

    public async Task RemoveUsernameAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", UsernameKey);
    }

    public async Task<List<string>> GetRolesAsync()
    {
        var json = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", RolesKey);
        if (string.IsNullOrEmpty(json))
            return new List<string>();
        return System.Text.Json.JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }

    public async Task SetRolesAsync(List<string> roles)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(roles);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", RolesKey, json);
    }

    public async Task RemoveRolesAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", RolesKey);
    }
}

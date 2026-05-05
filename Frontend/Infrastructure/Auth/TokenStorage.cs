using Microsoft.JSInterop;

namespace PCMasterFrontend.Infrastructure.Auth;

public class TokenStorage
{
    private readonly IJSRuntime _jsRuntime;
    private const string TokenKey = "pcmaster_auth_token";
    private const string UsernameKey = "pcmaster_username";

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
}

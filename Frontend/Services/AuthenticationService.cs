using PCMasterFrontend.Infrastructure.Auth;
using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.Authentication;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IApiClient _apiClient;
    private readonly CustomAuthStateProvider _authStateProvider;

    public AuthenticationService(IApiClient apiClient, CustomAuthStateProvider authStateProvider)
    {
        _apiClient = apiClient;
        _authStateProvider = authStateProvider;
    }

    public async Task<AuthenticatedUserDto?> SignInAsync(SignInRequest request)
    {
        var result = await _apiClient.PostAsync<AuthenticatedUserDto>(Endpoints.SignIn, request);
        if (result is not null)
        {
            await _authStateProvider.LoginAsync(result.Token, result.Username, result.Roles);
        }
        return result;
    }

    public async Task<SignUpResponse?> SignUpAsync(SignUpRequest request)
    {
        return await _apiClient.PostAsync<SignUpResponse>(Endpoints.SignUp, request);
    }

    public async Task LogoutAsync()
    {
        await _authStateProvider.LogoutAsync();
    }
}

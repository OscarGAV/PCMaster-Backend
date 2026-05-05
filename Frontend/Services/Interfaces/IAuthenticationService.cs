using PCMasterFrontend.Models.Authentication;

namespace PCMasterFrontend.Services.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticatedUserDto?> SignInAsync(SignInRequest request);
    Task<SignUpResponse?> SignUpAsync(SignUpRequest request);
    Task LogoutAsync();
}

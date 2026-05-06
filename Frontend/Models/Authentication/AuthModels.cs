namespace PCMasterFrontend.Models.Authentication;

public class SignInRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class SignUpRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = PCMasterFrontend.Infrastructure.Constants.ERole.ROLE_CLIENTE;
}

public class SignUpResponse
{
    public string Message { get; set; } = string.Empty;
}

public class AuthenticatedUserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
}

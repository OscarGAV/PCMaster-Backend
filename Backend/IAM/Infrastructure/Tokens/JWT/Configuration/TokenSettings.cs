namespace Backend.IAM.Infrastructure.Tokens.JWT.Configuration;

/// <summary>
/// Token settings. 
/// </summary>
public class TokenSettings
{
    public required string Secret { get; init; }
}
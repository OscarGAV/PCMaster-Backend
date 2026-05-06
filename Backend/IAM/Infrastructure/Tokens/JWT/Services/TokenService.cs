using System.Security.Claims;
using System.Text;
using Backend.IAM.Application.Internal.OutboundServices;
using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Backend.IAM.Infrastructure.Tokens.JWT.Services;

public class TokenService(IOptions<TokenSettings> tokenSettings) : ITokenService
{
    private readonly TokenSettings _tokenSettings = tokenSettings.Value;
    
    public string GenerateToken(User user)
    {
        var secret = _tokenSettings.Secret;
        var key = Encoding.ASCII.GetBytes(secret);
        var claims = new List<Claim>
        {
            new(JwtClaimTypes.UserId, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username)
        };
        claims.AddRange(user.UserRoles.Select(role => new Claim(ClaimTypes.Role, role.Role)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token;
    }

    public async Task<int?> ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token)) return null;
        var tokenHandler = new JsonWebTokenHandler();
        var secret = _tokenSettings.Secret;
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateLifetime = true
        };
        try
        {
            var tokenValidationResult = await tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);
            if (tokenValidationResult.SecurityToken is not JsonWebToken jwtToken) return null;
            var userId = int.Parse(jwtToken.Claims.First(c => c.Type == JwtClaimTypes.UserId).Value);
            return userId;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
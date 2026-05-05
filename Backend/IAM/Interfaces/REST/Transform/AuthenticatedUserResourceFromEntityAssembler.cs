using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Interfaces.REST.Resources;

namespace Backend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        var roles = user.UserRoles.Select(r => r.Role).ToList();
        return new AuthenticatedUserResource(user.Id, user.Username, token, roles);
    }
    
}
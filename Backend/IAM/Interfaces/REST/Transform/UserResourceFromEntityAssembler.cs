using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Interfaces.REST.Resources;

namespace Backend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        var roles = user.UserRoles.Select(r => r.Role).ToList();
        return new UserResource(user.Id, user.Username, roles);
    }
}
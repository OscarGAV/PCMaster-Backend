using Backend.IAM.Domain.Model.Commands;
using Backend.IAM.Interfaces.REST.Resources;

namespace Backend.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password, resource.Role);
    }
}
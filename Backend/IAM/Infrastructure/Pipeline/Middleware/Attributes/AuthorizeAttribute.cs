using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Domain.Model.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public ERole[]? AllowedRoles { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            return;

        var user = (User?)context.HttpContext.Items["User"];
        if (user is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (AllowedRoles is not { Length: > 0 }) return;

        if (!AllowedRoles.Any(user.HasRole))
            context.Result = new ForbidResult();
    }
}
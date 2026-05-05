using Backend.IAM.Application.Internal.OutboundServices;
using Backend.IAM.Domain.Model.Queries;
using Backend.IAM.Domain.Services;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace Backend.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        var endpoint = context.Request.HttpContext.GetEndpoint();
        var allowAnonymous = endpoint?.Metadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute)) ?? false;
        Console.WriteLine($"AllowAnonymous: {allowAnonymous}");
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            await next(context);
            return;
        }
        Console.WriteLine("Entering authorization");

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Token is missing or invalid");
            return;
        }
        var userId = await tokenService.ValidateToken(token);
        
        if (userId is null) throw new Exception("Invalid token");
        
        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);

        var user = await userQueryService.Handle(getUserByIdQuery);
        Console.WriteLine("Successfully authorized. Updating context...");
        context.Items["User"] = user;
        Console.WriteLine("Continuing to next middleware in pipeline");
        await next(context);
    }
}
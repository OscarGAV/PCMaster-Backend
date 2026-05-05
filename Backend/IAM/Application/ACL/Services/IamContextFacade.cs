using Backend.IAM.Domain.Model.Commands;
using Backend.IAM.Domain.Model.Queries;
using Backend.IAM.Domain.Model.ValueObjects;
using Backend.IAM.Domain.Services;
using Backend.IAM.Interfaces.ACL;

namespace Backend.IAM.Application.ACL.Services;

public class IamContextFacade(
    IUserCommandService userCommandService,
    IUserQueryService userQueryService) : IIamContextFacade
{
    public async Task<int> CreateUser(string username, string password, ERole role)
    {
        var signUpCommand = new SignUpCommand(username, password, role);
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
}
using Backend.IAM.Application.Internal.OutboundServices;
using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Domain.Model.Commands;
using Backend.IAM.Domain.Model.ValueObjects;
using Backend.IAM.Domain.Repositories;
using Backend.IAM.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;

namespace Backend.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService
    ) : IUserCommandService
{
    public async Task Handle(SignUpCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Username))
            throw new ValidationException("Username cannot be empty");

        if (string.IsNullOrWhiteSpace(command.Password))
            throw new ValidationException("Password cannot be empty");

        if (command.Password.Length < 6)
            throw new ValidationException("Password must be at least 6 characters");

        if (userRepository.ExistsByUsername(command.Username))
            throw new DuplicateEntityException($"Username '{command.Username}' already exists");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        user.UserRoles.Add(new UserRole(command.Role));
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Username))
            throw new ValidationException("Username cannot be empty");

        if (string.IsNullOrWhiteSpace(command.Password))
            throw new ValidationException("Password cannot be empty");

        var user = await userRepository.FindByUsernameAsync(command.Username);
        if (user is null)
            throw new NotFoundException($"User '{command.Username}' not found");

        if (!hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new ValidationException("Invalid password");

        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}
using Backend.IAM.Domain.Model.ValueObjects;

namespace Backend.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, ERole Role);
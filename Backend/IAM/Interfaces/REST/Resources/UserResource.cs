namespace Backend.IAM.Interfaces.REST.Resources;

public record UserResource(int Id, string Username, List<string> Roles);
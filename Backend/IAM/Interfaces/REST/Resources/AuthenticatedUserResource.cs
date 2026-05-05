namespace Backend.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Username, string Token, List<string> Roles);
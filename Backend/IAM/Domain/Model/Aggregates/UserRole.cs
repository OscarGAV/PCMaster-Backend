using System.ComponentModel.DataAnnotations;

namespace Backend.IAM.Domain.Model.Aggregates;

public class UserRole
{
    public int Id { get; }

    public int UserId { get; private set; }

    [MaxLength(20)]
    public string Role { get; private set; } = string.Empty;

    public User User { get; private set; } = null!;

    private UserRole() { }

    public UserRole(Backend.IAM.Domain.Model.ValueObjects.ERole role)
        => Role = role.ToString();
}
using System.ComponentModel.DataAnnotations;
using Backend.IAM.Domain.Model.ValueObjects;

namespace Backend.IAM.Domain.Model.Aggregates;

public class UserRole(ERole role)
{
    public int Id { get; }

    public int UserId { get; private set; }

    [MaxLength(20)]
    public string Role { get; private set; } = role.ToString();

    public User User { get; private set; } = null!;
}

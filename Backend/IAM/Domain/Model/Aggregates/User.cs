using System.ComponentModel.DataAnnotations;
using Backend.IAM.Domain.Model.ValueObjects;

namespace Backend.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash)
{
    public int Id { get; }

    [MaxLength(30, ErrorMessage = "Username must be at most 30 characters")]
    public string Username { get; private set; } = username;
    
    [MaxLength(255, ErrorMessage = "Password hash must be at most 255 characters")]
    public string PasswordHash { get; private set; } = passwordHash;

    public ICollection<UserRole> UserRoles { get; } = new List<UserRole>();

    public bool HasRole(ERole role) => UserRoles.Any(r => r.Role == role.ToString());
}
using System.ComponentModel.DataAnnotations;

namespace Backend.IAM.Domain.Model.Aggregates;

/// <summary>
/// User aggregate root 
/// </summary>
/// <param name="username">
/// The username of the user
/// </param>
/// <param name="passwordHash">
/// The password hash of the user
/// </param>
public class User(string username, string passwordHash)
{
    public int Id { get; }

    [MaxLength(30, ErrorMessage = "Username must be at most 30 characters")]
    public string Username { get; private set; } = username;
    
    [MaxLength(255, ErrorMessage = "Password hash must be at most 255 characters")]
    public string PasswordHash { get; private set; } = passwordHash;
}
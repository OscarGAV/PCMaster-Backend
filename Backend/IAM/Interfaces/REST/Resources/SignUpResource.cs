using System.ComponentModel.DataAnnotations;

namespace Backend.IAM.Interfaces.REST.Resources;

public record SignUpResource(
    [Required(ErrorMessage = "Username is required")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
    [MaxLength(30, ErrorMessage = "Username must be at most 30 characters")]
    string Username,

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    string Password
);
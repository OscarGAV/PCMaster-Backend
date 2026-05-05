using System.ComponentModel.DataAnnotations;

namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateTechnicalSupportReviewResource(
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    int Rating,

    [Required(ErrorMessage = "Comment is required")]
    [MaxLength(150, ErrorMessage = "Comment must be at most 150 characters")]
    string Comment,

    [Required(ErrorMessage = "UserName is required")]
    [MaxLength(30, ErrorMessage = "UserName must be at most 30 characters")]
    string UserName,

    [Range(1, int.MaxValue, ErrorMessage = "TechnicalSupportId must be a positive number")]
    int TechnicalSupportId
);
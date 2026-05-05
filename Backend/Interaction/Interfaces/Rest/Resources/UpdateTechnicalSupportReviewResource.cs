using System.ComponentModel.DataAnnotations;

namespace Backend.Interaction.Interfaces.Rest.Resources;

public record UpdateTechnicalSupportReviewResource()
{
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }

    [Required(ErrorMessage = "Comment is required")]
    [MaxLength(150, ErrorMessage = "Comment must be at most 150 characters")]
    public string Comment { get; set; }
}
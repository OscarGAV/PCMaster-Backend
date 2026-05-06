using System.ComponentModel.DataAnnotations;

namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record CreateTechnicianResource(
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name must be at most 100 characters")]
    string Name,

    bool Status,

    [Required(ErrorMessage = "Image URL is required")]
    [MaxLength(200, ErrorMessage = "Image URL must be at most 200 characters")]
    string Img
);
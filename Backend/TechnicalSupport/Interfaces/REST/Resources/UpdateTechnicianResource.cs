using System.ComponentModel.DataAnnotations;

namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record UpdateTechnicianResource()
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name must be at most 100 characters")]
    public string Name { get; set; }

    public bool Status { get; set; }

    [Range(0.0, 5.0, ErrorMessage = "Stars must be between 0 and 5")]
    public double Stars { get; set; }

    [Required(ErrorMessage = "Image URL is required")]
    [MaxLength(200, ErrorMessage = "Image URL must be at most 200 characters")]
    public string Img { get; set; }
}
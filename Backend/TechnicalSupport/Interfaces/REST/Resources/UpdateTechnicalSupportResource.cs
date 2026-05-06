using System.ComponentModel.DataAnnotations;

namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record UpdateTechnicalSupportResource
{
    [Required(ErrorMessage = "TechnicianId is required")]
    public required string TechnicianId { get; set; }

    public bool SupportType { get; set; }

    [Required(ErrorMessage = "DateOfRequest is required")]
    public DateTime DateOfRequest { get; set; }

    [Required(ErrorMessage = "StartDate is required")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "EndDate is required")]
    public DateTime EndDate { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record CreateTechnicalSupportResource(
    [Required(ErrorMessage = "TechnicianId is required")]
    string TechnicianId,

    bool SupportType,

    [Required(ErrorMessage = "DateOfRequest is required")]
    DateTime DateOfRequest,

    [Required(ErrorMessage = "StartDate is required")]
    DateTime StartDate,

    [Required(ErrorMessage = "EndDate is required")]
    DateTime EndDate
);
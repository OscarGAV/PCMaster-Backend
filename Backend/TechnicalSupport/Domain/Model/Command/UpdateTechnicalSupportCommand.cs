namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to update Technical Support
/// </summary>
/// <param name="Id"></param>
/// <param name="TechnicianId"></param>
/// <param name="SupportType"></param>
/// <param name="DateOfRequest"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
public record UpdateTechnicalSupportCommand    (
    int Id,
    string TechnicianId,
    bool SupportType,
    DateTime DateOfRequest,
    DateTime StartDate,
    DateTime EndDate
);
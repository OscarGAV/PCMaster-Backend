namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to create technical support
/// </summary>
/// <param name="TechnicianId"></param>
/// <param name="SupportType"></param>
/// <param name="DateOfRequest"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
public record CreateTechnicalSupportCommand(string TechnicianId, bool SupportType, DateTime DateOfRequest, DateTime StartDate, DateTime EndDate);
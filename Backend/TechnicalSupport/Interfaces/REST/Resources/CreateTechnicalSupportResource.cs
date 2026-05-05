namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record CreateTechnicalSupportResource(string TechnicianId, bool SupportType, DateTime DateOfRequest, DateTime StartDate, DateTime EndDate);
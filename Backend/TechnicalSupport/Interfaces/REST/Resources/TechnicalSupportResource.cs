namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record TechnicalSupportResource(int Id, string TechnicianId, bool SupportType, DateTime DateOfRequest, DateTime StartDate, DateTime EndDate);
namespace Backend.TechnicalSupport.Domain.Model.Queries;

public record GetTechnicalSupportBySupportTypeAndTechnicianIdQuery(bool SupportType, string TechnicianId);
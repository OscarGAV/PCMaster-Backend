namespace Backend.TechnicalSupport.Domain.Model.Aggregates;

public record CreateTechnicianResult(Technician Technician, string Username, string Password);

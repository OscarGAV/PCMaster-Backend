namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to delete technician by unique ID
/// </summary>
/// <param name="Id"></param>
public record DeleteTechnicianCommand(int Id);
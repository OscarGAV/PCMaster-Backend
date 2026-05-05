namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to delete technician by unique Id
/// </summary>
/// <param name="Id"></param>
public record DeleteTechnicianCommand(int Id);
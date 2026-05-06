namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to delete technical support by unique ID
/// </summary>
/// <param name="Id"></param>
public record DeleteTechnicalSupportCommand(int Id);
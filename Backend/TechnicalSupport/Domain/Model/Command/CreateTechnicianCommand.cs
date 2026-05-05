namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to create technician
/// </summary>
/// <param name="Name"></param>
/// <param name="Status"></param>
/// <param name="Stars"></param>
/// <param name="Img"></param>
public record CreateTechnicianCommand(string Name, bool Status, double Stars, string Img);
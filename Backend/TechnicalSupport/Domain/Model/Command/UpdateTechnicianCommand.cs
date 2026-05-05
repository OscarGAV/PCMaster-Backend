namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to update Technician
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Status"></param>
/// <param name="Stars"></param>
public record UpdateTechnicianCommand(
    int Id,
    string Name,
    bool Status,
    double Stars,
    string Img
    );
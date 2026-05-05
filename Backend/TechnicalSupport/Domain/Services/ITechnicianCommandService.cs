using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicianCommandService
{
    /// <summary>
    /// Handles the CreateTechnicianCommand
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<Technician?> Handle(CreateTechnicianCommand command);
    
    /// <summary>
    /// Handles the update of an existing Technician request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<Technician> Handle(UpdateTechnicianCommand command);
    
    /// <summary>
    /// Handles the deletion of a Technician request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<bool> Handle(DeleteTechnicianCommand command);
}
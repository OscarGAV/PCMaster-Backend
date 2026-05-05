using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicalSupportCommandService
{
    /// <summary>
    /// Handles the CreateTechnicalSupportCommand
    /// </summary>
    /// <remarks>
    /// This method will handle the CreateTechnicalSupportCommand and return the TechnicalSupport
    /// It checks if the TechnicalSupport already exists in the database
    /// </remarks>
    /// <param name="command"> CreateTechnicalSupportCommand command </param>
    /// <returns> A Technical Support instance if successful, or null if the entry already exists. </returns>
    Task<TechnicalSupport?> Handle(CreateTechnicalSupportCommand command);
    
    /// <summary>
    /// Handles the update of an existing Technical Support request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> The updated instance. </returns>
    Task<TechnicalSupport> Handle(UpdateTechnicalSupportCommand command);
    
    /// <summary>
    /// Handles the deletion of a Technical Support request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> True if the deletion was successful, otherwise false. </returns>
    Task<bool> Handle(DeleteTechnicalSupportCommand command);
}
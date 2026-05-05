using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.CommandServices;
/// <summary>
/// Service to handle command operations for the TechnicalSupport entity. This service provides
/// methods to create and update instances of TechnicalSupport in the system.
/// </summary>
/// <param name="technicalSupportRepository"> Repository interface for accessing and modifying TechnicalSupport data. </param>
/// <param name="unitOfWork"></param>
public class TechnicalSupportCommandService(ITechnicalSupportRepository technicalSupportRepository, 
    IUnitOfWork unitOfWork) : ITechnicalSupportCommandService
{
    /// <summary>
    /// Creates a new TechnicalSupport entity based on the provided command.
    /// </summary>
    /// <param name="command"> The command containing data to create the TechnicalSupport entity </param>
    /// <returns> The newly created TechnicalSupport entity, or null if creation fails. </returns>
    /// <exception cref="Exception"> Thrown when a TechnicalSupport entity associated with the provided ESupportType and TechnicianId already exists. </exception>
    public async Task<TechnicalSupport?> Handle(CreateTechnicalSupportCommand command)
    {
        // Check if a TechnicalSupport entity with the given ESupportType and TechnicianId already exists
        var technicalSupport = 
            await technicalSupportRepository.FindBySupportTypeAndTechnicianIdAsync(command.SupportType, command.TechnicianId);
        if (technicalSupport != null) 
            throw new Exception($"TechnicalSupport entity with support type '{command.SupportType}' " +
                                $"and technician Id '{command.TechnicianId}' already exists.");
        // Create a new TechnicalSupport entity from the command data
        technicalSupport = new TechnicalSupport(command);

        try
        {
            // Add the new TechnicalSupport entity to the repository and complete the transaction
            await technicalSupportRepository.AddAsync(technicalSupport);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return technicalSupport;
    }
    
    /// <summary>
    /// Updates an existing TechnicalSupport entity based on the provided command.
    /// </summary>
    /// <param name="command"> The command containing updated data for the TechnicalSupport entity. </param>
    /// <returns> The updated TechnicalSupport entity. </returns>
    /// <exception cref="Exception"> Thrown when the TechnicalSupport entity with the provided identifier is not found. </exception>
    public async Task<TechnicalSupport> Handle(UpdateTechnicalSupportCommand command)
    {
        // Retrieve the existing TechnicalSupport entity by Id
        var technicalSupport = await technicalSupportRepository.FindByIdAsync(command.Id);

        if (technicalSupport == null)
        {
            throw new Exception($"TechnicalSupport with Id {command.Id} does not exist.");
        }

        // Update the properties of the TechnicalSupport entity based on the command data
        technicalSupport.UpdateProperties(command);

        try
        {
            // Save the updated TechnicalSupport entity to the repository and complete the transaction
            await technicalSupportRepository.UpdateAsync(technicalSupport);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return technicalSupport;
    }
    
    /// <summary>
    /// Deletes an existing TechnicalSupport entity based on the provided command.
    /// </summary>
    /// <param name="command"> The command containing the ID of the TechnicalSupport entity to be deleted. </param>
    /// <returns> True if deletion was successful, otherwise false. </returns>
    public async Task<bool> Handle(DeleteTechnicalSupportCommand command)
    {
        // Retrieve the TechnicalSupport entity to be deleted
        var technicalSupport = await technicalSupportRepository.FindByIdAsync(command.Id);
        if (technicalSupport == null)
        {
            return false; // Not found
        }

        await technicalSupportRepository.DeleteAsync(technicalSupport); // Perform the deletion
        return true; // Successfully deleted
    }
}
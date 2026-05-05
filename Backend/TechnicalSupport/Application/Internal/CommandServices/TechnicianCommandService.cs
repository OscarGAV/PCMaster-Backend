using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.CommandServices;

public class TechnicianCommandService(ITechnicianRepository technicianRepository, 
    IUnitOfWork unitOfWork) : ITechnicianCommandService
{
    public async Task<Technician?> Handle(CreateTechnicianCommand command)
    {
        // Check if a Technician entity with the given Name already exists
        var technician = 
            await technicianRepository.FindByNameAsync(command.Name);
        if (technician != null) 
            throw new Exception($"Technician entity with name '{command.Name}' already exists.");
        // Create a new Technician entity from the command data
        technician = new Technician(command);

        try
        {
            // Add the new Technician entity to the repository and complete the transaction
            await technicianRepository.AddAsync(technician);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return technician;
    }
    
    public async Task<Technician> Handle(UpdateTechnicianCommand command)
    {
        // Retrieve the existing Technician entity by Id
        var technician = await technicianRepository.FindByIdAsync(command.Id);

        if (technician == null)
        {
            throw new Exception($"Technician with Id {command.Id} does not exist.");
        }

        // Update the properties of the Technician entity based on the command data
        technician.UpdateProperties(command);

        try
        {
            // Save the updated Technician entity to the repository and complete the transaction
            await technicianRepository.UpdateAsync(technician);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return technician;
    }
    
    public async Task<bool> Handle(DeleteTechnicianCommand command)
    {
        // Retrieve the Technician entity to be deleted
        var technician = await technicianRepository.FindByIdAsync(command.Id);
        if (technician == null)
        {
            return false; // Not found
        }

        await technicianRepository.DeleteAsync(technician); // Perform the deletion
        return true; // Successfully deleted
    }
}
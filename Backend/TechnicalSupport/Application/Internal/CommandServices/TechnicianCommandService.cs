using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;
using Backend.TechnicalSupport.Domain.Model.Aggregates;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.CommandServices;

public class TechnicianCommandService(ITechnicianRepository technicianRepository, 
    IUnitOfWork unitOfWork) : ITechnicianCommandService
{
    public async Task<Technician?> Handle(CreateTechnicianCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
            throw new ValidationException("Technician name cannot be empty");

        if (command.Name.Length > 100)
            throw new ValidationException("Technician name must be at most 100 characters");

        if (string.IsNullOrWhiteSpace(command.Img))
            throw new ValidationException("Technician image URL cannot be empty");

        if (command.Img.Length > 200)
            throw new ValidationException("Technician image URL must be at most 200 characters");

        var technician = await technicianRepository.FindByNameAsync(command.Name);
        if (technician != null) 
            throw new DuplicateEntityException($"Technician entity with name '{command.Name}' already exists");

        technician = new Technician(command);

        try
        {
            await technicianRepository.AddAsync(technician);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the technician: {e.Message}");
        }

        return technician;
    }
    
    public async Task<Technician> Handle(UpdateTechnicianCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        if (string.IsNullOrWhiteSpace(command.Name))
            throw new ValidationException("Technician name cannot be empty");

        if (command.Name.Length > 100)
            throw new ValidationException("Technician name must be at most 100 characters");

        if (string.IsNullOrWhiteSpace(command.Img))
            throw new ValidationException("Technician image URL cannot be empty");

        if (command.Img.Length > 200)
            throw new ValidationException("Technician image URL must be at most 200 characters");

        var technician = await technicianRepository.FindByIdAsync(command.Id);

        if (technician == null)
            throw new NotFoundException($"Technician with Id {command.Id} does not exist");

        technician.UpdateProperties(command);

        try
        {
            await technicianRepository.UpdateAsync(technician);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the technician: {e.Message}");
        }

        return technician;
    }
    
    public async Task<bool> Handle(DeleteTechnicianCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        var technician = await technicianRepository.FindByIdAsync(command.Id);
        if (technician == null)
            return false;

        await technicianRepository.DeleteAsync(technician);
        return true;
    }
}
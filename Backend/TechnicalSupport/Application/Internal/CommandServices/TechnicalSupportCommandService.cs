using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.CommandServices;

public class TechnicalSupportCommandService(ITechnicalSupportRepository technicalSupportRepository, 
    IUnitOfWork unitOfWork) : ITechnicalSupportCommandService
{
    public async Task<TechnicalSupport?> Handle(CreateTechnicalSupportCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.TechnicianId))
            throw new ValidationException("TechnicianId cannot be empty");

        if (command.DateOfRequest == default)
            throw new ValidationException("DateOfRequest is required");

        if (command.StartDate == default)
            throw new ValidationException("StartDate is required");

        if (command.EndDate == default)
            throw new ValidationException("EndDate is required");

        if (command.StartDate >= command.EndDate)
            throw new ValidationException("StartDate must be before EndDate");

        var technicalSupport = 
            await technicalSupportRepository.FindBySupportTypeAndTechnicianIdAsync(command.SupportType, command.TechnicianId);
        if (technicalSupport != null) 
            throw new DuplicateEntityException($"TechnicalSupport entity with support type '{command.SupportType}' " +
                                 $"and technician Id '{command.TechnicianId}' already exists");

        technicalSupport = new TechnicalSupport(command);

        try
        {
            await technicalSupportRepository.AddAsync(technicalSupport);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the technical support: {e.Message}");
        }

        return technicalSupport;
    }
    
    public async Task<TechnicalSupport> Handle(UpdateTechnicalSupportCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        if (string.IsNullOrWhiteSpace(command.TechnicianId))
            throw new ValidationException("TechnicianId cannot be empty");

        if (command.DateOfRequest == default)
            throw new ValidationException("DateOfRequest is required");

        if (command.StartDate == default)
            throw new ValidationException("StartDate is required");

        if (command.EndDate == default)
            throw new ValidationException("EndDate is required");

        if (command.StartDate >= command.EndDate)
            throw new ValidationException("StartDate must be before EndDate");

        var technicalSupport = await technicalSupportRepository.FindByIdAsync(command.Id);

        if (technicalSupport == null)
            throw new NotFoundException($"TechnicalSupport with Id {command.Id} does not exist");

        technicalSupport.UpdateProperties(command);

        try
        {
            await technicalSupportRepository.UpdateAsync(technicalSupport);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the technical support: {e.Message}");
        }

        return technicalSupport;
    }
    
    public async Task<bool> Handle(DeleteTechnicalSupportCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        var technicalSupport = await technicalSupportRepository.FindByIdAsync(command.Id);
        if (technicalSupport == null)
            return false;

        await technicalSupportRepository.DeleteAsync(technicalSupport);
        return true;
    }
}
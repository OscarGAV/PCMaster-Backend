using Backend.Component.Domain.Model.Commands;
using Backend.Component.Domain.Repositories;
using Backend.Component.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;

namespace Backend.Component.Application.Internal.CommandServices;

public class ComponentCommandService(IComponentRepository componentRepository,
    IUnitOfWork unitOfWork) : IComponentCommandService
{
    public async Task<Domain.Model.Aggregates.Component?> Handle(CreateComponentCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
            throw new ValidationException("Component name cannot be empty");

        if (command.Price < 0)
            throw new ValidationException("Component price must be greater than or equal to 0");

        if (command.Stock < 0)
            throw new ValidationException("Component stock must be greater than or equal to 0");

        if (command.ProviderId <= 0)
            throw new ValidationException("Component provider ID must be a positive number");

        if (string.IsNullOrWhiteSpace(command.Country))
            throw new ValidationException("Component country cannot be empty");

        var existingComponent = await componentRepository.FindByIdAsync(command.Id);
        if (existingComponent != null)
            throw new DuplicateEntityException($"Component with Id {command.Id} already exists");

        var component = new Domain.Model.Aggregates.Component(command);

        try
        {
            await componentRepository.AddAsync(component);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the component: {e.Message}");
        }

        return component;
    }
}
using Backend.Component.Domain.Model.Commands;
using Backend.Component.Domain.Repositories;
using Backend.Component.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Component.Application.Internal.CommandServices;

public class ComponentCommandService(IComponentRepository componentRepository,
    IUnitOfWork unitOfWork) : IComponentCommandService
{
    public async Task<Domain.Model.Aggregates.Component?> Handle(CreateComponentCommand command)
    {
        var component =
            await componentRepository.FindByIdAsync(command.Id);
        if (component != null)
            throw new Exception("Component with componentId already exists");

        component = new Domain.Model.Aggregates.Component(command);

        try
        {
            await componentRepository.AddAsync(component);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return component;
    }
}
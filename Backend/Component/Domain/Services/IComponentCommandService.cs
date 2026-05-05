using Backend.Component.Application.Internal.CommandServices;
using Backend.Component.Domain.Model.Commands;

namespace Backend.Component.Domain.Services;

public interface IComponentCommandService
{
    Task<Model.Aggregates.Component?> Handle(CreateComponentCommand createComponentCommand);
}
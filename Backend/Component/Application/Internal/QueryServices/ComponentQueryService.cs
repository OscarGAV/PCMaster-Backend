using Backend.Component.Domain.Model.Queries;
using Backend.Component.Domain.Repositories;
using Backend.Component.Domain.Services;

namespace Backend.Component.Application.Internal.QueryServices;

public class ComponentQueryService(IComponentRepository componentRepository) : IComponentQueryService
{
    public async Task<Domain.Model.Aggregates.Component?> Handle(GetComponentByIdQuery query)
    {
        return await componentRepository.FindByIdAsync(query.ComponentId);
    }

    public async Task<Domain.Model.Aggregates.Component> Handle(GetComponentsByCategoryQuery query)
    {
        return await componentRepository.GetComponentsByCategoryAsync(query.Category);
    }

    public async Task<Domain.Model.Aggregates.Component> Handle(GetComponentsByProviderQuery query)
    {
        return await componentRepository.GetComponentsByProviderAsync(query.ProviderId);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Component>> Handle(GetAllComponentsQuery query)
    {
        return await componentRepository.ListAsync();
    }
}
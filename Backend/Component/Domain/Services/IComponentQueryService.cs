using Backend.Component.Domain.Model.Queries;
namespace Backend.Component.Domain.Services;

public interface IComponentQueryService
{
    Task<Model.Aggregates.Component?> Handle(GetComponentByIdQuery query);
    Task<Model.Aggregates.Component> Handle(GetComponentsByCategoryQuery query);
    Task<Model.Aggregates.Component> Handle(GetComponentsByProviderQuery query);
    Task<IEnumerable<Model.Aggregates.Component>>Handle(GetAllComponentsQuery query);
}
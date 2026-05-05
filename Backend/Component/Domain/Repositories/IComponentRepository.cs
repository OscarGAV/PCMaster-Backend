using Backend.Shared.Domain.Repositories;

namespace Backend.Component.Domain.Repositories;

public interface IComponentRepository : IBaseRepository<Model.Aggregates.Component>
{
    Task<List<Model.Aggregates.Component>> FindComponentByIdAsync(int Id);
    Task<Model.Aggregates.Component> GetComponentsByCategoryAsync(string category);
    Task<Model.Aggregates.Component> GetComponentsByProviderAsync(string providerId);
    Task AddAsync();
    Task<Task<Model.Aggregates.Component>> GetAllAsync();
}
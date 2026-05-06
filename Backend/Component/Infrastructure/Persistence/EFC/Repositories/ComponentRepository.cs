using Backend.Component.Domain.Model.Queries;
using Backend.Component.Domain.Repositories;
using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Component.Infrastructure.Persistence.EFC.Repositories;
public class ComponentRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.Component>(context), IComponentRepository
{
    public async Task<List<Domain.Model.Aggregates.Component>> FindComponentByIdAsync(int id)
    {
        return await Context.Set<Domain.Model.Aggregates.Component>().Where(c => c.Id == id).ToListAsync();
    }

    public Task<Domain.Model.Aggregates.Component> GetComponentsByCategoryAsync(string category)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Aggregates.Component> GetComponentsByProviderAsync(string providerId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Task<Domain.Model.Aggregates.Component>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Model.Aggregates.Component>> Handle(GetAllComponentsQuery query)
    {
        /*return await ComponentRepository.ListAsync();*/
        throw new NotImplementedException();
    }

    public async Task<double?> GetAverageRatingByComponentIdAsync(int componentId)
    {
        var ratings = await Context.Set<ComponentReview>()
            .Where(r => r.ComponentId.CompId == componentId)
            .Select(r => r.Rating)
            .ToListAsync();

        if (!ratings.Any())
            return null;

        return ratings.Average();
    }
}

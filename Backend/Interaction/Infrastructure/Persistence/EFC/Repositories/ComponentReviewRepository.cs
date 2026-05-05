using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.ValueObjects;
using Backend.Interaction.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

public class ComponentReviewRepository(AppDbContext context) : BaseRepository<ComponentReview>(context), IComponentReviewRepository
{
    public async Task<IEnumerable<ComponentReview>> FindReviewComponentByComponentIdAsync(int componentId)
    {
        return await Context.Set<ComponentReview>()
            .Where(componentReview => componentReview.ComponentId.CompId == componentId)
            .ToListAsync();
    }

    public async Task UpdateAsync(ComponentReview componentReview)
    {
        Context.Set<ComponentReview>().Update(componentReview);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ComponentReview componentReview)
    {
        if (componentReview == null)
        {
            throw new ArgumentNullException(nameof(componentReview), "ComponentReview entity cannot be null.");
        }

        Context.Set<ComponentReview>().Remove(componentReview);
        await Context.SaveChangesAsync();
    }
}
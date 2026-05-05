using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

public class TechnicalSupportReviewRepository(AppDbContext context) : BaseRepository<TechnicalSupportReview>(context), ITechnicalSupportReviewRepository
{
    public async Task<IEnumerable<TechnicalSupportReview>> FindByTechnicalSupportIdAsync(int technicalSupportId)
    {
        return await Context.Set<TechnicalSupportReview>()
            .Where(reviewTechnicalSupport => reviewTechnicalSupport.TechnicalSupportId.TechSupportId == technicalSupportId)
            .ToListAsync();
    }

    public async Task UpdateAsync(TechnicalSupportReview technicalSupportReview)
    {
        Context.Set<TechnicalSupportReview>().Update(technicalSupportReview);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TechnicalSupportReview technicalSupportReview)
    {
        if (technicalSupportReview == null)
        {
            throw new ArgumentNullException(nameof(technicalSupportReview), "TechnicalSupportReview entity cannot be null.");
        }

        Context.Set<TechnicalSupportReview>().Remove(technicalSupportReview);
        await Context.SaveChangesAsync();
    }
}
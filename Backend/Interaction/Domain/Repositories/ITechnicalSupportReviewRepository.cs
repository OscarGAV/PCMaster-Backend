using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend. Interaction. Domain. Repositories;

public interface ITechnicalSupportReviewRepository: IBaseRepository<TechnicalSupportReview>
{
    Task<IEnumerable<TechnicalSupportReview>> FindByTechnicalSupportIdAsync(int technicalSupportId);
    Task UpdateAsync(TechnicalSupportReview technicalSupportReview);
    
    Task DeleteAsync(TechnicalSupportReview technicalSupportReview);
    
}
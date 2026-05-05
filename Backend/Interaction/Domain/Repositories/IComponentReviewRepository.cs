using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend. Interaction. Domain. Repositories;

public interface IComponentReviewRepository: IBaseRepository<ComponentReview>
{
    Task<IEnumerable<ComponentReview>> FindReviewComponentByComponentIdAsync(int componentId);
    Task UpdateAsync(ComponentReview componentReview);
    
    Task DeleteAsync(ComponentReview componentReview);
}
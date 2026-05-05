using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class ComponentReviewQueryService(IComponentReviewRepository componentReviewRepository)
    : IComponentReviewQueryService
{
    public async Task<IEnumerable<ComponentReview>> Handle(GetAllComponentReviewsByComponentIdQuery query)
    {
        return await componentReviewRepository.FindReviewComponentByComponentIdAsync(query.ComponentId.CompId);
    }
}
using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class ComponentReviewQueryService : IComponentReviewQueryService
{
    private readonly IComponentReviewRepository _componentReviewRepository;

    public ComponentReviewQueryService(IComponentReviewRepository componentReviewRepository)
    {
        _componentReviewRepository = componentReviewRepository;
    }

    public async Task<IEnumerable<ComponentReview>> Handle(GetAllComponentReviewsByComponentIdQuery query)
    {
        return await _componentReviewRepository.FindReviewComponentByComponentIdAsync(query.ComponentId.CompId);
    }
}
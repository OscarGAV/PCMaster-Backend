using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;

namespace Backend.Interaction.Domain.Services;

public interface IComponentReviewQueryService
{
    Task<IEnumerable<ComponentReview>> Handle(GetAllComponentReviewsByComponentIdQuery query);
}
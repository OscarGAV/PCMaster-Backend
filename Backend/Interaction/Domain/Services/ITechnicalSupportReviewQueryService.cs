using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;

namespace Backend.Interaction.Domain.Services;

public interface ITechnicalSupportReviewQueryService
{
    Task<IEnumerable<TechnicalSupportReview>> Handle(GetAllTechnicalSupportReviewsByTechnicalSupportIdQuery query);
}
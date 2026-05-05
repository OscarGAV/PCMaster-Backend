using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class TechnicalSupportReviewQueryService(ITechnicalSupportReviewRepository technicalSupportReviewRepository)
    : ITechnicalSupportReviewQueryService
{
    public async Task<IEnumerable<TechnicalSupportReview>> Handle(GetAllTechnicalSupportReviewsByTechnicalSupportIdQuery query)
    {
        return await technicalSupportReviewRepository.FindByTechnicalSupportIdAsync(query.TechnicalSupportId.TechSupportId);
    }
}
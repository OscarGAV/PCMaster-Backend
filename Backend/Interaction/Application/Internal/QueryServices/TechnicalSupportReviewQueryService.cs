using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class TechnicalSupportReviewQueryService : ITechnicalSupportReviewQueryService
{
    private readonly ITechnicalSupportReviewRepository _technicalSupportReviewRepository;

    public TechnicalSupportReviewQueryService(ITechnicalSupportReviewRepository technicalSupportReviewRepository)
    {
        _technicalSupportReviewRepository = technicalSupportReviewRepository;
    }

    public async Task<IEnumerable<TechnicalSupportReview>> Handle(GetAllTechnicalSupportReviewsByTechnicalSupportIdQuery query)
    {
        return await _technicalSupportReviewRepository.FindByTechnicalSupportIdAsync(query.TechnicalSupportId.TechSupportId);
    }
}
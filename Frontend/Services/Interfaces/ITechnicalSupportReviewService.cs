using PCMasterFrontend.Models.TechnicalSupportReview;

namespace PCMasterFrontend.Services.Interfaces;

public interface ITechnicalSupportReviewService
{
    Task<List<TechnicalSupportReviewDto>> GetByTechnicalSupportIdAsync(int tsId);
    Task<TechnicalSupportReviewDto?> CreateAsync(CreateTechnicalSupportReviewRequest request);
    Task<TechnicalSupportReviewDto?> UpdateAsync(int id, UpdateTechnicalSupportReviewRequest request);
    Task DeleteAsync(int id);
}

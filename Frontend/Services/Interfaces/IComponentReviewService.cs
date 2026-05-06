using PCMasterFrontend.Models.ComponentReview;

namespace PCMasterFrontend.Services.Interfaces;

public interface IComponentReviewService
{
    Task<List<ComponentReviewDto>> GetByComponentIdAsync(int componentId);
    Task<ComponentReviewDto?> CreateAsync(CreateComponentReviewRequest request);
    Task<ComponentReviewDto?> UpdateAsync(int id, UpdateComponentReviewRequest request);
    Task DeleteAsync(int id);
}

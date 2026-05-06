using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.ComponentReview;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class ComponentReviewService : IComponentReviewService
{
    private readonly IApiClient _apiClient;

    public ComponentReviewService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<ComponentReviewDto>> GetByComponentIdAsync(int componentId)
    {
        return await _apiClient.GetAsync<List<ComponentReviewDto>>(Endpoints.ComponentReviewByComponent(componentId)) ?? new List<ComponentReviewDto>();
    }

    public async Task<ComponentReviewDto?> CreateAsync(CreateComponentReviewRequest request)
    {
        return await _apiClient.PostAsync<ComponentReviewDto>(Endpoints.ComponentReview, request);
    }

    public async Task<ComponentReviewDto?> UpdateAsync(int id, UpdateComponentReviewRequest request)
    {
        return await _apiClient.PutAsync<ComponentReviewDto>(Endpoints.ComponentReviewById(id), request);
    }

    public async Task DeleteAsync(int id)
    {
        await _apiClient.DeleteAsync(Endpoints.ComponentReviewById(id));
    }
}

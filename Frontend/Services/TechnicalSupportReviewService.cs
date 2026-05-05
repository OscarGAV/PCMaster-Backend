using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.TechnicalSupportReview;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class TechnicalSupportReviewService : ITechnicalSupportReviewService
{
    private readonly IApiClient _apiClient;

    public TechnicalSupportReviewService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<TechnicalSupportReviewDto>> GetByTechnicalSupportIdAsync(int tsId)
    {
        return await _apiClient.GetAsync<List<TechnicalSupportReviewDto>>(Endpoints.TechnicalSupportReviewByTs(tsId)) ?? new List<TechnicalSupportReviewDto>();
    }

    public async Task<TechnicalSupportReviewDto?> CreateAsync(CreateTechnicalSupportReviewRequest request)
    {
        return await _apiClient.PostAsync<TechnicalSupportReviewDto>(Endpoints.TechnicalSupportReview, request);
    }

    public async Task<TechnicalSupportReviewDto?> UpdateAsync(int id, UpdateTechnicalSupportReviewRequest request)
    {
        return await _apiClient.PutAsync<TechnicalSupportReviewDto>(Endpoints.TechnicalSupportReviewById(id), request);
    }

    public async Task DeleteAsync(int id)
    {
        await _apiClient.DeleteAsync(Endpoints.TechnicalSupportReviewById(id));
    }
}

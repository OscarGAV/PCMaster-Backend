using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.TechnicalSupport;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class TechnicalSupportService : ITechnicalSupportService
{
    private readonly IApiClient _apiClient;

    public TechnicalSupportService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<TechnicalSupportDto>> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<TechnicalSupportDto>>(Endpoints.TechnicalSupport) ?? new List<TechnicalSupportDto>();
    }

    public async Task<TechnicalSupportDto?> GetByIdAsync(int id)
    {
        return await _apiClient.GetAsync<TechnicalSupportDto>(Endpoints.TechnicalSupportById(id));
    }

    public async Task<List<TechnicalSupportDto>> GetFilteredAsync(bool supportType, int? technicianId = null)
    {
        var endpoint = Endpoints.TechnicalSupportFiltered(supportType, technicianId);
        return await _apiClient.GetAsync<List<TechnicalSupportDto>>(endpoint) ?? new List<TechnicalSupportDto>();
    }

    public async Task<TechnicalSupportDto?> CreateAsync(CreateTechnicalSupportRequest request)
    {
        return await _apiClient.PostAsync<TechnicalSupportDto>(Endpoints.TechnicalSupport, request);
    }

    public async Task<TechnicalSupportDto?> UpdateAsync(int id, UpdateTechnicalSupportRequest request)
    {
        return await _apiClient.PutAsync<TechnicalSupportDto>(Endpoints.TechnicalSupportById(id), request);
    }

    public async Task DeleteAsync(int id)
    {
        await _apiClient.DeleteAsync(Endpoints.TechnicalSupportById(id));
    }
}

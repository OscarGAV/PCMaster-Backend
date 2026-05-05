using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.Technician;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class TechnicianService : ITechnicianService
{
    private readonly IApiClient _apiClient;

    public TechnicianService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<TechnicianDto>> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<TechnicianDto>>(Endpoints.Technicians) ?? new List<TechnicianDto>();
    }

    public async Task<List<TechnicianDto>> GetTopRankedAsync()
    {
        return await _apiClient.GetAsync<List<TechnicianDto>>(Endpoints.TechniciansTopRanked) ?? new List<TechnicianDto>();
    }

    public async Task<TechnicianDto?> GetByIdAsync(int id)
    {
        return await _apiClient.GetAsync<TechnicianDto>(Endpoints.TechnicianById(id));
    }

    public async Task<TechnicianDto?> CreateAsync(CreateTechnicianRequest request)
    {
        return await _apiClient.PostAsync<TechnicianDto>(Endpoints.Technicians, request);
    }

    public async Task<TechnicianDto?> UpdateAsync(int id, UpdateTechnicianRequest request)
    {
        return await _apiClient.PutAsync<TechnicianDto>(Endpoints.TechnicianById(id), request);
    }

    public async Task DeleteAsync(int id)
    {
        await _apiClient.DeleteAsync(Endpoints.TechnicianById(id));
    }
}

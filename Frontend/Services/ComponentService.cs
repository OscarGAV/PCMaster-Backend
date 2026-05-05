using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.Component;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class ComponentService : IComponentService
{
    private readonly IApiClient _apiClient;

    public ComponentService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<ComponentDto>> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<ComponentDto>>(Endpoints.Components) ?? new List<ComponentDto>();
    }

    public async Task<ComponentDto?> GetByIdAsync(int id)
    {
        return await _apiClient.GetAsync<ComponentDto>(Endpoints.ComponentById(id));
    }

    public async Task<ComponentDto?> CreateAsync(CreateComponentRequest request)
    {
        return await _apiClient.PostAsync<ComponentDto>(Endpoints.Components, request);
    }
}

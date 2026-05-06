using PCMasterFrontend.Models.Component;

namespace PCMasterFrontend.Services.Interfaces;

public interface IComponentService
{
    Task<List<ComponentDto>> GetAllAsync();
    Task<ComponentDto?> GetByIdAsync(int id);
    Task<ComponentDto?> CreateAsync(CreateComponentRequest request);
}

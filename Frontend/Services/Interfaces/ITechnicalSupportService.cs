using PCMasterFrontend.Models.TechnicalSupport;

namespace PCMasterFrontend.Services.Interfaces;

public interface ITechnicalSupportService
{
    Task<List<TechnicalSupportDto>> GetAllAsync();
    Task<TechnicalSupportDto?> GetByIdAsync(int id);
    Task<List<TechnicalSupportDto>> GetFilteredAsync(bool supportType, int? technicianId = null);
    Task<TechnicalSupportDto?> CreateAsync(CreateTechnicalSupportRequest request);
    Task<TechnicalSupportDto?> UpdateAsync(int id, UpdateTechnicalSupportRequest request);
    Task DeleteAsync(int id);
}

using PCMasterFrontend.Models.Technician;

namespace PCMasterFrontend.Services.Interfaces;

public interface ITechnicianService
{
    Task<List<TechnicianDto>> GetAllAsync();
    Task<List<TechnicianDto>> GetTopRankedAsync();
    Task<TechnicianDto?> GetByIdAsync(int id);
    Task<TechnicianDto?> CreateAsync(CreateTechnicianRequest request);
    Task<TechnicianDto?> UpdateAsync(int id, UpdateTechnicianRequest request);
    Task DeleteAsync(int id);
}

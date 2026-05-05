using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport;

namespace Backend.TechnicalSupport.Domain.Repositories;

public interface ITechnicalSupportRepository : IBaseRepository<TechnicalSupport>
{
    Task<IEnumerable<TechnicalSupport>> FindBySupportTypeAsync(bool supportType);
    
    Task<TechnicalSupport?> FindBySupportTypeAndTechnicianIdAsync(bool supportType, string technicianId);
    
    Task UpdateAsync(TechnicalSupport technicalSupport);
    
    Task DeleteAsync(TechnicalSupport technicalSupport);
}
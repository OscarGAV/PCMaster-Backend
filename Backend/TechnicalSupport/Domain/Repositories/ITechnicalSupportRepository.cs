using Backend.Shared.Domain.Repositories;

namespace Backend.TechnicalSupport.Domain.Repositories;

public interface ITechnicalSupportRepository : IBaseRepository<Model.Aggregates.TechnicalSupport>
{
    Task<IEnumerable<Model.Aggregates.TechnicalSupport>> FindBySupportTypeAsync(bool supportType);
    
    Task<Model.Aggregates.TechnicalSupport?> FindBySupportTypeAndTechnicianIdAsync(bool supportType, string technicianId);
    
    Task UpdateAsync(Model.Aggregates.TechnicalSupport technicalSupport);
    
    Task DeleteAsync(Model.Aggregates.TechnicalSupport technicalSupport);
}
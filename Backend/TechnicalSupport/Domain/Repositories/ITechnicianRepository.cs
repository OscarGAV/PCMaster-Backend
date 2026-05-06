using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Model.Aggregates;

namespace Backend.TechnicalSupport.Domain.Repositories;

public interface ITechnicianRepository : IBaseRepository<Technician>
{
    Task<Technician?> FindByNameAsync(string name);
    
    Task<double?> GetAverageRatingByTechnicianNameAsync(string technicianName);
    
    Task UpdateAsync(Technician technician);
    
    Task DeleteAsync(Technician technician);
}
using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport;

namespace Backend.TechnicalSupport.Domain.Repositories;

public interface ITechnicianRepository : IBaseRepository<Technician>
{
    Task<Technician?> FindByNameAsync(string name);
    
    Task<Technician?> FindByStarsAsync(double stars);
    
    Task UpdateAsync(Technician technician);
    
    Task DeleteAsync(Technician technician);
}
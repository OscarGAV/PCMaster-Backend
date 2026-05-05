using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend.TechnicalSupport;
using Backend.TechnicalSupport.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.TechnicalSupport.Infrastructure.Repositories;

public class TechnicianRepository(AppDbContext ctx)
    : BaseRepository<Technician>(ctx), ITechnicianRepository
{
    
    public async Task<Technician?> FindByNameAsync(string name)
    {
        return await Context.Set<Technician>().FirstOrDefaultAsync(f=>f.Name == name);
    }

    public async Task<Technician?> FindByStarsAsync(double stars)
    {
        const double tolerance = 0.001; // Adjustable value based on required precision
        return await Context.Set<Technician>()
            .FirstOrDefaultAsync(f => Math.Abs(f.Stars - stars) < tolerance);
    }
    
    public async Task UpdateAsync(Technician technician)
    {
        //Update method of DbSet
        Context.Set<Technician>().Update(technician);
        await Context.SaveChangesAsync(); // Ensure you save the changes
    }
    
    public async Task DeleteAsync(Technician technician)
    {
        // Check if the technicians exists in the database
        if (technician == null)
        {
            throw new ArgumentNullException(nameof(technician), "Technician entity cannot be null.");
        }

        // Remove the entity from the DbSet
        Context.Set<Technician>().Remove(technician);
        await Context.SaveChangesAsync(); // Save changes to the database
    }
}
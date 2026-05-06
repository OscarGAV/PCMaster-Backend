using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend.TechnicalSupport.Domain.Model.Aggregates;
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

    public async Task<double?> GetAverageRatingByTechnicianNameAsync(string technicianName)
    {
        // Find all TechnicalSupport tickets assigned to this technician
        var ticketIds = await Context.Set<TechnicalSupport.Domain.Model.Aggregates.TechnicalSupport>()
            .Where(ts => ts.TechnicianId == technicianName)
            .Select(ts => ts.Id)
            .ToListAsync();

        if (!ticketIds.Any())
            return null;

        // Find all reviews for these tickets
        var ratings = await Context.Set<TechnicalSupportReview>()
            .Where(review => ticketIds.Contains(review.TechnicalSupportId.TechSupportId))
            .Select(review => review.Rating)
            .ToListAsync();

        if (!ratings.Any())
            return null;

        return ratings.Average();
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

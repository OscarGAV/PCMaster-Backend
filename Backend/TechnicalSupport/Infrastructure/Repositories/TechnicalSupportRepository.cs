using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend.TechnicalSupport.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.TechnicalSupport.Infrastructure.Repositories;

public class TechnicalSupportRepository(AppDbContext ctx)
: BaseRepository<Domain.Model.Aggregates.TechnicalSupport>(ctx), ITechnicalSupportRepository
{
    public async Task<IEnumerable<Domain.Model.Aggregates.TechnicalSupport>> FindBySupportTypeAsync(bool supportType)
    {
        return await Context.Set<Domain.Model.Aggregates.TechnicalSupport>().Where(f=>f.SupportType == supportType).ToListAsync();
    }

    public async Task<Domain.Model.Aggregates.TechnicalSupport?> FindBySupportTypeAndTechnicianIdAsync(bool supportType, string technicianId)
    {
        return await Context.Set<Domain.Model.Aggregates.TechnicalSupport>().FirstOrDefaultAsync(f=>f.SupportType == supportType && f.TechnicianId == technicianId);
    }
    
    public async Task UpdateAsync(Domain.Model.Aggregates.TechnicalSupport technicalSupport)
    {
        //Update method of DbSet
        Context.Set<Domain.Model.Aggregates.TechnicalSupport>().Update(technicalSupport);
        await Context.SaveChangesAsync(); // Ensure you save the changes
    }
    
    public async Task DeleteAsync(Domain.Model.Aggregates.TechnicalSupport technicalSupport)
    {
        // Check if the technicalSupport exists in the database
        if (technicalSupport == null)
        {
            throw new ArgumentNullException(nameof(technicalSupport), "TechnicalSupport entity cannot be null.");
        }

        // Remove the entity from the DbSet
        Context.Set<Domain.Model.Aggregates.TechnicalSupport>().Remove(technicalSupport);
        await Context.SaveChangesAsync(); // Save changes to the database
    }
}
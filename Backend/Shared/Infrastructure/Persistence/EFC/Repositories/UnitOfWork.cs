using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}
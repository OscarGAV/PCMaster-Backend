using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>()
            .Include(u => u.UserRoles)
            .FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }

    public new async Task<User?> FindByIdAsync(int id)
    {
        return await Context.Set<User>()
            .Include(u => u.UserRoles)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public new async Task<IEnumerable<User>> ListAsync()
    {
        return await Context.Set<User>()
            .Include(u => u.UserRoles)
            .ToListAsync();
    }
}
using Backend.Orders.Domain.Model.Aggregates;

using Backend.Orders.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Orders.Infrastructure.Repositories;

public class CartRepository(AppDbContext context) : BaseRepository<Cart>(context), ICartRepository
{
    public async Task<IEnumerable<Cart>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Cart>().Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<Cart?> FindByComponentIdAsync(int productId)
    {
        return await Context.Set<Cart>().FirstOrDefaultAsync(f => f.ComponentId == productId);
    }

    public async Task DeleteByIdAsync(Cart cart)
    {

        if (cart == null)
        {
            throw new ArgumentNullException(nameof(cart), "Cart not found");
        }

        // Delete cart
        Context.Set<Cart>().Remove(cart);
    }

    public async Task<bool> ComponentIdExistsForUserAsync(int userId, int componentId)
    {
        return await Context.Set<Cart>()
            .AnyAsync(c => c.UserId == userId && c.ComponentId == componentId);
    }

    public async Task<IEnumerable<Cart>> GetCarts()
    {
        return await Context.Set<Cart>().ToListAsync();
    }
    
}
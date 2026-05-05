using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

public class WishlistRepository(AppDbContext context) : BaseRepository<Wishlist>(context), IWishlistRepository
{
    public async Task<IEnumerable<Wishlist>> FindWishlistByUserIdAsync(int userId)
    {
        return await Context.Set<Wishlist>()
            .Where(wishlist => wishlist.UserId.UsrId == userId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Wishlist wishlist)
    {
        Context.Set<Wishlist>().Update(wishlist);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Wishlist wishlist)
    {
        if (wishlist == null)
        {
            throw new ArgumentNullException(nameof(wishlist), "Wishlist entity cannot be null.");
        }

        Context.Set<Wishlist>().Remove(wishlist);
        await Context.SaveChangesAsync();
    }
}
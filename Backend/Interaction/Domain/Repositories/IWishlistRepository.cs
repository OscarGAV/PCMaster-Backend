using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Domain.Repositories;

public interface IWishlistRepository: IBaseRepository<Wishlist>
{
    Task<IEnumerable<Wishlist>> FindWishlistByUserIdAsync(int userId);
    Task UpdateAsync(Wishlist wishlist);
    
    Task DeleteAsync(Wishlist wishlist);
}
using Backend.Orders.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Orders.Domain.Repositories;

public interface ICartRepository : IBaseRepository<Cart>
{
    // Cart interface repository
    
    Task<IEnumerable<Cart>> FindByUserIdAsync(int userId);

    Task<Cart?> FindByComponentIdAsync(int productId);
    
    Task DeleteByIdAsync(Cart cart);
    
    Task<bool> ComponentIdExistsForUserAsync(int userId, int componentId);
    
    Task<IEnumerable<Cart>> GetCarts();
}
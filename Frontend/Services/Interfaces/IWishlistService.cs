using PCMasterFrontend.Models.Wishlist;

namespace PCMasterFrontend.Services.Interfaces;

public interface IWishlistService
{
    Task<List<WishlistDto>> GetByUserIdAsync(int userId);
    Task<WishlistDto?> CreateAsync(CreateWishlistRequest request);
    Task<WishlistDto?> UpdateAsync(int id, UpdateWishlistRequest request);
    Task DeleteAsync(int id);
}

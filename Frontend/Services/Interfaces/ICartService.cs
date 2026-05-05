using PCMasterFrontend.Models.Cart;

namespace PCMasterFrontend.Services.Interfaces;

public interface ICartService
{
    Task<List<CartDto>> GetAllAsync();
    Task<List<CartDto>> GetByUserIdAsync(int userId);
    Task<CartDto?> CreateAsync(CreateCartRequest request);
    Task DeleteAsync(int id);
}

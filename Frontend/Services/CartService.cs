using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.Cart;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class CartService : ICartService
{
    private readonly IApiClient _apiClient;

    public CartService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<CartDto>> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<CartDto>>(Endpoints.Cart) ?? new List<CartDto>();
    }

    public async Task<List<CartDto>> GetByUserIdAsync(int userId)
    {
        return await _apiClient.GetAsync<List<CartDto>>(Endpoints.CartByUser(userId)) ?? new List<CartDto>();
    }

    public async Task<CartDto?> CreateAsync(CreateCartRequest request)
    {
        return await _apiClient.PostAsync<CartDto>(Endpoints.Cart, request);
    }

    public async Task DeleteAsync(int id)
    {
        await _apiClient.DeleteAsync(Endpoints.CartById(id));
    }
}

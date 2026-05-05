using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.Wishlist;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class WishlistService : IWishlistService
{
    private readonly IApiClient _apiClient;

    public WishlistService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<WishlistDto>> GetByUserIdAsync(int userId)
    {
        return await _apiClient.GetAsync<List<WishlistDto>>(Endpoints.WishlistByUser(userId)) ?? new List<WishlistDto>();
    }

    public async Task<WishlistDto?> CreateAsync(CreateWishlistRequest request)
    {
        return await _apiClient.PostAsync<WishlistDto>(Endpoints.Wishlist, request);
    }

    public async Task<WishlistDto?> UpdateAsync(int id, UpdateWishlistRequest request)
    {
        return await _apiClient.PutAsync<WishlistDto>(Endpoints.WishlistById(id), request);
    }

    public async Task DeleteAsync(int id)
    {
        await _apiClient.DeleteAsync(Endpoints.WishlistById(id));
    }
}

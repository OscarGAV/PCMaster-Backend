using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Models.User;
using PCMasterFrontend.Services.Interfaces;

namespace PCMasterFrontend.Services;

public class UserService : IUserService
{
    private readonly IApiClient _apiClient;

    public UserService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<UserDto>>(Endpoints.Users) ?? new List<UserDto>();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        return await _apiClient.GetAsync<UserDto>(Endpoints.UserById(id));
    }
}

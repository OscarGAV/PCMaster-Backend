using PCMasterFrontend.Models.User;

namespace PCMasterFrontend.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
}

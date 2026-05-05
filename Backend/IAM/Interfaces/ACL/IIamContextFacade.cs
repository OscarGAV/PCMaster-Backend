using Backend.IAM.Domain.Model.ValueObjects;

namespace Backend.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password, ERole role);
    
    Task<int> FetchUserIdByUsername(string username);
    
    Task<string> FetchUsernameByUserId(int userId);
}
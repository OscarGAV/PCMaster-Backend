using Backend.IAM.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.IAM.Domain.Repositories;

/// <summary>
/// Represents the user repository. 
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    /// Finds a user by username. 
    /// </summary>
    /// <param name="username">
    /// The username to search for.
    /// </param>
    /// <returns>
    /// The user if found; otherwise, null.
    /// </returns>
    Task<User?> FindByUsernameAsync(string username);
    
    /// <summary>
    /// Checks if a user with the specified username exists. 
    /// </summary>
    /// <param name="username">
    /// The username to check for.
    /// </param>
    /// <returns>
    /// True if a user with the specified username exists; otherwise, false.
    /// </returns>
    bool ExistsByUsername(string username);

}
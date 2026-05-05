using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;

namespace Backend.Interaction.Domain.Services;

public interface IWishlistCommandService
{
    Task<Wishlist?> Handle(CreateWishlistCommand command);
    /// <summary>
    /// Handles the update of an existing Wishlist request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> The updated instance. </returns>
    Task<Wishlist> Handle(UpdateWishlistCommand command);
    
    /// <summary>
    /// Handles the deletion of a Wishlist request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> True if the deletion was successful, otherwise false. </returns>
    Task<bool> Handle(DeleteWishlistCommand command);
}
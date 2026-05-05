using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Application.Internal.CommandServices;
/// <summary>
/// Initializes a new instance of the <see cref="WishlistCommandService"/> class.
/// </summary>
/// <param name="wishlistSupportRepository">Repository for managing wishlist.</param>
/// <param name="unitOfWork"></param>
public class WishlistCommandService(IWishlistRepository wishlistRepository,
    IUnitOfWork unitOfWork)
    : IWishlistCommandService
{
    /// <summary>
    /// Handles the creation of a new wishlist.
    /// </summary>
    /// <param name="command">The command containing the necessary data to create the wishlist.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The result contains the created wishlist, 
    /// or <c>null</c> if it could not be created.
    /// </returns>

    public async Task<Wishlist?> Handle(CreateWishlistCommand command)
    {
        var wishlist = new Wishlist(command);
        await wishlistRepository.AddAsync(wishlist);
        await unitOfWork.CompleteAsync();
        return wishlist;
    }

    public async Task<Wishlist> Handle(UpdateWishlistCommand command)
    {
        var wishlist = await wishlistRepository.FindByIdAsync(command.Id);

        if (wishlist == null)
        {
            throw new Exception($"Wishlist with Id {command.Id} does not exist.");
        }

        wishlist.Update(command);

        try
        {
            await wishlistRepository.UpdateAsync(wishlist);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return wishlist;
    }

    public async Task<bool> Handle(DeleteWishlistCommand command)
    {
        var wishlist = await wishlistRepository.FindByIdAsync(command.Id);
        if (wishlist == null)
        {
            return false;
        }

        await wishlistRepository.DeleteAsync(wishlist);
        return true;
    }
}
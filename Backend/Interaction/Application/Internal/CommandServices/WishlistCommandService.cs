using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;

namespace Backend.Interaction.Application.Internal.CommandServices;

public class WishlistCommandService(IWishlistRepository wishlistRepository,
    IUnitOfWork unitOfWork)
    : IWishlistCommandService
{
    public async Task<Wishlist?> Handle(CreateWishlistCommand command)
    {
        if (command.UserId <= 0)
            throw new ValidationException("UserId must be a positive number");

        if (command.ComponentId <= 0)
            throw new ValidationException("ComponentId must be a positive number");

        if (command.Quantity <= 0)
            throw new ValidationException("Quantity must be at least 1");

        var wishlist = new Wishlist(command);
        await wishlistRepository.AddAsync(wishlist);
        await unitOfWork.CompleteAsync();
        return wishlist;
    }

    public async Task<Wishlist> Handle(UpdateWishlistCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        if (command.Quantity <= 0)
            throw new ValidationException("Quantity must be at least 1");

        var wishlist = await wishlistRepository.FindByIdAsync(command.Id);

        if (wishlist == null)
            throw new NotFoundException($"Wishlist with Id {command.Id} does not exist");

        wishlist.Update(command);

        try
        {
            await wishlistRepository.UpdateAsync(wishlist);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the wishlist: {e.Message}");
        }

        return wishlist;
    }

    public async Task<bool> Handle(DeleteWishlistCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        var wishlist = await wishlistRepository.FindByIdAsync(command.Id);
        if (wishlist == null)
            return false;

        await wishlistRepository.DeleteAsync(wishlist);
        return true;
    }
}
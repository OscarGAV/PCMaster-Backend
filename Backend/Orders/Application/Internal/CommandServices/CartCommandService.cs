using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Commands;
using Backend.Orders.Domain.Repositories;
using Backend.Orders.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;

namespace Backend.Orders.Application.Internal.CommandServices;

public class CartCommandService(ICartRepository cartRepository,
    IUnitOfWork unitOfWork) : ICartCommandService
{
    public async Task<Cart?> Handle(CreateCartCommand command)
    {
        if (command.ComponentId <= 0)
            throw new ValidationException("ComponentId must be a positive number");

        if (command.UserId <= 0)
            throw new ValidationException("UserId must be a positive number");

        if (command.Quantity <= 0)
            throw new ValidationException("Quantity must be at least 1");

        var exists = await cartRepository.ComponentIdExistsForUserAsync(command.UserId, command.ComponentId);

        if (exists)
            throw new DuplicateEntityException($"Component '{command.ComponentId}' already exists for user '{command.UserId}'");

        var cart = new Cart(command);

        try
        {
            await cartRepository.AddAsync(cart);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the cart: {e.Message}");
        }

        return cart;
    }

    public async Task<bool> Handle(DeleteCartCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        var cart = await cartRepository.FindByIdAsync(command.Id);

        if (cart == null)
            return false;

        try
        {
            await cartRepository.DeleteByIdAsync(cart);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting the cart: {e.Message}");
        }

        return true;
    }
}
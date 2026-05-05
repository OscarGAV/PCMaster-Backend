using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Commands;
using Backend.Orders.Domain.Repositories;
using Backend.Orders.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Orders.Application.Internal.CommandServices;

public class CartCommandService(ICartRepository cartRepository,
    IUnitOfWork unitOfWork) : ICartCommandService
{
    public async Task<Cart?> Handle(CreateCartCommand command)
    {
        var exists = await cartRepository.ComponentIdExistsForUserAsync(command.UserId, command.ComponentId);

        if (exists)
        {
            throw new Exception("Component" + command.ComponentId +" already exists for user " + command.UserId );
        }

        var cart = new Cart(command);

        try
        {
            await cartRepository.AddAsync(cart);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return cart;
    }

    public async Task<bool> Handle(DeleteCartCommand command)
    {
        var cart = 
                await cartRepository.FindByIdAsync(command.Id);

        if (cart == null)
        {
            return false;
            //throw new Exception("Cart not found to delete");
        }

        try
        {
            await cartRepository.DeleteByIdAsync(cart);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return true;
    }
}
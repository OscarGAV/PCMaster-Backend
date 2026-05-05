using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Queries;
using Backend.Orders.Domain.Repositories;
using Backend.Orders.Domain.Services;

namespace Backend.Orders.Application.Internal.QueryServices;

public class CartQueryService(ICartRepository cartRepository) : ICartQueryService
{
    public async Task<IEnumerable<Cart>> Handle(GetCartsByUserId query)
    {
        return await cartRepository.FindByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Cart>> Handle(GetCartsQuery query)
    {
        return await cartRepository.GetCarts();
    }
}
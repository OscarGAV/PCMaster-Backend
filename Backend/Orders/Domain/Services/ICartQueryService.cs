using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Queries;

namespace Backend.Orders.Domain.Services;

public interface ICartQueryService
{
    Task<IEnumerable<Cart>> Handle(GetCartsByUserId query);
    
    Task<IEnumerable<Cart>> Handle(GetCartsQuery query);
}
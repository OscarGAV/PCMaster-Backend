using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Interfaces.REST.Resource;

namespace Backend.Orders.Interfaces.REST.Transform;

public static class CartResourceFromEntityAssembler
{
    public static CartResource ToResourceFromEntity(Cart entity)
    {
        return new CartResource(entity.Id, entity.ComponentId, entity.UserId, entity.Quantity );
    }
}
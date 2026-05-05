using Backend.Orders.Domain.Model.Commands;
using Backend.Orders.Interfaces.REST.Resource;

namespace Backend.Orders.Interfaces.REST.Transform;

public class CreateCartCommandFromResourceAssembler
{
    public static CreateCartCommand toCommandFromResource(CreateCartResource resource)
    {
        return new CreateCartCommand(resource.ComponentId, resource.UserId, resource.Quantity);
    }
}
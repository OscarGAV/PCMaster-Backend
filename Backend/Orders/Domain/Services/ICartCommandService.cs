using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Commands;

namespace Backend.Orders.Domain.Services;

public interface ICartCommandService
{

    Task<Cart?> Handle(CreateCartCommand command);
    
    /// <summary>
    /// Delete Cart command
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<bool> Handle(DeleteCartCommand command);

}
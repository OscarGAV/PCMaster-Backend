using Backend.Orders.Domain.Model.Commands;

namespace Backend.Orders.Domain.Model.Aggregates;

public partial class Cart
{
    public int Id { get; }

    public int ComponentId { get; set; } // value object
    
    public int UserId { get; set; } // value object
    
    public int Quantity { get; set; }

    protected Cart()
    {
        ComponentId = 0;
        UserId = 0;
        Quantity = 0;
    }
    
    // Command

    public Cart(CreateCartCommand command)
    {
        ComponentId = command.ComponentId;
        UserId = command.UserId;
        Quantity = command.Quantity;
    }
}
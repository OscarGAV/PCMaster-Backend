namespace Backend.Orders.Interfaces.REST.Resource;

public record CreateCartResource(int ComponentId, int UserId, int Quantity);
namespace Backend.Orders.Interfaces.REST.Resource;

public record CartResource(int Id, int ComponentId, int UserId, int Quantity);
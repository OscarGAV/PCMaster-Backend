namespace Backend.Orders.Domain.Model.Commands;

/// <summary>
///  Command to create a cart
/// </summary>
public record CreateCartCommand(int ComponentId, int UserId, int Quantity);
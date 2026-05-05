using System.ComponentModel.DataAnnotations;

namespace Backend.Orders.Interfaces.REST.Resource;

public record CreateCartResource(
    [Range(1, int.MaxValue, ErrorMessage = "ComponentId must be a positive number")]
    int ComponentId,

    [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number")]
    int UserId,

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    int Quantity
);
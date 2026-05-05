using System.ComponentModel.DataAnnotations;

namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateWishlistResource(
    [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number")]
    int UserId,

    [Range(1, int.MaxValue, ErrorMessage = "ComponentId must be a positive number")]
    int ComponentId,

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    int Quantity
);
using System.ComponentModel.DataAnnotations;

namespace Backend.Interaction.Interfaces.Rest.Resources;

public record UpdateWishlistResource()
{
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }
}
namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateWishlistResource(
    int UserId,
    int ComponentId, 
    int Quantity)
{
    
}
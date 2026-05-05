namespace Backend.Interaction.Domain.Model.Commands;

public record CreateWishlistCommand(
    int UserId, 
    int ComponentId,
    int Quantity)
{
    
}
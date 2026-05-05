namespace Backend.Interaction.Domain.Model.Commands;
/// <summary>
/// Command to update Wishlist
/// </summary>
/// <param name="Id"></param>
/// <param name="UserId"></param>
/// <param name="ComponentName"></param>
/// <param name="QuantityComponents"></param>
public record UpdateWishlistCommand(
    int Id,
    //int UserId, 
    //string ComponentName, 
    int Quantity);
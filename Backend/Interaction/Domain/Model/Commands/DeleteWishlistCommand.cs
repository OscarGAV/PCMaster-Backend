namespace Backend.Interaction.Domain.Model.Commands;
/// <summary>
/// Command to delete wishlist by unique Id
/// </summary>
/// <param name="Id"></param>
public record DeleteWishlistCommand(int Id);
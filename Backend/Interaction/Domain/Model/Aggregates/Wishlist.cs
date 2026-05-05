using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Aggregates;

public class Wishlist
{
    public int Id { get; }
    public UserId UserId { get; private set; }
    public ComponentId ComponentId { get; private set; }
    public int Quantity { get; private set; }


    public Wishlist()
    {
        UserId = new UserId();
        ComponentId = new ComponentId();
        Quantity = 0;
    }

    public Wishlist(int userId, int componentId, int quantityComponents)
    {
        UserId = new UserId(userId);
        ComponentId = new ComponentId(componentId);
        Quantity = quantityComponents;
    }


    public Wishlist(CreateWishlistCommand command)
    {
        UserId = new UserId(command.UserId);
        ComponentId = new ComponentId(command.ComponentId);
        Quantity = command.Quantity;
    }

    public void Update(UpdateWishlistCommand command)
    {
        Quantity = command.Quantity;
    }
}
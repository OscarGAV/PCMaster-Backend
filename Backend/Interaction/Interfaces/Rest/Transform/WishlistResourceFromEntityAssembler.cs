using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class WishlistResourceFromEntityAssembler
{
    public static WishlistResource ToResourceFromEntity(Wishlist entity)
    {
        return new WishlistResource(entity.Id, entity.UserId.UsrId, entity.ComponentId.CompId, entity.Quantity);
    }
}
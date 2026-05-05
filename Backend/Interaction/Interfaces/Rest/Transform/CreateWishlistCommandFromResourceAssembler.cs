using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class CreateWishlistCommandFromResourceAssembler
{
    public static CreateWishlistCommand ToCommandFromResource(CreateWishlistResource resource)
    {
        return new CreateWishlistCommand(resource.UserId, resource.ComponentId, resource.Quantity);
    }
}
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public class UpdateWishlistCommandFromResourceAssembler
{
    public static UpdateWishlistCommand ToCommandFromResource(int id, UpdateWishlistResource resource)
    {
        return new UpdateWishlistCommand
        (
            Id: id,
            Quantity: resource.Quantity
        );
    }
}
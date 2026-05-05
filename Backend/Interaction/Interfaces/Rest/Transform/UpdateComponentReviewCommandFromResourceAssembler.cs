using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public class UpdateComponentReviewCommandFromResourceAssembler
{
    public static UpdateComponentReviewCommand ToCommandFromResource(int id, UpdateComponentReviewResource resource)
    {
        return new UpdateComponentReviewCommand
        (
            Id: id,
            Rating:resource.Rating,
            Comment:resource.Comment
        );
    }
}
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class UpdateTechnicalSupportReviewCommandFromResourceAssembler
{
    public static UpdateTechnicalSupportReviewCommand ToCommandFromResource(int id, UpdateTechnicalSupportReviewResource resource)
    {
        return new UpdateTechnicalSupportReviewCommand
        (
            Id: id,
            Rating:resource.Rating,
            Comment:resource.Comment
        );
    }
}
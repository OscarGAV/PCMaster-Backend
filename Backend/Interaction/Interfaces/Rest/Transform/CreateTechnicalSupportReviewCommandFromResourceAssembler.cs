using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class CreateTechnicalSupportReviewCommandFromResourceAssembler
{
    public static CreateTechnicalSupportReviewCommand ToCommandFromResource(CreateTechnicalSupportReviewResource resource)
    {
        return new CreateTechnicalSupportReviewCommand(resource.Rating, resource.Comment, resource.UserName, resource.TechnicalSupportId);
    }
}
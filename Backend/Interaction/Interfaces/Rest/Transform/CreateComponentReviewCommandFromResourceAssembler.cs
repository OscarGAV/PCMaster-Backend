using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class CreateComponentReviewCommandFromResourceAssembler
{
    public static CreateComponentReviewCommand ToCommandFromResource(CreateComponentReviewResource resource)
    {
        return new CreateComponentReviewCommand(resource.ComponentId, resource.UserName,resource.Rating, resource.Comment);
    }
}
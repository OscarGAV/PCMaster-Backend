using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class ComponentReviewResourceFromEntityAssembler
{
    public static ComponentReviewResource ToResourceFromEntity(ComponentReview entity)
    {
        return new ComponentReviewResource(entity.Id, entity.ComponentId.CompId, entity.UserName.Name, entity.Rating, entity.Comment);
    }
}
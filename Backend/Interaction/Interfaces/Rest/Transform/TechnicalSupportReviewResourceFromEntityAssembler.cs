using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class TechnicalSupportReviewResourceFromEntityAssembler
{
    public static TechnicalSupportReviewResource ToResourceFromEntity(TechnicalSupportReview entity)
    {
        return new TechnicalSupportReviewResource(entity.Id, entity.Rating, entity.Comment, entity.UserName.Name, entity.TechnicalSupportId.TechSupportId);
    }
}
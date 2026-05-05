namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateTechnicalSupportReviewResource(int Rating, string Comment, string UserName, int TechnicalSupportId)
{
    
}
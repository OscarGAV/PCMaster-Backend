namespace Backend.Interaction.Interfaces.Rest.Resources;

public record TechnicalSupportReviewResource(int Id, int Rating, string Comment, string UserName, int TechnicalSupportId)
{
    
}
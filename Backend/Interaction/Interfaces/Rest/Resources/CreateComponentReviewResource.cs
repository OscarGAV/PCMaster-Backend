namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateComponentReviewResource(int Rating, string Comment, string UserName, int ComponentId)
{
    
}
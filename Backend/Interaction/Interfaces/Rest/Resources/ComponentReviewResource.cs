namespace Backend.Interaction.Interfaces.Rest.Resources;

public record ComponentReviewResource(int Id, int ComponentId, string UserName, int Rating, string Comment)
{
    
}
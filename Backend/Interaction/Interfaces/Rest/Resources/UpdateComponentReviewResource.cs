namespace Backend.Interaction.Interfaces.Rest.Resources;

public record UpdateComponentReviewResource()
{
    public int Rating { get; set; }
    public string Comment { get; set; }
}
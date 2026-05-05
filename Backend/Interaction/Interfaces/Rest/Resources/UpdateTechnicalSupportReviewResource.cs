namespace Backend.Interaction.Interfaces.Rest.Resources;

public record UpdateTechnicalSupportReviewResource()
{
    public int Rating { get; set; }
    public string Comment { get; set; }
}
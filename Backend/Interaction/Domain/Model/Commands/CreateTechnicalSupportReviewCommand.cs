namespace Backend.Interaction.Domain.Model.Commands;

public record CreateTechnicalSupportReviewCommand(
    int Rating,
    string Comment,
    string UserName,
    int TechnicalSupportId
    )
{
}
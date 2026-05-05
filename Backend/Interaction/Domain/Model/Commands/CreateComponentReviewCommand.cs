namespace Backend.Interaction.Domain.Model.Commands;

public record CreateComponentReviewCommand(
    int ComponentId,
    string UserName,
    int Rating,
    string Comment
    );
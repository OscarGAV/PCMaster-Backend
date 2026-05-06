namespace Backend.Interaction.Domain.Model.Commands;
/// <summary>
/// Command to delete technical support review by unique ID
/// </summary>
/// <param name="Id"></param>
public record DeleteTechnicalSupportReviewCommand(int Id);
namespace Backend.Interaction.Domain.Model.Commands;
/// <summary>
/// Command to delete component review by unique Id
/// </summary>
/// <param name="Id"></param>
public record DeleteComponentReviewCommand(int Id);
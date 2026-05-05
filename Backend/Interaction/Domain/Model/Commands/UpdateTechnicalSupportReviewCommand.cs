namespace Backend.Interaction.Domain.Model.Commands;
/// <summary>
/// Command to update Technical Support Review
/// </summary>
/// <param name="Id"></param>
/// <param name="Rating"></param>
/// <param name="Comment"></param>
/// <param name="UserName"></param>
/// <param name="TechnicalSupportId"></param>
public record UpdateTechnicalSupportReviewCommand(
    int Id,
    int Rating, 
    string Comment
    //string UserName, 
    //int TechnicalSupportId
    );
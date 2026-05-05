namespace Backend.Interaction.Domain.Model.Commands;
/// <summary>
/// Command to update Component Review
/// </summary>
/// <param name="Id"></param>
/// <param name="Rating"></param>
/// <param name="Comment"></param>
/// <param name="UserName"></param>
/// <param name="ComponentId"></param>
public record UpdateComponentReviewCommand(
    int Id,
    int Rating, 
    string Comment
    //string UserName, 
    //int ComponentId
    );
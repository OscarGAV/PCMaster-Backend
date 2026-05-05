using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Aggregates;

public class TechnicalSupportReview
{
    public int Id { get; }
    public int Rating { get; private set; }
    public string Comment { get; private set; }
    public UserName UserName { get; private set; }
    public TechnicalSupportId TechnicalSupportId { get; private set; }
    
    public TechnicalSupportReview()
    {
        Rating = 0;
        Comment = "";
        UserName = new UserName();
        TechnicalSupportId = new TechnicalSupportId();
    }

    public TechnicalSupportReview(int rating, string comment, string userName, int technicalSupportId)
    {
        Rating = rating;
        Comment = comment;
        UserName = new UserName(userName);
        TechnicalSupportId = new TechnicalSupportId(technicalSupportId);
    }
    
    public TechnicalSupportReview(CreateTechnicalSupportReviewCommand command)
    {
        Rating = command.Rating;
        Comment = command.Comment;
        UserName = new UserName(command.UserName);
        TechnicalSupportId = new TechnicalSupportId(command.TechnicalSupportId);
    }

    public void Update(UpdateTechnicalSupportReviewCommand command)
    {
        Rating = command.Rating;
        Comment = command.Comment;
    }
}
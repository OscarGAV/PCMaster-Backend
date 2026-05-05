using System.ComponentModel.DataAnnotations;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Aggregates;

public class ComponentReview
{
    public int Id { get; }
    
    public int Rating { get; private set; }
    public string Comment { get; private set; }
    public UserName UserName { get; private set; }
    public ComponentId ComponentId { get; private set; }
    
    public ComponentReview()
    {
        Rating = 1;
        Comment = "";
        UserName = new UserName();
        ComponentId = new ComponentId();
    }
    

    public ComponentReview(int rating, string comment, string userName, int componentId)
    {
        Rating = rating;
        Comment = comment;
        UserName = new UserName(userName);
        ComponentId = new ComponentId(componentId);
    }

    public ComponentReview(CreateComponentReviewCommand command)
    {
        Rating = command.Rating;
        Comment = command.Comment;
        UserName = new UserName(command.UserName);
        ComponentId = new ComponentId(command.ComponentId);
    }

    public void Update(UpdateComponentReviewCommand command)
    {
        Rating = command.Rating;
        Comment = command.Comment;
    }
}
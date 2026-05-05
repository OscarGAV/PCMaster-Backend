using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;

namespace Backend.Interaction.Domain.Services;

public interface IComponentReviewCommandService
{
    Task<ComponentReview?> Handle(CreateComponentReviewCommand command);
    /// <summary>
    /// Handles the update of an existing Component Review request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> The updated instance. </returns>
    Task<ComponentReview> Handle(UpdateComponentReviewCommand command);
    
    /// <summary>
    /// Handles the deletion of a Component Review request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> True if the deletion was successful, otherwise false. </returns>
    Task<bool> Handle(DeleteComponentReviewCommand command);
}
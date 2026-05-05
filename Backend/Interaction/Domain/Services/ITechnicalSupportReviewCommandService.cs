using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;

namespace Backend.Interaction.Domain.Services;

public interface ITechnicalSupportReviewCommandService
{
    Task<TechnicalSupportReview?> Handle(CreateTechnicalSupportReviewCommand command);
    /// <summary>
    /// Handles the update of an existing Technical Support Review request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> The updated instance. </returns>
    Task<TechnicalSupportReview> Handle(UpdateTechnicalSupportReviewCommand command);
    
    /// <summary>
    /// Handles the deletion of a Technical Support Review request.
    /// </summary>
    /// <param name="command"></param>
    /// <returns> True if the deletion was successful, otherwise false. </returns>
    Task<bool> Handle(DeleteTechnicalSupportReviewCommand command);
}
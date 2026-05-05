using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Application.Internal.CommandServices;
/// <summary>
/// Initializes a new instance of the <see cref="ComponentReviewCommandService"/> class.
/// </summary>
/// <param name="componentReviewRepository">Repository for managing component reviews.</param>
/// <param name="unitOfWork"></param>
public class ComponentReviewCommandService(IComponentReviewRepository componentReviewRepository,
    IUnitOfWork unitOfWork)
    : IComponentReviewCommandService
{
    /// <summary>
    /// Handles the creation of a new component review.
    /// </summary>
    /// <param name="command">The command containing the necessary data to create the component review.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The result contains the created component review, 
    /// or <c>null</c> if it could not be created.
    /// </returns>
    public async Task<ComponentReview?> Handle(CreateComponentReviewCommand command)
    {
        // Validar el rango del Rating
        if (command.Rating < 1 || command.Rating > 5)
        {
            throw new ArgumentException("Rating must be between 1 and 5.", nameof(command.Rating));
        }
        var reviewComponent = new ComponentReview(command);
        await componentReviewRepository.AddAsync(reviewComponent);
        await unitOfWork.CompleteAsync();
        return reviewComponent;
    }

    public async Task<ComponentReview> Handle(UpdateComponentReviewCommand command)
    {
        var componentReview = await componentReviewRepository.FindByIdAsync(command.Id);

        if (componentReview == null)
        {
            throw new Exception($"ComponentReview with Id {command.Id} does not exist.");
        }
        
        if (command.Rating < 1 || command.Rating > 5)
        {
            throw new ArgumentException("Rating must be between 1 and 5.", nameof(command.Rating));
        }

        componentReview.Update(command);

        try
        {
            await componentReviewRepository.UpdateAsync(componentReview);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return componentReview;
    }

    public async Task<bool> Handle(DeleteComponentReviewCommand command)
    {
        var componentReview = await componentReviewRepository.FindByIdAsync(command.Id);
        if (componentReview == null)
        {
            return false;
        }

        await componentReviewRepository.DeleteAsync(componentReview);
        return true;
    }
}
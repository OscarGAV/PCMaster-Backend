using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Application.Internal.CommandServices;
/// <summary>
/// Initializes a new instance of the <see cref="TechnicalSupportReviewCommandService"/> class.
/// </summary>
/// <param name="technicalSupportRepository">Repository for managing technical support reviews.</param>
/// <param name="unitOfWork"></param>
public class TechnicalSupportReviewCommandService(ITechnicalSupportReviewRepository technicalSupportReviewRepository,
    IUnitOfWork unitOfWork)
    : ITechnicalSupportReviewCommandService
{
    /// <summary>
    /// Handles the creation of a new technical support review.
    /// </summary>
    /// <param name="command">The command containing the necessary data to create the technical support review.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The result contains the created technical support review, 
    /// or <c>null</c> if it could not be created.
    /// </returns>
    public async Task<TechnicalSupportReview?> Handle(CreateTechnicalSupportReviewCommand command)
    {
        // Validar el rango del Rating
        if (command.Rating < 1 || command.Rating > 5)
        {
            throw new ArgumentException("Rating must be between 1 and 5.", nameof(command.Rating));
        }
        var reviewTechnicalSupport = new TechnicalSupportReview(command);
        await technicalSupportReviewRepository.AddAsync(reviewTechnicalSupport);
        await unitOfWork.CompleteAsync();
        return reviewTechnicalSupport;
    }

    public async Task<TechnicalSupportReview> Handle(UpdateTechnicalSupportReviewCommand command)
    {
        var technicalSupportReview = await technicalSupportReviewRepository.FindByIdAsync(command.Id);

        if (technicalSupportReview == null)
        {
            throw new Exception($"TechnicalSupportReview with Id {command.Id} does not exist.");
        }
        
        // Validar el rango del Rating
        if (command.Rating < 1 || command.Rating > 5)
        {
            throw new ArgumentException("Rating must be between 1 and 5.", nameof(command.Rating));
        }

        technicalSupportReview.Update(command);

        try
        {
            await technicalSupportReviewRepository.UpdateAsync(technicalSupportReview);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return technicalSupportReview;
    }

    public async Task<bool> Handle(DeleteTechnicalSupportReviewCommand command)
    {
        var technicalSupportReview = await technicalSupportReviewRepository.FindByIdAsync(command.Id);
        if (technicalSupportReview == null)
        {
            return false;
        }

        await technicalSupportReviewRepository.DeleteAsync(technicalSupportReview);
        return true;
    }
}
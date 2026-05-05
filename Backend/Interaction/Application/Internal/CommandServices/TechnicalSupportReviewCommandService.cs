using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;

namespace Backend.Interaction.Application.Internal.CommandServices;

public class TechnicalSupportReviewCommandService(ITechnicalSupportReviewRepository technicalSupportReviewRepository,
    IUnitOfWork unitOfWork)
    : ITechnicalSupportReviewCommandService
{
    public async Task<TechnicalSupportReview?> Handle(CreateTechnicalSupportReviewCommand command)
    {
        if (command.Rating < 1 || command.Rating > 5)
            throw new ValidationException("Rating must be between 1 and 5");

        if (string.IsNullOrWhiteSpace(command.Comment))
            throw new ValidationException("Comment cannot be empty");

        if (command.Comment.Length > 150)
            throw new ValidationException("Comment must be at most 150 characters");

        if (string.IsNullOrWhiteSpace(command.UserName))
            throw new ValidationException("UserName cannot be empty");

        if (command.TechnicalSupportId <= 0)
            throw new ValidationException("TechnicalSupportId must be a positive number");

        var reviewTechnicalSupport = new TechnicalSupportReview(command);
        await technicalSupportReviewRepository.AddAsync(reviewTechnicalSupport);
        await unitOfWork.CompleteAsync();
        return reviewTechnicalSupport;
    }

    public async Task<TechnicalSupportReview> Handle(UpdateTechnicalSupportReviewCommand command)
    {
        var technicalSupportReview = await technicalSupportReviewRepository.FindByIdAsync(command.Id);

        if (technicalSupportReview == null)
            throw new NotFoundException($"TechnicalSupportReview with Id {command.Id} does not exist");

        if (command.Rating < 1 || command.Rating > 5)
            throw new ValidationException("Rating must be between 1 and 5");

        if (string.IsNullOrWhiteSpace(command.Comment))
            throw new ValidationException("Comment cannot be empty");

        if (command.Comment.Length > 150)
            throw new ValidationException("Comment must be at most 150 characters");

        technicalSupportReview.Update(command);

        try
        {
            await technicalSupportReviewRepository.UpdateAsync(technicalSupportReview);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the technical support review: {e.Message}");
        }

        return technicalSupportReview;
    }

    public async Task<bool> Handle(DeleteTechnicalSupportReviewCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        var technicalSupportReview = await technicalSupportReviewRepository.FindByIdAsync(command.Id);
        if (technicalSupportReview == null)
            return false;

        await technicalSupportReviewRepository.DeleteAsync(technicalSupportReview);
        return true;
    }
}
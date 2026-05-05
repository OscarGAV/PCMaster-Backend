using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Exceptions;

namespace Backend.Interaction.Application.Internal.CommandServices;

public class ComponentReviewCommandService(IComponentReviewRepository componentReviewRepository,
    IUnitOfWork unitOfWork)
    : IComponentReviewCommandService
{
    public async Task<ComponentReview?> Handle(CreateComponentReviewCommand command)
    {
        if (command.Rating < 1 || command.Rating > 5)
            throw new ValidationException("Rating must be between 1 and 5");

        if (string.IsNullOrWhiteSpace(command.Comment))
            throw new ValidationException("Comment cannot be empty");

        if (command.Comment.Length > 150)
            throw new ValidationException("Comment must be at most 150 characters");

        if (string.IsNullOrWhiteSpace(command.UserName))
            throw new ValidationException("UserName cannot be empty");

        if (command.ComponentId <= 0)
            throw new ValidationException("ComponentId must be a positive number");

        var reviewComponent = new ComponentReview(command);
        await componentReviewRepository.AddAsync(reviewComponent);
        await unitOfWork.CompleteAsync();
        return reviewComponent;
    }

    public async Task<ComponentReview> Handle(UpdateComponentReviewCommand command)
    {
        var componentReview = await componentReviewRepository.FindByIdAsync(command.Id);

        if (componentReview == null)
            throw new NotFoundException($"ComponentReview with Id {command.Id} does not exist");

        if (command.Rating < 1 || command.Rating > 5)
            throw new ValidationException("Rating must be between 1 and 5");

        if (string.IsNullOrWhiteSpace(command.Comment))
            throw new ValidationException("Comment cannot be empty");

        if (command.Comment.Length > 150)
            throw new ValidationException("Comment must be at most 150 characters");

        componentReview.Update(command);

        try
        {
            await componentReviewRepository.UpdateAsync(componentReview);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the component review: {e.Message}");
        }

        return componentReview;
    }

    public async Task<bool> Handle(DeleteComponentReviewCommand command)
    {
        if (command.Id <= 0)
            throw new ValidationException("Id must be a positive number");

        var componentReview = await componentReviewRepository.FindByIdAsync(command.Id);
        if (componentReview == null)
            return false;

        await componentReviewRepository.DeleteAsync(componentReview);
        return true;
    }
}
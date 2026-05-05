using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Queries;

public record GetAllComponentReviewsByComponentIdQuery(ComponentId ComponentId);
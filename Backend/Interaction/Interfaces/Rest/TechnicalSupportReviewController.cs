using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Model.ValueObjects;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Interfaces.Rest.Resources;
using Backend.Interaction.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Interaction.Interfaces.Rest;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Available Review Technical Support Endpoints")]
public class TechnicalSupportReviewController(ITechnicalSupportReviewCommandService technicalSupportReviewCommandService, 
    ITechnicalSupportReviewQueryService technicalSupportReviewQueryService) : ControllerBase
{
    [HttpGet("{technicalSupportId:int}")]
    [SwaggerOperation(
        Summary = "Get reviews by Technical Support ID",
        Description = "Get all reviews for a specific Technical Support ID",
        OperationId = "GetTechnicalSupportById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Reviews found", typeof(IEnumerable<TechnicalSupportReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No reviews found")]
    public async Task<IActionResult> GetAllReviewTechnicalSupportByIdQuery(int technicalSupportId)
    {
        var reviews = await technicalSupportReviewQueryService.Handle(new GetAllTechnicalSupportReviewsByTechnicalSupportIdQuery(new TechnicalSupportId(technicalSupportId)));
        var technicalSupportReviewsResources = reviews.Select(TechnicalSupportReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(technicalSupportReviewsResources);
    }
    
    /// <summary>
    /// Creates a new technical support review based on the provided resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new technical support review",
        Description = "Create a new technical support review",
        OperationId = "CreateReviewTechnicalSupport")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was created", typeof(TechnicalSupportReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review could not be created")]
    public async Task<IActionResult> CreateTechnicalSupportReview([FromBody] CreateTechnicalSupportReviewResource resource)
    {
        var createTechnicalSupportReviewCommand = CreateTechnicalSupportReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await technicalSupportReviewCommandService.Handle(createTechnicalSupportReviewCommand);
        if (review is null)
        {
            return BadRequest();
        }
        var technicalSupportReviewResource = TechnicalSupportReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(technicalSupportReviewResource);
    }
    
    /// <summary>
    /// Updates an existing technical support review record.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns> The updated technical support review resource, or a 404 Not Found if the record does not exist. </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTechnicalSupportReview(int id, [FromBody] UpdateTechnicalSupportReviewResource resource)
    {
        var command = UpdateTechnicalSupportReviewCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await technicalSupportReviewCommandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(TechnicalSupportReviewResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Deletes a technical support review record by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// A 204 No Content response if the deletion was successful,
    /// or a 404 Not Found if the record does not exist.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnicalSupportReview(int id)
    {
        var command = new DeleteTechnicalSupportReviewCommand(id);
        var result = await technicalSupportReviewCommandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}
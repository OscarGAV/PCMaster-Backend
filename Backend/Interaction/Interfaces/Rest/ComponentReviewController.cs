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
[SwaggerTag("Available Review Component Endpoints")]

public class ComponentReviewController(IComponentReviewCommandService componentReviewCommandService, 
    IComponentReviewQueryService componentReviewQueryService) : ControllerBase
{
    [HttpGet("{componentId:int}")]
    [SwaggerOperation(
        Summary = "Get a review by Component id",
        Description = "Get all reviews for a specific Component Id",
        OperationId = "GetComponentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Reviews found", typeof(IEnumerable<ComponentReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No reviews found")]
    public async Task<IActionResult> GetAllReviewComponentByComponentIdQuery(int componentId)
    {
        var reviews = await componentReviewQueryService.Handle(new GetAllComponentReviewsByComponentIdQuery(new ComponentId(componentId)));
        var componentReviewsResources = reviews.Select(ComponentReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(componentReviewsResources);
    }
    
    /// <summary>
    /// Creates a new component review based on the provided resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new component review",
        Description = "Create a new component review",
        OperationId = "CreateReviewComponent")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was created", typeof(ComponentReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review could not be created")]
    public async Task<IActionResult> CreateComponentReview([FromBody] CreateComponentReviewResource resource)
    {
        var createComponentReviewCommand = CreateComponentReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await componentReviewCommandService.Handle(createComponentReviewCommand);
        if (review is null)
        {
            return BadRequest();
        }
        var componentReviewResource = ComponentReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(componentReviewResource);
    }
    
    /// <summary>
    /// Updates an existing component review record.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns> The updated component review resource, or a 404 Not Found if the record does not exist. </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComponentReview(int id, [FromBody] UpdateComponentReviewResource resource)
    {
        var command = UpdateComponentReviewCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await componentReviewCommandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(ComponentReviewResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Deletes a component review record by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// A 204 No Content response if the deletion was successful,
    /// or a 404 Not Found if the record does not exist.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComponentReview(int id)
    {
        var command = new DeleteComponentReviewCommand(id);
        var result = await componentReviewCommandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}
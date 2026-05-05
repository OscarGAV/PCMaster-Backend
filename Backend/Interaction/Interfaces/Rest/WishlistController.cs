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
[SwaggerTag("Available Wishlist Endpoints")]
public class WishlistController(IWishlistCommandService wishlistCommandService, 
    IWishlistQueryService wishlistQueryService) : ControllerBase
{
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Get wishlist by user ID",
        Description = "Get wishlist for a specific User ID",
        OperationId = "GetWishlistByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Wishlist found", typeof(IEnumerable<WishlistResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No wishlist found")]
    public async Task<IActionResult> GetWishlistByUserIdQuery(int userId)
    {
        var wishlist = await wishlistQueryService.Handle(new GetWishlistByUserId(new UserId(userId)));
        var wishlistResources = wishlist.Select(WishlistResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(wishlistResources);
    }
    
    [HttpPost()]
    [SwaggerOperation(
        Summary = "Create a new wishlist",
        Description = "Create a new wishlist",
        OperationId = "CreateWishlist")]
    [SwaggerResponse(StatusCodes.Status200OK, "The wishlist was created", typeof(WishlistResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wishlist could not be created")]
    public async Task<IActionResult> CreateWishlist([FromBody] CreateWishlistResource resource)
    {
        var createWishlistCommand = CreateWishlistCommandFromResourceAssembler.ToCommandFromResource(resource);
        var wishlist = await wishlistCommandService.Handle(createWishlistCommand);
        if (wishlist is null)
        {
            return BadRequest();
        }
        var wishlistResource = WishlistResourceFromEntityAssembler.ToResourceFromEntity(wishlist);
        return Ok(wishlistResource);
    }
    
    /// <summary>
    /// Updates an existing wishlist record.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns> The updated wishlist resource, or a 404 Not Found if the record does not exist. </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWishlist(int id, [FromBody] UpdateWishlistResource resource)
    {
        var command = UpdateWishlistCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await wishlistCommandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(WishlistResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Deletes a wishlist record by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// A 204 No Content response if the deletion was successful,
    /// or a 404 Not Found if the record does not exist.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWishlist(int id)
    {
        var command = new DeleteWishlistCommand(id);
        var result = await wishlistCommandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}
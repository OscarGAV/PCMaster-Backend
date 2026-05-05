using System.Net.Mime;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Commands;
using Backend.Orders.Domain.Model.Queries;
using Backend.Orders.Domain.Services;
using Backend.Orders.Interfaces.REST.Resource;
using Backend.Orders.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Orders.Interfaces.REST;

[ApiController]
[Authorize]
[Route("/api/v1/cart")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Cart")]
public class CartController(
    ICartCommandService cartCommandService,
    ICartQueryService cartQueryService) : ControllerBase
{
    /// <summary>
    /// Create a new cart
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a cart",
        Description = "Create a cart source",
        OperationId = "CreateCart")]
    [SwaggerResponse(201, "Cart was created", typeof(CreateCartResource))]
    [SwaggerResponse(400, "Cart was not created")]
    public async Task<ActionResult> CreateCart([FromBody] CreateCartResource resource)
    {
        var command = CreateCartCommandFromResourceAssembler.toCommandFromResource(resource);
        var result = await cartCommandService.Handle(command);
        if (result is null) return BadRequest();
        
        //return CreatedAtAction(nameof())
        return Ok(command);
    }

    /// <summary>
    /// Get all carts
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get carts",
        Description = "Get all carts",
        OperationId = "GetCarts")]
    [SwaggerResponse(StatusCodes.Status200OK, "Carts", typeof(IEnumerable<CartResource>))]
    public async Task<IActionResult> GetCarts()
    {
        var getAllCarts = new GetCartsQuery();
        var carts = await cartQueryService.Handle(getAllCarts);
        var cartResources = carts.Select(CartResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(cartResources);
    }
    
    /// <summary>
    /// Get Cart by User id
    /// </summary>
    /// <returns></returns>
    [HttpGet("user/{userId}")]
    [SwaggerOperation(
        Summary = "Get carts by user",
        Description = "Get carts by user id",
        OperationId = "GetCartsByUser")]
    [SwaggerResponse(StatusCodes.Status200OK, "Carts", typeof(IEnumerable<CartResource>))]
    public async Task<IActionResult> GetCartsByUserId([FromRoute] int userId)
    {
        var getCartsByUserIdQuery = new GetCartsByUserId(userId);
        var carts = await cartQueryService.Handle(getCartsByUserIdQuery);
        var cartResource = carts.Select(CartResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(cartResource);
    }

    /// <summary>
    /// Delete a cart
    /// </summary>
    /// <returns> Void </returns>
    [HttpDelete("{cartId}")]
    [SwaggerOperation(
        Summary = "Delete a cart",
        Description = "Delete a cart by id",
        OperationId = "DeleteCart")]
    [SwaggerResponse(StatusCodes.Status200OK, "Cart Delete")]
    public async Task<IActionResult> DeleteCart([FromRoute] int cartId)
    {
        var commandDelete = new DeleteCartCommand(cartId);
        var result = await cartCommandService.Handle(commandDelete);
        
        if(!result) return BadRequest();

        return Ok();
    }
}
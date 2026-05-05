using System.Net.Mime;
using Backend.Component.Domain.Model.Queries;
using Backend.Component.Domain.Services;
using Backend.Component.Interfaces.REST.Resources;
using Backend.Component.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Component.Interfaces.REST;

[ApiController]
[Authorize] //Esto es el locker del IAM
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)] 
[Tags("Component")]
public class ComponentController(
    IComponentCommandService componentCommandService,
    IComponentQueryService componentQueryService)
    : ControllerBase
{
    private readonly IComponentCommandService _componentCommandService = componentCommandService;
    private readonly IComponentQueryService _componentQueryService = componentQueryService;

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new component",
        Description = "Create a new component",
        OperationId = "CreateComponent")]
    [SwaggerResponse(StatusCodes.Status201Created, "The component was created", typeof(ComponentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The component could not be created")]
    public async Task<IActionResult> CreateComponent([FromBody] CreateComponentResource resource)
    {
        var createComponentCommand = CreateComponentCommandFromResourceAssembler.ToCommand(resource);
        var component = await componentCommandService.Handle(createComponentCommand);
        if (component is null)
        {
            return BadRequest("No se pudo crear el componente. Verifique los datos proporcionados.");
        }
        var componentResource = ComponentResourceFromEntityAssembler.ToResource(component);
        return CreatedAtAction(nameof(CreateComponent), new { id = component.Id }, componentResource);
    }
    [HttpGet("{componentId:int}")]
    [SwaggerOperation(
        Summary = "Get a component by its ID",
        Description = "Get a component by its ID",
        OperationId = "GetComponentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The component was found", typeof(ComponentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No component found")]
    public async Task<IActionResult> GetComponentById(int componentId)
    {
        var query = new GetComponentByIdQuery(componentId);
        var component = await _componentQueryService.Handle(query);
        if (component is null)
        {
            return NotFound();
        }
        var resource = ComponentResourceFromEntityAssembler.ToResource(component);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all components",
        Description = "Get all components",
        OperationId = "GetComponents")]
    [SwaggerResponse(StatusCodes.Status200OK, "Components", typeof(IEnumerable<ComponentResource>))]
    public async Task<IActionResult> GetAllComponents()
    {
        var components = await _componentQueryService.Handle(new GetAllComponentsQuery());
        var resources = components.Select(ComponentResourceFromEntityAssembler.ToResource).ToList();  // Asegúrate de llamar a ToList() para materializar el enumerable
        return Ok(resources);
    }
}

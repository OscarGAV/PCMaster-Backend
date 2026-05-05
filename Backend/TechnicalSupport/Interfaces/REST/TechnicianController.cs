using System.Net.Mime;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Backend.TechnicalSupport.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.TechnicalSupport.Interfaces.REST;

[ApiController]
[Authorize]
[Route("/api/v1/technicians")]
[Produces(MediaTypeNames.Application.Json)]
[Tags ("Technicians")]
public class TechnicianController(ITechnicianCommandService commandService, 
    ITechnicianQueryService queryService) : ControllerBase
{
    /// <summary>
    /// Creates a new technician based on the provided resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateTechnicians([FromBody] CreateTechnicianResource resource)
    {
        var command = CreateTechnicianCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetTechnicianById), new { id = result.Id},
        TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Gets the top-ranked technicians with the greatest stars number, limited by the specified TopRanking value.
    /// </summary>
    /// <returns>A list of top-ranked technicians based on stars.</returns>
    [HttpGet("top-ranked")]
    public async Task<ActionResult> GetTopRankedTechnicians()
    {
        var query = new GetAllTechnicianByGreatestStarsNumberQuery(); // Uses default values
        var result = await queryService.Handle(query);

        if (result == null || !result.Any())
            return NotFound("No technicians found with the specified criteria.");

        // Transform the result to TechnicianResource with the rounded Stars value
        var resources = result.Select(TechnicianResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    /// <summary>
    /// Retrieves all technicians
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all technicians",
        Description = "Get all technicians",
        OperationId = "GetAllTechnician")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of technicians were found", typeof(IEnumerable<TechnicianResource>))]
    public async Task<IActionResult> GetAllTechnician()
    {
        var technicians = await queryService.Handle(new GetAllTechnicianQuery());
        var technicianResources = technicians.Select(TechnicianResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(technicianResources);
    }
    
    /// <summary>
    /// Gets a technician by their identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTechnicianById(int id)
    {
        var getTechnicianById = new GetTechnicianByIdQuery(id);
        var result = await queryService.Handle(getTechnicianById);
        if (result is null) return NotFound();
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    /// <summary>
    /// Updates an existing technician's information.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTechnicianSupport(int id, [FromBody] UpdateTechnicianResource resource)
    {
        var command = UpdateTechnicianCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Deletes a technician by their identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnicianSupport(int id)
    {
        var command = new DeleteTechnicianCommand(id);
        var result = await commandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}
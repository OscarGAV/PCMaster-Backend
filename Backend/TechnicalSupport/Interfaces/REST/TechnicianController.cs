using System.Net.Mime;
using Backend.IAM.Domain.Model.ValueObjects;
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
    [Authorize(AllowedRoles = [ERole.ROLE_ADMIN])]
    public async Task<IActionResult> CreateTechnicians([FromBody] CreateTechnicianResource resource)
    {
        var command = CreateTechnicianCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetTechnicianById), new { id = result.Technician.Id},
        new { 
            technician = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result.Technician),
            username = result.Username,
            password = result.Password
        });
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

        var technicians = result.ToList();
        if (technicians.Count == 0)
            return NotFound("No technicians found with the specified criteria.");

        // Transform the result to TechnicianResource with the average rating
        var resources = new List<TechnicianResource>();
        foreach (var tech in technicians)
        {
            var avgRating = await queryService.GetAverageRatingByTechnicianNameAsync(tech.Name);
            resources.Add(TechnicianResourceFromEntityAssembler.ToResourceFromEntity(tech, avgRating));
        }
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
        var resources = new List<TechnicianResource>();
        foreach (var tech in technicians)
        {
            var avgRating = await queryService.GetAverageRatingByTechnicianNameAsync(tech.Name);
            resources.Add(TechnicianResourceFromEntityAssembler.ToResourceFromEntity(tech, avgRating));
        }
        return Ok(resources);
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
        var avgRating = await queryService.GetAverageRatingByTechnicianNameAsync(result.Name);
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result, avgRating);
        return Ok(resources);
    }
    
    /// <summary>
    /// Updates an existing technician's information.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(AllowedRoles = [ERole.ROLE_ADMIN])]
    public async Task<IActionResult> UpdateTechnicianSupport(int id, [FromBody] UpdateTechnicianResource resource)
    {
        var command = UpdateTechnicianCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);

        return Ok(TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Deletes a technician by their identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(AllowedRoles = [ERole.ROLE_ADMIN])]
    public async Task<IActionResult> DeleteTechnicianSupport(int id)
    {
        var command = new DeleteTechnicianCommand(id);
        var result = await commandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}
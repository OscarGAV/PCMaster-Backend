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
[Route("/api/v1/technical-support")]
[Produces(MediaTypeNames.Application.Json)]
[Tags ("Technical support services by Technicians")]
public class TechnicalSupportController(ITechnicalSupportCommandService commandService, 
    ITechnicalSupportQueryService queryService) : ControllerBase
{
    /// <summary>
    /// Creates a new technical support record.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns>
    /// A 201 Created response with the created technical support resource,
    /// or a 400 Bad Request if creation fails.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> GetTechnicalSupports([FromBody] CreateTechnicalSupportResource resource)
    {
        var command = CreateTechnicalSupportCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetTechnicalSupportById), new { id = result.Id},
        TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Retrieves all technical support records filtered by support type.
    /// </summary>
    /// <param name="supportType"></param>
    /// <returns> A collection of technical support resources. </returns>
    private async Task<ActionResult> GetAllTechnicalSupportBySupportType(bool supportType)
    {
        var getAllTechnicalSupportBySupportType =
            new GetTechnicalSupportBySupportTypeQuery(supportType);
        var result = await queryService.Handle(getAllTechnicalSupportBySupportType);
        var resources = result.Select(TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    /// <summary>
    /// Retrieves a specific technical support record by support type and technician ID.
    /// </summary>
    /// <param name="supportType"></param>
    /// <param name="technicianId"></param>
    /// <returns> The technical support resource if found, or a 404 Not Found if not. </returns>
    private async Task<ActionResult> GetTechnicalSupportBySupportTypeAndTechniciansId(bool supportType, string technicianId)
    {
        var getTechnicalSupportBySupportTypeAndTechniciansId = new GetTechnicalSupportBySupportTypeAndTechnicianIdQuery(supportType, technicianId);
        var result = await queryService.Handle(getTechnicalSupportBySupportTypeAndTechniciansId);
        if (result is null) return NotFound();
        var resources = TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    /// <summary>
    /// Retrieves all technical supports
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all technical support",
        Description = "Get all technical support",
        OperationId = "GetAllTechnicalSupport")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of technical supports were found", typeof(IEnumerable<TechnicalSupportResource>))]
    public async Task<IActionResult> GetAllTechnicalSupport()
    {
        var technicalSupports = await queryService.Handle(new GetAllTechnicalSupportQuery());
        var technicalSupportResources = technicalSupports.Select(TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(technicalSupportResources);
    }

    /// <summary>
    /// Retrieves technical support records based on query parameters.
    /// </summary>
    /// <param name="supportType"></param>
    /// <param name="technicianId"></param>
    /// <returns> A collection of technical support resources. </returns>
    [HttpGet("{supportType}")]
    public async Task<ActionResult> GetTechnicalSupportFromQuery(bool supportType, [FromQuery] string technicianId = "")
    {
        return string.IsNullOrEmpty(technicianId) 
            ? await GetAllTechnicalSupportBySupportType(supportType)
            : await GetTechnicalSupportBySupportTypeAndTechniciansId(supportType, technicianId);
    }
    
    /// <summary>
    /// Retrieves a specific technical support record by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> The technical support resource if found, or a 404 Not Found if not. </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTechnicalSupportById(int id)
    {
        var getTechnicalSupportById = new GetTechnicalSupportByIdQuery(id);
        var result = await queryService.Handle(getTechnicalSupportById);
        if (result is null) return NotFound();
        var resources = TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    /// <summary>
    /// Updates an existing technical support record.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns> The updated technical support resource, or a 404 Not Found if the record does not exist. </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTechnicalSupport(int id, [FromBody] UpdateTechnicalSupportResource resource)
    {
        var command = UpdateTechnicalSupportCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Deletes a technical support record by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// A 204 No Content response if the deletion was successful,
    /// or a 404 Not Found if the record does not exist.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnicalSupport(int id)
    {
        var command = new DeleteTechnicalSupportCommand(id);
        var result = await commandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}
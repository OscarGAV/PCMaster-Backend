using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.QueryServices;

/// <summary>
/// Service to handle query operations for the TechnicalSupport entity. This service provides methods 
/// to retrieve TechnicalSupport instances by various criteria, including ESupportType, TechnicianId, and Id (the TechnicalSupport entity identifier).
/// </summary>
/// <param name="technicalSupportRepository"> The repository interface for accessing TechnicalSupport data. </param>
public class TechnicalSupportQueryService(ITechnicalSupportRepository technicalSupportRepository) : ITechnicalSupportQueryService
{
    /// <summary>
    /// Retrieves all TechnicalSupport entities
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TechnicalSupport>> Handle(GetAllTechnicalSupportQuery query)
    {
        return await technicalSupportRepository.ListAsync();
    }
    
    /// <summary>
    /// Retrieves all TechnicalSupport entities associated with a specified Support Type.
    /// </summary>
    /// <param name="query"> The query containing the Support Type. </param>
    /// <returns> An enumerable collection of TechnicalSupport entities associated with the provided Support Type. </returns>
    public async Task<IEnumerable<TechnicalSupport>> Handle(GetTechnicalSupportBySupportTypeQuery query)
    {
        return await technicalSupportRepository.FindBySupportTypeAsync(query.SupportType);
    }

    /// <summary>
    /// Retrieves a single TechnicalSupport entity by a specified Support Type and Technician ID.
    /// </summary>
    /// <param name="query"> The query containing the Support Type and Technician ID. </param>
    /// <returns> The TechnicalSupport entity associated with the specified Support Type and Technician ID, if found; otherwise, null. </returns>
    public async Task<TechnicalSupport> Handle(GetTechnicalSupportBySupportTypeAndTechnicianIdQuery query)
    {
        return await technicalSupportRepository.FindBySupportTypeAndTechnicianIdAsync(query.SupportType, query.TechnicianId);
    }

    /// <summary>
    /// Retrieves a TechnicalSupport entity by its unique identifier.
    /// </summary>
    /// <param name="query"> The query containing the unique identifier of the TechnicalSupport entity. </param>
    /// <returns> The TechnicalSupport entity with the specified ID, if found; otherwise, null. </returns>
    public async Task<TechnicalSupport> Handle(GetTechnicalSupportByIdQuery query)
    {
        return await technicalSupportRepository.FindByIdAsync(query.Id);
    }
}
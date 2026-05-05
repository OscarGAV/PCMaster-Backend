using Backend.TechnicalSupport;
using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.QueryServices;

public class TechnicianQueryService(ITechnicianRepository technicianRepository) : ITechnicianQueryService
{
    /// <summary>
    /// Retrieves all Technicians
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Technician>> Handle(GetAllTechnicianQuery query)
    {
        return await technicianRepository.ListAsync();
    }
    
    /// <summary>
    /// Retrieves a Technician entity by its unique identifier.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> The Technician entity with the specified ID, if found; otherwise, null. </returns>
    public async Task<Technician> Handle(GetTechnicianByIdQuery query)
    {
        return await technicianRepository.FindByIdAsync(query.Id);
    }
    
    /// <summary>
    /// Retrieves the top-ranked Technicians with the highest stars, up to the specified TopRanking.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> A list of top-ranked Technicians with the greatest number of stars. </returns>
    public async Task<IEnumerable<Technician>> Handle(GetAllTechnicianByGreatestStarsNumberQuery query)
    {
        // Fetch all technicians and filter, sort, and limit based on the query criteria
        var technicians = await technicianRepository.ListAsync();

        var topTechnicians = technicians
            .Where(t => t.Stars >= query.Stars)
            .OrderByDescending(t => t.Stars)
            .ThenBy(t => t.Name)
            .Take(query.TopRanking)
            .ToList();

        return topTechnicians;
    }
}
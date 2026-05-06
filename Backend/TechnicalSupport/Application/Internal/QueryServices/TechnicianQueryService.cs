using Backend.TechnicalSupport;
using Backend.TechnicalSupport.Domain.Model.Aggregates;
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
    /// Retrieves the top-ranked Technicians with the highest ratings, up to the specified TopRanking.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> A list of top-ranked Technicians with the greatest average rating. </returns>
    public async Task<IEnumerable<Technician>> Handle(GetAllTechnicianByGreatestStarsNumberQuery query)
    {
        // Fetch all technicians and calculate their average ratings
        var technicians = await technicianRepository.ListAsync();
        var techniciansWithRatings = new List<(Technician Technician, double Rating)>();

        foreach (var tech in technicians)
        {
            var avgRating = await technicianRepository.GetAverageRatingByTechnicianNameAsync(tech.Name);
            if (avgRating.HasValue)
            {
                techniciansWithRatings.Add((tech, avgRating.Value));
            }
        }

        // Sort by rating descending, then by name, and take the top N
        var topTechnicians = techniciansWithRatings
            .OrderByDescending(t => t.Rating)
            .ThenBy(t => t.Technician.Name)
            .Take(query.TopRanking)
            .Select(t => t.Technician)
            .ToList();

        return topTechnicians;
    }
    
    /// <summary>
    /// Gets the average rating for a technician by their name.
    /// </summary>
    /// <param name="technicianName"></param>
    /// <returns></returns>
    public async Task<double?> GetAverageRatingByTechnicianNameAsync(string technicianName)
    {
        return await technicianRepository.GetAverageRatingByTechnicianNameAsync(technicianName);
    }
}

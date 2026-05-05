using Backend.TechnicalSupport.Domain.Model.Queries;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicianQueryService
{
    /// <summary>
    /// Retrieves all Technical Support
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<Technician>> Handle(GetAllTechnicianQuery query);
    
    /// <summary>
    /// Retrieves a Technician record by its unique identifier.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Technician> Handle(GetTechnicianByIdQuery query);
    
    /// <summary>
    /// Retrieves all Technicians with the greatest stars rating, limited by TopRanking.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<Technician>> Handle(GetAllTechnicianByGreatestStarsNumberQuery query);
}
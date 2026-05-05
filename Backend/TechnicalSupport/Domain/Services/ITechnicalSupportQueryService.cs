using Backend.TechnicalSupport.Domain.Model.Queries;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicalSupportQueryService
{
    /// <summary>
    /// Retrieves all Technical Support
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<TechnicalSupport>> Handle(GetAllTechnicalSupportQuery query);
    
    /// <summary>
    /// Retrieves all Technical Support records that match a specified support type.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<TechnicalSupport>> Handle(GetTechnicalSupportBySupportTypeQuery query);
    
    /// <summary>
    /// Retrieves a specific Technical Support record based on support type and technician ID.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<TechnicalSupport> Handle(GetTechnicalSupportBySupportTypeAndTechnicianIdQuery query);
    
    /// <summary>
    /// Retrieves a specific Technical Support record by its unique identifier.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<TechnicalSupport> Handle(GetTechnicalSupportByIdQuery query);
}
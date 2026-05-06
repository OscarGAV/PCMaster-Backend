namespace Backend.TechnicalSupport.Domain.Model.Queries;

public record GetAllTechnicianByGreatestStarsNumberQuery
{
    public int TopRanking { get; set; } = 4;   // Default to top 4 technicians
}

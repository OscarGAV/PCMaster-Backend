namespace Backend.TechnicalSupport.Domain.Model.Queries;

public record GetAllTechnicianByGreatestStarsNumberQuery
{
    public double Stars { get; set; } = 0.0;        // Default to 0 stars
    public int TopRanking { get; set; } = 4;   // Default to top 4 technicians
}
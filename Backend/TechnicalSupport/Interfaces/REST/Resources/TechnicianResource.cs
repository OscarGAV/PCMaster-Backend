namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record TechnicianResource(int Id, string Name, bool Status, double? AverageRating, string Img);
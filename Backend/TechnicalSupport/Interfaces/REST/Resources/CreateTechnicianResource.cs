namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record CreateTechnicianResource(string Name, bool Status, double Stars, string Img);
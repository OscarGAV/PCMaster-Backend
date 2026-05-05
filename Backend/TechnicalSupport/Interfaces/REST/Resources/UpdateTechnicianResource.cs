namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record UpdateTechnicianResource()
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public double Stars { get; set; }
    public string Img { get; set; }
}
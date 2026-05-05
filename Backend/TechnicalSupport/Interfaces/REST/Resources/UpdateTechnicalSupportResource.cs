namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record UpdateTechnicalSupportResource()
{
    public string TechnicianId { get; set; }
    public bool SupportType { get; set; }
    public DateTime DateOfRequest { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
namespace PCMasterFrontend.Models.TechnicalSupport;

public class TechnicalSupportDto
{
    public int Id { get; set; }
    public string TechnicianId { get; set; } = string.Empty;
    public bool SupportType { get; set; }
    public DateTime DateOfRequest { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class CreateTechnicalSupportRequest
{
    public string TechnicianId { get; set; } = string.Empty;
    public bool SupportType { get; set; }
    public DateTime DateOfRequest { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class UpdateTechnicalSupportRequest
{
    public string TechnicianId { get; set; } = string.Empty;
    public bool SupportType { get; set; }
    public DateTime DateOfRequest { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

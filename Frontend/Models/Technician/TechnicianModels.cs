namespace PCMasterFrontend.Models.Technician;

public class TechnicianDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    public double Stars { get; set; }
    public string Img { get; set; } = string.Empty;
}

public class CreateTechnicianRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    public double Stars { get; set; }
    public string Img { get; set; } = string.Empty;
}

public class UpdateTechnicianRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    public double Stars { get; set; }
    public string Img { get; set; } = string.Empty;
}

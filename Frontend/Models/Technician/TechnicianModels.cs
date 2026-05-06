namespace PCMasterFrontend.Models.Technician;

public class TechnicianDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    public double? AverageRating { get; set; }
    public string Img { get; set; } = string.Empty;
}

public class CreateTechnicianRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string Img { get; set; } = string.Empty;
}

public class CreateTechnicianResponse
{
    public TechnicianDto Technician { get; set; } = new();
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UpdateTechnicianRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string Img { get; set; } = string.Empty;
}

namespace PCMasterFrontend.Models.TechnicalSupportReview;

public class TechnicalSupportReviewDto
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int TechnicalSupportId { get; set; }
}

public class CreateTechnicalSupportReviewRequest
{
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int TechnicalSupportId { get; set; }
}

public class UpdateTechnicalSupportReviewRequest
{
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}

namespace PCMasterFrontend.Models.ComponentReview;

public class ComponentReviewDto
{
    public int Id { get; set; }
    public int ComponentId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}

public class CreateComponentReviewRequest
{
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int ComponentId { get; set; }
}

public class UpdateComponentReviewRequest
{
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}

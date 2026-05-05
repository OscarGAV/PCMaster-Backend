namespace PCMasterFrontend.Models.Component;

public class ComponentDto
{
    public int ComponentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    public int ProviderId { get; set; }
    public string Image { get; set; } = string.Empty;
    public int Ratings { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string CategoryType { get; set; } = string.Empty;
    public string CategorySubType { get; set; } = string.Empty;
    public string CategoryBrand { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}

public class CreateComponentRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    public int ProviderId { get; set; }
    public string Image { get; set; } = string.Empty;
    public int Ratings { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string CategoryType { get; set; } = string.Empty;
    public string CategorySubType { get; set; } = string.Empty;
    public string CategoryBrand { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}

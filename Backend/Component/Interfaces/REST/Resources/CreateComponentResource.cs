namespace Backend.Component.Interfaces.REST.Resources
{
    public record CreateComponentResource(
        string Name,
        string? Description,
        float Price,
        int Stock,
        int ProviderId,
        string Image,
        int Ratings,
        string Model,
        string Color,
        string Dimensions,
        string Material,
        string Weight,
        string CategoryType,
        string CategorySubType,
        string CategoryBrand,
        string Country
    );
}
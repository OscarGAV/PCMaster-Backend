namespace Backend.Component.Interfaces.REST.Resources
{
    public record ComponentResource(
        int ComponentId,
        string Name,
        string Description,
        float Price,
        int Stock,
        string Image,
        double? AverageRating,
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

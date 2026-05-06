namespace Backend.Component.Domain.Model.Commands;

public record CreateComponentCommand(
    string Name,
    string Description,
    float Price,
    int Stock,
    string Image,
    string Model,
    string Color,
    string Dimensions,
    string Material,
    string Weight,
    string CategoryType,
    string CategorySubType,
    string CategoryBrand,
    string Country
)
{
    public int Id { get; }
}

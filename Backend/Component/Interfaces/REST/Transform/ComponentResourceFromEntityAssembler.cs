using Backend.Component.Domain.Model.ValueObjects;
using Backend.Component.Interfaces.REST.Resources;

namespace Backend.Component.Interfaces.REST.Transform;

public static class ComponentResourceFromEntityAssembler
{
    public static ComponentResource ToResource(Domain.Model.Aggregates.Component component, double? averageRating = null)
    {
        return new ComponentResource(
            component.Id,
            component.Name,
            component.Description,
            component.Price,
            component.Stock,
            component.Image,
            averageRating,
            component.Model,
            component.Color,
            component.Dimensions,
            component.Material,
            component.Weight,
            component.CategoryType,
            component.CategorySubType,
            component.CategoryBrand,
            component.Country
        );
    }
}

using System.Text.Json.Serialization;

namespace Backend.Component.Interfaces.REST.Resources;

[method: JsonConstructor]
public record CategoriesResource(List<string> CategoriesList)
{
    // Constructor with no parameters for deserialization
    public CategoriesResource() : this([]) { }
}
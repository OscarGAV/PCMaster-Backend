using System.Text.Json.Serialization;

namespace Backend.Component.Interfaces.REST.Resources;

public record CategoriesResource
{
    public List<string> CategoriesList { get; init; }

    // Constructor sin parámetros para la deserialización
    public CategoriesResource() 
    {
        CategoriesList = new List<string>();
    }

    // O bien, si tienes un constructor parametrizado
    [JsonConstructor]
    public CategoriesResource(List<string> categoriesList)
    {
        CategoriesList = categoriesList;
    }
}
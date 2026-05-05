using System.Text.Json.Serialization;

namespace Backend.Component.Interfaces.REST.Resources;

public record AttributesResource
{
    public Dictionary<string, string> AttributeList { get; init; }

    // Constructor sin parámetros para la deserialización
    public AttributesResource() 
    {
        AttributeList = new Dictionary<string, string>();
    }

    // O bien, si tienes un constructor parametrizado
    [JsonConstructor]
    public AttributesResource(Dictionary<string, string> attributeList)
    {
        AttributeList = attributeList;
    }
}
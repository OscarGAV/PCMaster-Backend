using System.Text.Json.Serialization;

namespace Backend.Component.Interfaces.REST.Resources;

[method: JsonConstructor]
public record AttributesResource(Dictionary<string, string> AttributeList)
{
    // Constructor with no parameters for deserialization
    public AttributesResource() : this(new Dictionary<string, string>()) { }
}
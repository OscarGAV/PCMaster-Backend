namespace Backend.Component.Domain.Model.ValueObjects;

public record Attributes(Dictionary<string, string> AttributeList)
{
  public Attributes() : this(new Dictionary<string, string>()) { }
}

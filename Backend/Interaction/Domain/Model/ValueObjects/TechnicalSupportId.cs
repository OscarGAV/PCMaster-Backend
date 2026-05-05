namespace Backend.Interaction.Domain.Model.ValueObjects;

public record TechnicalSupportId(int TechSupportId)
{
    public TechnicalSupportId() : this(0) { }
}
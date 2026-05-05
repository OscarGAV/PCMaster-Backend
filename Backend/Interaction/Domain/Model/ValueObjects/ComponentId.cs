namespace Backend.Interaction.Domain.Model.ValueObjects;

public record ComponentId(int CompId)
{
    public ComponentId() : this(0) { }
}
namespace Backend.Interaction.Domain.Model.ValueObjects;

public record ComponentName(string Name)
{
    public ComponentName() : this(string.Empty) { }
}
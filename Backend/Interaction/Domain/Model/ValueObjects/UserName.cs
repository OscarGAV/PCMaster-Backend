namespace Backend.Interaction.Domain.Model.ValueObjects;

public record UserName(string Name)
{
    public UserName() : this(string.Empty) { }
}
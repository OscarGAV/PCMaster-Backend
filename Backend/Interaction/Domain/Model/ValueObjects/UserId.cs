namespace Backend.Interaction.Domain.Model.ValueObjects;

public record UserId(int UsrId)
{
    public UserId() : this(0) { }
}
namespace Backend.Component.Domain.Model.ValueObjects;

public record Categories(List<string> CategoriesList)
{
    public Categories() : this(new List<string>()) { }
}
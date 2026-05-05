namespace Backend.TechnicalSupport.Domain.Model.ValueObjects;

public record Img(string Main, List<string> Secondary) {
    public Img() : this(string.Empty, new List<string>()) { }
}
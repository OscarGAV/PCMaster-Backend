using Backend.Component.Domain.Model.Commands;

namespace Backend.Component.Domain.Model.Aggregates;

public class Component
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float Price { get; private set; }
    public int Stock { get; private set; }
    public string Image {get; private set;}
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string Dimensions { get; private set; }
    public string Material { get; private set; }
    public string Weight { get; private set; }

    // Properties for category information
    public string CategoryType { get; private set; }
    public string CategorySubType { get; private set; }
    public string CategoryBrand { get; private set; }
    public string Country { get; init; }

    public Component(string name, string description, float price, int stock, string image,
        string model, string color, string dimensions, 
        string material, string weight, string categoryType, string categorySubType, string categoryBrand, string country)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Component name cannot be empty", nameof(name));

        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than or equal to 0");

        if (stock < 0)
            throw new ArgumentOutOfRangeException(nameof(stock), "Stock must be greater than or equal to 0");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        Model = model;
        Color = color;
        Dimensions = dimensions;
        Material = material;
        Weight = weight;
        CategoryType = categoryType;
        CategorySubType = categorySubType;
        CategoryBrand = categoryBrand;
        Country = country;
    }

    public Component(CreateComponentCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Price = command.Price;
        Stock = command.Stock;
        Image = command.Image;
        Model = command.Model;
        Color = command.Color;
        Dimensions = command.Dimensions;
        Material = command.Material;
        Weight = command.Weight;
        CategoryType = command.CategoryType;
        CategorySubType = command.CategorySubType;
        CategoryBrand = command.CategoryBrand;
        Country = command.Country;
    }
}

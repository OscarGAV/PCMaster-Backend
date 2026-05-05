using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Component.Domain.Model.Commands;
using Backend.Component.Domain.Model.ValueObjects;
using Backend.Component.Interfaces.REST.Resources;

namespace Backend.Component.Domain.Model.Aggregates;

public partial class Component
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float Price { get; private set; }
    public int Stock { get; private set; }
    public int ProviderId { get; set; }
    public string Image {get; private set;}
    public int Ratings { get; set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string Dimensions { get; private set; }
    public string Material { get; private set; }
    public string Weight { get; private set; }

    // Propiedades para categorías específicas
    public string CategoryType { get; private set; }
    public string CategorySubType { get; private set; }
    public string CategoryBrand { get; private set; }
    public string Country { get; set; }
    public Component(string name, string description, float price, int stock, string image, int providerId, int ratings,
        string model, string color, string dimensions, 
        string material, string weight, string categoryType, string categorySubType, string categoryBrand, string country)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        ProviderId = providerId;
        Ratings = ratings;
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
        ProviderId = command.ProviderId;
        Image = command.Image;
        Ratings = command.Ratings;
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
using System.ComponentModel.DataAnnotations;

namespace Backend.Component.Interfaces.REST.Resources
{
    public record CreateComponentResource(
        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Name cannot be empty")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters")]
        string Name,

        [MaxLength(500, ErrorMessage = "Description must be at most 500 characters")]
        string? Description,

        [Range(0, float.MaxValue, ErrorMessage = "Price must be greater than or equal to 0")]
        float Price,

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater than or equal to 0")]
        int Stock,

        [Range(1, int.MaxValue, ErrorMessage = "ProviderId must be a positive number")]
        int ProviderId,

        [Required(ErrorMessage = "Image URL is required")]
        [MaxLength(200, ErrorMessage = "Image URL must be at most 200 characters")]
        string Image,

        [Range(0, 5, ErrorMessage = "Ratings must be between 0 and 5")]
        int Ratings,

        [MaxLength(100, ErrorMessage = "Model must be at most 100 characters")]
        string Model,

        [MaxLength(50, ErrorMessage = "Color must be at most 50 characters")]
        string Color,

        [MaxLength(50, ErrorMessage = "Dimensions must be at most 50 characters")]
        string Dimensions,

        [MaxLength(50, ErrorMessage = "Material must be at most 50 characters")]
        string Material,

        [MaxLength(50, ErrorMessage = "Weight must be at most 50 characters")]
        string Weight,

        [MaxLength(50, ErrorMessage = "CategoryType must be at most 50 characters")]
        string CategoryType,

        [MaxLength(50, ErrorMessage = "CategorySubType must be at most 50 characters")]
        string CategorySubType,

        [MaxLength(50, ErrorMessage = "CategoryBrand must be at most 50 characters")]
        string CategoryBrand,

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(50, ErrorMessage = "Country must be at most 50 characters")]
        string Country
    );
}
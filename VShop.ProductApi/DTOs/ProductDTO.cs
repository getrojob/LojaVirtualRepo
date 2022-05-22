using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(3, ErrorMessage = "The field {0} must have a minimum of {1} characters")]
        [MaxLength(100, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(5, ErrorMessage = "The field {0} must have a minimum of {1} characters")]
        [MaxLength(200, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, 9999, ErrorMessage = "The field {0} must be a number greater than {1}")]
        public long Stock { get; set; }
        public string? ImageURL { get; set; }
        public string? CategoryName { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
    }
}

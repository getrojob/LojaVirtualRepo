using System.ComponentModel.DataAnnotations;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(3, ErrorMessage = "The field {0} must have a minimum of {1} characters")]
        [MaxLength(100, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Dto
{
    public class FoodCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}

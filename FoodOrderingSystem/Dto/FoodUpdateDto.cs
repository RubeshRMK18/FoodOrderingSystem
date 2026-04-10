using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Dto
{ 
        public class FoodUpdateDto
        {
            [Required]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Category { get; set; }

            [Required]
            public decimal Price { get; set; }

            public string ImageUrl { get; set; }

            public bool IsAvailable { get; set; }
        }
    }

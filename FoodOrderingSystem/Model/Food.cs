using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Model
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }


    }
}

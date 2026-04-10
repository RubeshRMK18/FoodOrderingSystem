namespace FoodOrderingSystem.Dto
{
    public class FoodResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public bool isAvailable { get; set; }
    }
}

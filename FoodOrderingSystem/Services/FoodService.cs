using FoodOrderingSystem.Data;
using FoodOrderingSystem.Dto;
using FoodOrderingSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodOrderingSystem.Services
{
    public class FoodService
    {

        private readonly AppDbContext _context;

        public FoodService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FoodResponseDto>> GetAllFoods()
        {
            return _context.Foods
                .Where(f => f.IsAvailable)
                .Select(f => new FoodResponseDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Category = f.Category,
                    Price = f.Price,
                    ImageUrl = f.ImageUrl
                })
                .ToList();
        }

        public async Task<FoodResponseDto> GetFoodById(int id)
        {
            var food = _context.Foods.FirstOrDefault(f => f.Id == id);

            if (food == null) return null;

            return new FoodResponseDto
            {
                Id = food.Id,
                Name = food.Name,
                Category = food.Category,
                Price = food.Price,
                ImageUrl = food.ImageUrl
            };
        }

        public async Task<FoodResponseDto> AddFood(FoodCreateDto dto)
        {
            var food = new Food
            {
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                IsAvailable = true 
            };

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return new FoodResponseDto
            {
                Id = food.Id,
                Name = food.Name,
                Category = food.Category,
                Price = food.Price,
                ImageUrl = food.ImageUrl,
            };
        }
        public async Task<bool> UpdateFood(FoodUpdateDto dto)
        {
            var food = await _context.Foods
                .FirstOrDefaultAsync(f => f.Id == dto.Id);

            if (food == null)
                return false;

            // Update fields
            food.Name = dto.Name;
            food.Category = dto.Category;
            food.Price = dto.Price;
            food.ImageUrl = dto.ImageUrl;
            food.IsAvailable = dto.IsAvailable;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteFood(int id)
        {
            var food = await _context.Foods
                .FirstOrDefaultAsync(f => f.Id == id);

            if (food == null)
                return false;

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

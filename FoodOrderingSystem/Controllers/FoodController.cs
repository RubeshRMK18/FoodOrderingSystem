using FoodOrderingSystem.Dto;
using FoodOrderingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
            private readonly FoodService _foodService;

            public FoodController(FoodService foodService)
            {
                _foodService = foodService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllFoods()
            {
                var foods = await _foodService.GetAllFoods();
                return Ok(foods);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetFoodById(int id)
            {
                var food = await _foodService.GetFoodById(id);

                if (food == null)
                    return NotFound("Food not found");

                return Ok(food);
            }

    
            [HttpPost]
            public async Task<IActionResult> AddFood(FoodCreateDto dto)
            {
                var newFood = await _foodService.AddFood(dto);
                return Ok(newFood);
            }
        [HttpPut]
        public async Task<IActionResult> UpdateFood(FoodUpdateDto dto)
        {
            var result = await _foodService.UpdateFood(dto);

            if (!result)
                return NotFound("Food not found");

            return Ok("Food updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var result = await _foodService.DeleteFood(id);

            if (!result)
                return NotFound("Food not found");

            return Ok("Food deleted successfully");
        }
    }
    }

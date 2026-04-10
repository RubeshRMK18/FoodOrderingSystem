using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Model;
using FoodOrderingSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // ✅ POST → BODY INPUT (NO ID IN URL)
        [HttpPost("place")]
        public IActionResult PlaceOrder([FromBody] PlaceOrderDto dto)
        {
            if (dto.UserId <= 0)
                return BadRequest("Invalid userId");

            var result = _orderService.PlaceOrder(dto.UserId);

            if (result.Contains("No items"))
                return BadRequest(result);

            return Ok(result);
        }

        // ✅ GET → SIMPLE PARAM
        [HttpGet("{userId}")]
        public IActionResult GetOrders(int userId)
        {
            var orders = _orderService.GetOrders(userId);
            return Ok(orders);
        }
    }
}
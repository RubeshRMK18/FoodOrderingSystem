using FoodOrderingSystem.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var token = _authService.Register(new DTO.RegisterDTO { Id = 1, Username = "testuser", Password = "password" });
            return Ok(token);
        }

        [HttpPost("Register")]
        public IActionResult Register(DTO.RegisterDTO registerDTO)
        {
            var token = _authService.Register(registerDTO);
            return Ok(token);
        }

        [HttpPost("Login")]
        public IActionResult Login(DTO.LoginDTO loginDTO)
        {
            var token = _authService.Login(loginDTO);
            return Ok(token);
        }
    }
}

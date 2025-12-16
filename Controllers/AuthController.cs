using AuthApi.DTOs;
using AuthApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthApi.Controllers
{
    [ApiController] // Marks the class as a controller for handling API requests
    [Route("api/[controller]")] // Route template for the controller
    public class AuthController : ControllerBase  // Inherits from ControllerBase to provide API functionalities
    {
        private readonly AuthService _authService; // Service for authentication operations

        public AuthController(AuthService authService)  // Constructor with dependency injection
        {
            _authService = authService;
        }

        [HttpPost("register")] // Endpoint for user registration
        public async Task<IActionResult> Register(RegisterDto dto) // Accepts registration data
        {
            try
            {
                var user = await _authService.RegisterAsync(dto);
                return Ok(new { user.Id, user.Username, user.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); // Return error message if registration fails
            }
        }

        [HttpPost("login")] // Endpoint for user login
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var token = await _authService.LoginAsync(dto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message }); // Return error message if login fails
            }
        }

        [Authorize]
        [HttpGet("me")] // Endpoint to get current user info, requires authorization
        public IActionResult Me() // Returns the authenticated user's information
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            return Ok(new { Id = userId, Email = email }); // Return user ID and email
        }
    }
}

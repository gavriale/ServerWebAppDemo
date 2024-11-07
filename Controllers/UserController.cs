using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationDemo.Data;
using WebApplicationDemo.DemoBL;
using WebApplicationDemo.Exceptions;
using WebApplicationDemo.models;

namespace WebApplicationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private UserBL _userBL;

        public UserController(ILogger<UserController> logger, UserBL userBL)
        {
            _logger = logger;
            _userBL = userBL;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            return await HandleUserRequest(
                        () => _userBL.GetUserById(userId),
                        userId.ToString(),
                        "ID"
                    );
            }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            return await HandleUserRequest(
                        () => _userBL.GetUserByEmail(email),
                        email,
                        "email"
                    );
        }

        private async Task<IActionResult> HandleUserRequest(Func<Task<User>> getUserFunc, string identifier, string identifierType)
        {
            _logger.LogInformation($"Attempting to retrieve user with {identifierType}: {identifier}");

            try
            {
                User retrievedUser = await getUserFunc();
                return Ok(retrievedUser);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogWarning($"User with {identifierType} {identifier} not found. Error: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Invalid argument for user {identifierType} {identifier}. Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred while retrieving user with {identifierType} {identifier}. Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}

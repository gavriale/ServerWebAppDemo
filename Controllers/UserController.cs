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
            _logger.LogInformation($"In Controller GetUserById: {userId}");
            try
            {
                _logger.LogInformation($"Attempting to retrieve user with ID: {userId}");
                 User retrievedUser = await _userBL.GetUserById(userId);
                 return Ok(retrievedUser);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogWarning($"User with ID {userId} not found. Error: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Invalid argument for user ID {userId}. Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred while retrieving user with ID {userId}. Error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

    }
}

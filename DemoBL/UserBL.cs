using WebApplicationDemo.Controllers;
using WebApplicationDemo.DemoDAL;
using WebApplicationDemo.Exceptions;
using WebApplicationDemo.models;

namespace WebApplicationDemo.DemoBL
{
    public class UserBL
    {
        private readonly ILogger<UserBL> _logger;
        private UserDAL _userDAL;


        public UserBL(ILogger<UserBL> logger, UserDAL userDAL)
        {
            _logger = logger;
            _userDAL = userDAL;
        }

        public async Task<User> GetUserById(int userId)
        {

            if (userId <= 0)
            {
                throw new ArgumentException("User ID must be greater than 0", nameof(userId));
            }

            User retrievedUser = await _userDAL.GetUserById(userId);

            if (retrievedUser == null)
            {
                throw new UserNotFoundException(userId);
            }

            _logger.LogInformation($"User with ID {userId} retrieved successfully");
            return retrievedUser;
        }

        public async Task<User> GetUserByEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            User retrievedUser = await _userDAL.GetUserByEmail(email);

            if (retrievedUser == null)
            {
                throw new UserNotFoundException(email);
            }

            return retrievedUser;
        }


    }
}

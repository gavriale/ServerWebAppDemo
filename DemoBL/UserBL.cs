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
            User retrievedUser = await _userDAL.GetUserById(userId);

            if (retrievedUser == null)
            {
                throw new UserNotFoundException(userId);
            }

            return retrievedUser;
        }
    }
}

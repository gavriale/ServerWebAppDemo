using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Controllers;
using WebApplicationDemo.Data;
using WebApplicationDemo.Exceptions;
using WebApplicationDemo.Interfaces;
using WebApplicationDemo.models;

namespace WebApplicationDemo.DemoDAL
{
    public class UserDAL : IUserRepository
    {
        private readonly ILogger<UserDAL> _logger;
        private ApplicationDbContext _contextDB;

        public UserDAL(ApplicationDbContext contextDB, ILogger<UserDAL> logger)
        {
            _logger = logger;
            _contextDB = contextDB;
        }

        public async Task<User> GetUserById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Illegal Id input, Id should be greater than 0");
            }

            User? retrievedUser = await _contextDB.Users
                                            .Include(u => u.Certificates)
                                            .FirstOrDefaultAsync(u => u.Id == id);
            if (retrievedUser == null)
            {
                _logger.LogWarning($"User with ID {id} not found");
                throw new UserNotFoundException(id);
            }

            _logger.LogInformation($"User with ID {id} retrieved successfully");
            return retrievedUser;
        }
    }
}

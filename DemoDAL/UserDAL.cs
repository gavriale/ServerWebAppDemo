﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<User> AddUser()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User? retrievedUser = await _contextDB.Users
                .Where(u => u.Email.Equals(email))
                .FirstOrDefaultAsync();

            return retrievedUser;
        }

        public async Task<User> GetUserById(int id)
        {
          
            User? retrievedUser = await _contextDB.Users
                                            .Include(u => u.Certificates)
                                            .FirstOrDefaultAsync(u => u.Id == id);
            return retrievedUser;
        }
    }
}

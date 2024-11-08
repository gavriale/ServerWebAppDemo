﻿using WebApplicationDemo.models;

namespace WebApplicationDemo.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser();

    }
}

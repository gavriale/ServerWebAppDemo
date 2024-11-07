using WebApplicationDemo.models;

namespace WebApplicationDemo.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);

    }
}

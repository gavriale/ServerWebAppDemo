namespace WebApplicationDemo.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public int? UserId { get; }
        public string Email { get; }

        public UserNotFoundException(int userId)
            : base($"User with ID {userId} was not found.")
        {
            UserId = userId;
        }

        public UserNotFoundException(string email)
            : base($"User with Email {email} was not found.")
        {
            Email = email;
        }
    }
}

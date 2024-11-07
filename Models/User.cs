namespace WebApplicationDemo.models
{
    // User Model
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Unique
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Navigation property to define one-to-many relationship
        public ICollection<Certificate> Certificates { get; set; }
    }
}

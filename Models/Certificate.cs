
namespace WebApplicationDemo.models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string CertificateId { get; set; } // Unique
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        // Foreign Key
        public int UserId { get; set; }

        
    }
}

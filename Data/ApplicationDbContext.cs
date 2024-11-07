using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.models;

namespace WebApplicationDemo.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserId)
                .IsUnique();

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserId = "U001", Name = "John Doe", Email = "john@example.com", DateOfBirth = new DateTime(1990, 1, 1) },
                new User { Id = 2, UserId = "U002", Name = "Jane Smith", Email = "jane@example.com", DateOfBirth = new DateTime(1992, 5, 23) },
                new User { Id = 3, UserId = "U003", Name = "Alice Johnson", Email = "alice@example.com", DateOfBirth = new DateTime(1985, 11, 30) },
                new User { Id = 4, UserId = "U004", Name = "Bob Brown", Email = "bob@example.com", DateOfBirth = new DateTime(1995, 8, 15) }
            );

            // Seed data for Certificates
            modelBuilder.Entity<Certificate>().HasData(
                new Certificate { Id = 1, CertificateId = "C001", Description = "Certification A", StartDate = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 1 },
                new Certificate { Id = 2, CertificateId = "C002", Description = "Certification B", StartDate = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 2 },
                new Certificate { Id = 3, CertificateId = "C003", Description = "Certification C", StartDate = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 3 },
                new Certificate { Id = 4, CertificateId = "C004", Description = "Certification D", StartDate = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 1 },
                new Certificate { Id = 5, CertificateId = "C005", Description = "Certification E", StartDate = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 4 }
            );


        }
    }
}
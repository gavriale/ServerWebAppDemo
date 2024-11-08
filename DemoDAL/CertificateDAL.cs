using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.Interfaces;
using WebApplicationDemo.models;

namespace WebApplicationDemo.DemoDAL
{
    public class CertificateDAL : ICertificatesRepository
    {
        private readonly ILogger<CertificateDAL> _logger;
        private readonly ApplicationDbContext _context;

        public CertificateDAL(ApplicationDbContext context, ILogger<CertificateDAL> logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Certificate> GetCertificateById(string certificateId)
        {
            Certificate? retrievedCertificate = await _context.Certificates.FirstOrDefaultAsync(c => c.CertificateId == certificateId);
            return retrievedCertificate;
        }

        public async Task<List<Certificate>> GetCertificates()
        {
            List<Certificate> certificates = await _context.Certificates.ToListAsync();

            if (!certificates.Any())
            {
                _logger.LogWarning("No users found.");
            }
            else
            {
                _logger.LogInformation($"{certificates.Count} users retrieved.");
            }

            return certificates;
        }

        public async Task<Certificate> AddCertificate(Certificate certificateToAdd)
        {
            if (certificateToAdd == null)
            {
                throw new ArgumentNullException(nameof(certificateToAdd), "Certificate data is null.");
            }

            _context.Certificates.Add(certificateToAdd);
            await _context.SaveChangesAsync();
            return certificateToAdd;
        }

        public Task<List<Certificate>> GetCertificatesByUserId(Certificate certificate)
        {
            throw new NotImplementedException();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Controllers;
using WebApplicationDemo.DemoDAL;
using WebApplicationDemo.models;

namespace WebApplicationDemo.DemoBL
{
    public class CertificateBL
    {
        private readonly ILogger<UserController> _logger;
        private CertificateDAL _certificateDAL;


        public CertificateBL(ILogger<UserController> logger, CertificateDAL certificateDAL)
        {
            _logger = logger;
            _certificateDAL = certificateDAL;
        }

        public async Task<Certificate> GetCertificateById(string certificateId)
        {
            Certificate? certificate = await _certificateDAL.GetCertificateById(certificateId);
            return certificate;
        }

        public async Task<Certificate> AddCertificate(Certificate certificateToAdd)
        {
            if (certificateToAdd == null)
            {
                _logger.LogInformation($"{nameof(certificateToAdd)} has no value.");
                return null;
            }
            Certificate? addedCertificate = await _certificateDAL.AddCertificate(certificateToAdd);

            return addedCertificate;
        }

        public async Task<List<Certificate>> GetCertificates()
        {
            _logger.LogInformation($"GetCertificates BL");

            var certificates = await _certificateDAL.GetCertificates();
            return certificates;
        }


    }
}

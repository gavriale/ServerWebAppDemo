using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.DemoBL;
using WebApplicationDemo.models;

namespace WebApplicationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserController> _logger;
        private CertificateBL _certificateBL;

        public CertificateController(ApplicationDbContext context, ILogger<UserController> logger,CertificateBL certificateBL)
        {
            _logger = logger;
            _context = context;
            _certificateBL = certificateBL;
        }

        [HttpPost]
        public async Task<IActionResult> AddCertificate([FromBody] Certificate certificateToAdd)
        {
            if (certificateToAdd == null)
            {
                return BadRequest("Certificate data is null.");
            }

            Certificate addedCertificate = await _certificateBL.AddCertificate(certificateToAdd);
            return Ok(addedCertificate);
        }


        [HttpGet("{certificateId}")]
        public async Task<IActionResult> GetCertificateById(string certificateId)
        {
            Certificate certificate = await _certificateBL.GetCertificateById(certificateId);

            if (certificate == null)
            {
                _logger.LogWarning($"No Certificate found with certificateId: {certificateId}");
            }
            else
            {
                _logger.LogInformation($"{certificateId} certificate retrieved.");
            }

            return Ok(certificate);
        }

        [HttpGet]
        public IActionResult GetCertificates()
        {
            _logger.LogInformation($"GetCertificates Controller");

            List<Certificate> certificates = _context.Certificates.ToList();

            if (!certificates.Any())
            {
                _logger.LogWarning("No users found.");
            }
            else
            {
                _logger.LogInformation($"{certificates.Count} users retrieved.");
            }

            return Ok(certificates);
        }
       
    }
}

/**
 * {
  "certificateId": "c003",
  "description": "SSL Certificate for Website Security",
  "startDate": "2024-11-01T00:00:00",
  "dueDate": "2025-11-01T00:00:00",
  "userId": 1
}
 */

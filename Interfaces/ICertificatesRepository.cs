using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.models;

namespace WebApplicationDemo.Interfaces
{
    public interface ICertificatesRepository
    {
        Task<List<Certificate>> GetCertificates();
        Task<Certificate> GetCertificateById(string certificateId);
        Task<Certificate> AddCertificate(Certificate certificate);
        Task<List<Certificate>> GetCertificatesByUserId(Certificate certificate);


    }
}

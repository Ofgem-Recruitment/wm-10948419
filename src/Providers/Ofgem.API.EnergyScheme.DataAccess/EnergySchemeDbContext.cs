using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Ofgem.API.EnergyScheme.DataAccess
{
    public class EnergySchemeDbContext : DbContext
    {
        public DbSet<CertificateRequest> CertificateRequests { get; set; }
    }
}
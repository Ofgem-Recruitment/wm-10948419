using System.ComponentModel.DataAnnotations;

namespace Ofgem.API.EnergyScheme.Domain.Entities;

public sealed class CertificateRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double EnergyGenerated { get; set; }

    public EnergyType EnergyType { get; set; }
}

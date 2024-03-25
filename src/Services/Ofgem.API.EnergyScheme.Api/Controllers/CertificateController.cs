using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ofgem.API.EnergyScheme.Core;
using Ofgem.API.EnergyScheme.Domain;

namespace Ofgem.API.EnergyScheme.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize("Managers")]
    public class CertificateController : ControllerBase
    {
        private readonly ILogger<CertificateController> logger;

        public CertificateController(ILogger<CertificateController> logger)
        {
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] double energyGenerated, EnergyType energyType)
        {
            var calculationService = new CalculationService();

            return await calculationService.CertificateEntitlement(energyGenerated, energyType);
        }
    }

}

using Ofgem.API.EnergyScheme.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ofgem.API.EnergyScheme.Core
{
    public class CalculationService : ICalculationService
    {
        public int CertificateEntitlement(double energyGenerated, EnergyType type)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(energyGenerated);

            int certificates;

            switch (type)
            {
                case EnergyType.Solar:
                    certificates = energyGenerated / 1000;
                    break;
                case EnergyType.Wind:
                    certificates = energyGenerated / 2000;
                    break;
                default:
                    throw new ArgumentException("Invalid Energy Type");
            }

            if (certificates < 0)
                throw new InvalidOperationException("Negative certificate count detected");

            return certificates;
        }
    }
}

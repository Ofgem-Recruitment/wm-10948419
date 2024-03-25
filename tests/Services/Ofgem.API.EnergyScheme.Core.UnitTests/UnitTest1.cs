using Ofgem.API.EnergyScheme.Domain;

namespace Ofgem.API.EnergyScheme.Core.UnitTests;

public class CalculationServiceTests
{
    [Theory]
    [InlineData(1000, EnergyType.Solar, 1)]
    [InlineData(2000, EnergyType.Wind, 1)]
    [InlineData(500, EnergyType.Solar, 0)]    
    public void CertificateEntitlement_ValidInput_ReturnsExpectedCertificates(
        double energyGenerated,
        EnergyType energyType,
        int expectedCertificates)
    {
        // Arrange
        var certificatesService = new CalculationService();

        // Act
        int actualCertificates = certificatesService.CertificateEntitlement(energyGenerated, energyType);

        // Assert
        Assert.Equal(expectedCertificates, actualCertificates);
    }

    [Theory]
    [InlineData(-100, EnergyType.Solar)] 
    [InlineData(1000, (EnergyType)99)] 
    public void CalculateCertificates_InvalidInput_ThrowsException(double energyGenerated, EnergyType type)
    {
        // Arrange
        var certificateService = new CalculationService();

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => certificateService.CertificateEntitlement(energyGenerated, type));
    }

}
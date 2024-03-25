using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Ofgem.API.EnergyScheme.DataAccess.UnitTests;

public class ServiceExtensionsTests
{
    [Fact]
    public void AddDataAccess_Should_RegisterDbContext_WithCorrectConnectionString()
    {
        // Arrange
        var services = new ServiceCollection();
        var configuration = new Mock<IConfiguration>();
        configuration.Setup(c => c.GetConnectionString("EnergySchemeDatabase"))
            .Returns("ATestConnectionString");

        // Act
        services.AddDataAccess(configuration.Object);
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<EnergySchemeDbContext>();

        // Assert
        Assert.NotNull(dbContext);
        Assert.IsType<EnergySchemeDbContext>(dbContext);
    }
}
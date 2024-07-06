using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TimerLog.WebAPI.Extensions;
using TimerLog.WebAPI.Services;

namespace TimerLog.Tests.Extensions
{
    /// <summary>
    /// <see cref="ServiceCollectionExtensions"/>の単体テスト
    /// </summary>
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void OkAddDIComponents()
        {
            // Arrange
            var services = new ServiceCollection();
            var assembly = Assembly.GetAssembly(typeof(ITimerLogService));

            // Act
            services.AddDIComponents(assembly);

            // Assert
            var expected = services.FirstOrDefault(s => s.ServiceType == typeof(ITimerLogService));
            Assert.NotNull(expected);
            Assert.Equal(ServiceLifetime.Transient, expected.Lifetime);
        }

    }
}

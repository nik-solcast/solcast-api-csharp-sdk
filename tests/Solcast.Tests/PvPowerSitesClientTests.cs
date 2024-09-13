using NUnit.Framework;
using Solcast.Clients;
using System.Threading.Tasks;

namespace Solcast.Tests
{
    [TestFixture]
    public class PvPowerSitesClientTests
    {
        private PvPowerSitesClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new PvPowerSitesClient();
        }

        [Test]
        public async Task Test_ListPvPowerSites()
        {
            // Act
            var response = await _client.ListPvPowerSites("json");

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Contains("resource_id"));
        }

        [Test]
        public async Task Test_GetPvPowerSite()
        {
            // Arrange
            var resourceId = UnmeteredLocations.Locations["Sydney Opera House"].ResourceId;

            // Act
            var response = await _client.GetPvPowerSite(resourceId, "json");

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Contains(resourceId));
        }
    }
}

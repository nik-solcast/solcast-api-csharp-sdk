using NUnit.Framework;
using Solcast.Clients;
using System;
using System.Threading.Tasks;

namespace Solcast.Tests
{
    [TestFixture]
    public class HistoricClientTests
    {
        private HistoricClient _historicClient;
        private string _originalApiKey;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Capture the original API key (if it exists)
            _originalApiKey = Environment.GetEnvironmentVariable("SOLCAST_API_KEY");
        }

        [SetUp]
        public void Setup()
        {
            // Reuse the original API key (if it exists)
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);

            // Initialize the HistoricClient
            _historicClient = new HistoricClient();
        }

        [TearDown]
        public void TearDown()
        {
            // Reset the environment variable to the original API key after each test
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);
        }

        [Test]
        public async Task GetHistoricRadiationAndWeather_ShouldReturnValidData()
        {
            // Arrange
            double latitude = -33.856784;
            double longitude = 151.215297;
            string start = "2022-06-01T06:00";
            string duration = "P1D";

            // Act
            var response = await _historicClient.GetRadiationAndWeather(latitude, longitude, start, duration: duration);

            // Assert
            Assert.IsNotNull(response);
            // Additional assertions can be added here based on response structure
        }

        [Test]
        public void GetHistoricRadiationAndWeather_ShouldThrowException_WhenApiKeyIsMissing()
        {
            // Arrange
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", null);
            _historicClient = new HistoricClient();

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await _historicClient.GetRadiationAndWeather(-33.856784, 151.215297, "2022-06-01T06:00", duration: "P1D");
            });
        }

        // [Test]
        // public async Task GetHistoricRooftopPvPower_ShouldReturnValidData()
        // {
        //     // Arrange
        //     double latitude = -33.856784;
        //     double longitude = 151.215297;
        //     string start = "2022-06-01T06:00";
        //     string duration = "P1D";

        //     // Act
        //     var response = await _historicClient.GetRooftopPvPower(latitude, longitude, start, duration: duration);

        //     // Assert
        //     Assert.IsNotNull(response);
        //     // Additional assertions based on response data structure
        // }

        // [Test]
        // public void GetHistoricRooftopPvPower_ShouldThrowException_WhenApiKeyIsMissing()
        // {
        //     // Arrange
        //     Environment.SetEnvironmentVariable("SOLCAST_API_KEY", null);

        //     // Act & Assert
        //     Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
        //     {
        //         await _historicClient.GetRooftopPvPower(-33.856784, 151.215297, "2022-06-01T06:00", duration: "P1D");
        //     });
        // }

        // [Test]
        // public async Task GetHistoricAdvancedPvPower_ShouldReturnValidData()
        // {
        //     // Arrange
        //     int resourceId = 12345;  // Replace with a valid resource ID
        //     string start = "2022-06-01T06:00";
        //     string duration = "P1D";

        //     // Act
        //     var response = await _historicClient.GetAdvancedPvPower(resourceId, start, duration: duration);

        //     // Assert
        //     Assert.IsNotNull(response);
        //     // Additional assertions based on response data structure
        // }

        // [Test]
        // public void GetHistoricAdvancedPvPower_ShouldThrowException_WhenApiKeyIsMissing()
        // {
        //     // Arrange
        //     Environment.SetEnvironmentVariable("SOLCAST_API_KEY", null);

        //     // Act & Assert
        //     Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
        //     {
        //         await _historicClient.GetAdvancedPvPower(12345, "2022-06-01T06:00", duration: "P1D");
        //     });
        // }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Restore the original API key after all tests
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);
        }
    }
}

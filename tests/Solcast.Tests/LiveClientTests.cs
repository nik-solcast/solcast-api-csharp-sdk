using NUnit.Framework;
using Solcast.Clients;
using System;
using System.Threading.Tasks;

namespace Solcast.Tests
{
    [TestFixture]
    public class LiveClientTests
    {
        private LiveClient _liveClient;
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

            // Initialize the LiveClient
            _liveClient = new LiveClient();
        }

        [TearDown]
        public void TearDown()
        {
            // After each test, revert back to the original API key (if it exists)
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);
        }

        [Test]
        public async Task GetRadiationAndWeather_ShouldReturnValidCsvData()
        {
            // Arrange
            double latitude = -33.856784;
            double longitude = 151.215297;
            string[] outputParameters = { "dni", "ghi", "air_temp" };

            // Act
            var response = await _liveClient.GetRadiationAndWeather(latitude, longitude, outputParameters);

            // Assert - checking if the response is in CSV format (string)
            Assert.IsInstanceOf<string>(response);
            var csvData = (string)response;

            // Basic check to ensure that the CSV has the expected headers and content
            Assert.IsNotEmpty(csvData);
            Assert.IsTrue(csvData.Contains("dni,ghi,air_temp"), "CSV headers missing or incorrect");
        }

        [Test, Category("Live")]
        public void GetRadiationAndWeather_ShouldThrowUnauthorizedAccessException_WhenApiKeyIsMissing()
        {
            // Arrange: Simulate missing API key
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", null);
            _liveClient = new LiveClient(); // Reinitialize the client to refresh headers

            // Act & Assert
            var ex = Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await _liveClient.GetRadiationAndWeather(-33.856784, 151.215297, new[] { "dni", "ghi" });
            });

            // Assert the exception message
            Assert.AreEqual("Invalid API key.", ex.Message);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // After all tests are completed, restore the original API key
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);
        }
    }
}

using NUnit.Framework;
using Solcast.Clients;
using System.Threading.Tasks;

namespace Solcast.Tests
{
    [TestFixture]
    public class TmyClientTests
    {
        private TmyClient _tmyClient;

        [SetUp]
        public void Setup()
        {
            _tmyClient = new TmyClient();
        }

        [Test]
        public async Task GetRadiationAndWeather_ShouldReturnValidData()
        {
            var response = await _tmyClient.GetRadiationAndWeather(-33.856784, 151.215297);
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetRooftopPvPower_ShouldReturnValidData()
        {
            var response = await _tmyClient.GetRooftopPvPower(-33.856784, 151.215297);
            Assert.IsNotNull(response);
        }
    }
}

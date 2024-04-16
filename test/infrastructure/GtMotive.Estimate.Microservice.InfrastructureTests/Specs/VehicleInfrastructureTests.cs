using System.Net.Http;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    public class VehicleInfrastructureTests : InfrastructureTestBase
    {
        private readonly HttpClient _client;

        public VehicleInfrastructureTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
            _client = fixture?.Server.CreateClient();
        }

        // NO FUNCIONA
        [Fact]
        public async Task GetAllVehiclesReturnsOkResult()
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "vehicle/getAll");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json", response.Content.Headers.ContentType.ToString());
            request.Dispose();
        }
    }
}

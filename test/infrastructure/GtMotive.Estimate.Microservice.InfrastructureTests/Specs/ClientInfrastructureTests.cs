using System;
using System.Net.Http;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Host.Models;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    public class ClientInfrastructureTests : InfrastructureTestBase
    {
        private readonly HttpClient _client;

        public ClientInfrastructureTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
            _client = fixture?.Server.CreateClient();
        }

        [Fact]
        public async Task GetAllClientsReturnsOkResult()
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "Client/getAll");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var content = await response.ReadContentAsAsync<ClientDto[]>();
            Assert.IsType<ClientDto[]>(content);
            Assert.Contains("application/json", response.Content.Headers.ContentType.ToString(), StringComparison.Ordinal);
            request.Dispose();
        }
    }
}

using System.Net.Http.Json;
using Xunit;
using RealEstateApp.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace RealEstateApp.Tests.IntegrationTests
{
    public class PropertiesIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PropertiesIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllProperties_ShouldReturnProperties()
        {
            var response = await _client.GetAsync("/api/properties");
            response.EnsureSuccessStatusCode();
            var properties = await response.Content.ReadFromJsonAsync<List<Property>>();
            Assert.NotNull(properties);
        }
    }
}

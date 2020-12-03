﻿using System.Text.Json;
using System.Threading.Tasks;
using App.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace App.Tests
{
    [Collection("Tests de Integración")]
    public class EndpointsControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public EndpointsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/","Api está en linea")]
        [InlineData("/health","Healthy")]
        public async Task GetPath_ReturnsSuccessAndExpectedStatus(string path, string expectedStatus)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(path);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseObject = JsonSerializer.Deserialize<ResponseType>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.Equal(expectedStatus, responseObject?.Status);
        }

        private class ResponseType
        {
            public string Status { get; set; }
        }
    }
}

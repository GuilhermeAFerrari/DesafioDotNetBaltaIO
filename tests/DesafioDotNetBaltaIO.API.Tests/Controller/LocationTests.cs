using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DesafioDotNetBaltaIO.Application.Services;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using DesafioDotNetBaltaIO.Infrastructure.Context;
using Moq;
using Newtonsoft.Json;
using tests.DesafioDotNetBaltaIO.API.Tests.Controller;

namespace tests.DesafioDotNetBaltaIO.API.Tests
{
    public class LocationTests
    {
        private Mock<ILocationRepository> _mockService;

        public LocationTests()
        {
            _mockService = new Mock<ILocationRepository>();
        }

        [Fact]
        public async Task CreateLocationReturnUnauthorizedTest()
        {
            // Given
            var api = new LocationApiFactory();

            var httpClient = api.CreateClient();

            var data = new
            {
                Id = 1,
                City = "Belo Horizonte",
                State = "MG"
            };

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // When
            var response = await httpClient.PostAsync(requestUri: "/v1/location", content: content);

            // Then
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
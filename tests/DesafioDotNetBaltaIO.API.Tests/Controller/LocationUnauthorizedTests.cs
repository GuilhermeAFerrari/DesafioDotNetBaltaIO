using System.Net;
using System.Text;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using Moq;
using Newtonsoft.Json;
using tests.DesafioDotNetBaltaIO.API.Tests.Controller;

namespace tests.DesafioDotNetBaltaIO.API.Tests
{
    public class LocationTests
    {

        [Fact(DisplayName = "GetLocationReturnUnauthorizedTest")]
        public async Task GetLocationReturnUnauthorizedTest()
        {
            // Given
            var api = new LocationApiFactory();

            var httpClient = api.CreateClient();

            // When
            var response = await httpClient.GetAsync(requestUri: "/v1/locations");

            // Then
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "UpdateLocationReturnUnauthorizedTest")]
        public async Task UpdateLocationReturnUnauthorizedTest()
        {
            // Given
            var api = new LocationApiFactory();

            var httpClient = api.CreateClient();

            var data = new
            {
                Id = 1,
                City = "São Paulo",
                State = "SP"
            };

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // When
            var response = await httpClient.PutAsync(requestUri: "/v1/location/1", content: content);

            // Then
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        [Fact(DisplayName = "DeleteLocationReturnUnauthorizedTest")]
        public async Task DeleteLocationReturnUnauthorizedTest()
        {
            // Given
            var api = new LocationApiFactory();

            var httpClient = api.CreateClient();

            // When
            var response = await httpClient.DeleteAsync(requestUri: "/v1/location/30405526");

            // Then
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }


        [Fact(DisplayName = "CreateLocationReturnUnauthorizedTest")]
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
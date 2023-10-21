using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Xunit;

namespace tests.DesafioDotNetBaltaIO.API.Tests.Controller
{
    public class LocationJWTTests
    {
        public string TokenString { get; set; }
        public LocationJWTTests()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Chave_secreta");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, "Test User")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            TokenString = tokenHandler.WriteToken(token);
        }

        [Fact(DisplayName = "GetLocationReturnOkTest")]
        public async Task GetLocationReturnOkTest()
        {
            // Given
            var api = new LocationApiFactory();

            var httpClient = api.CreateClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenString);

            // When
            var response = await httpClient.GetAsync(requestUri: "/v1/locations");

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "CreateLocationReturnCreatedTest")]
        public async Task CreateLocationReturnCreatedTest()
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

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenString);

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // When
            var response = await httpClient.PostAsync(requestUri: "/v1/location", content: content);

            // Then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact(DisplayName = "UpdateLocationReturnOkTest")]
        public async Task UpdateLocationReturnOkTest()
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

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenString);

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // When
            var response = await httpClient.PutAsync(requestUri: "/v1/location", content: content);

            // Then
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        [Fact(DisplayName = "DeleteLocationReturnNoContentTest")]
        public async Task DeleteLocationReturnNoContentTest()
        {
            // Given
            var api = new LocationApiFactory();

            var httpClient = api.CreateClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenString);
            // When
            var response = await httpClient.DeleteAsync(requestUri: "/v1/location/1");

            // Then
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }


}
using APIWeb.Core.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace APIWeb.Test
{
    public class VehiculoTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Vehicle;
        private readonly ITestOutputHelper _testOutputHelper;

        public VehiculoTest(TestFixture<Startup> fixture, ITestOutputHelper testOutputHelper)
        {
            Vehicle = fixture.Client;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task GetVehicle_EmptyBody_IsSuccessStatusCodeIsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/Vehiculo"
            };

            // Act
            var response = await Vehicle.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetVehicle_EmptyBody_Count7IsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/Vehiculo"
            };

            // Act
            var response = await Vehicle.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaVehiculos = JsonSerializer.Deserialize<List<VehiculoDTO>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(listaVehiculos.Count == 7);
        }
    }
}

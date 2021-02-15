using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace APIWeb.Test
{
    public class UsuarioTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;
        private readonly ITestOutputHelper _testOutputHelper;

        public UsuarioTest(TestFixture<Startup> fixture, ITestOutputHelper testOutputHelper)
        {
            Client = fixture.Client;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task AddUser_ExpectedBody_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/Usuario",
                Body = new
                {
                    Username = "usuarioPrueba",
                    Password = "123ABCD",
                    Dni = "12345678G",
                    Nombre = "Jonathan",
                    Apellido = "Joestar",
                    JefeMecanico = "KamiKeys",
                    Especialidad = "Respirar",
                    Email = "j.joestar@speedwagonfndtn.com",
                    Tlf = "+1384952734",
                    RolIdRol = 1,
                    concesionarioDireccion = "Cuatro torres"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "true");
        }

        [Fact]
        public async Task AddExistingUser_ExpectedBody_ThrowsHttpRequestException()
        {
            // Arrange
            var request = new
            {
                Url = "/Usuario",
                Body = new
                {
                    Username = "aFernandez",
                    Password = "123ABC",
                    Dni = "28473614F",
                    Nombre = "Antonio",
                    Apellido = "Fernández",
                    JefeMecanico = "KamiKeys",
                    Especialidad = "Cambio de aceite",
                    Email = "afernandez@initald.es",
                    Tlf = "+34782364512",
                    RolIdRol = 1,
                    concesionarioDireccion = "Cuatro torres"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }

        [Fact]
        public async Task AddUser_EmptyBody_ThrowsHttpRequestException()
        {
            // Arrange
            var request = new
            {
                Url = "/Usuario",
                Body = new
                {
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }

        [Fact]
        public async Task GetUser_EmptyBody_IsSuccessStatusCodeIsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/Usuario"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

    }
}
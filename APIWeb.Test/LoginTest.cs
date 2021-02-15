using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace APIWeb.Test
{
    public class LoginTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public LoginTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task LoginTests_LoginBossCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/Login",
                Body = new
                {
                    Username = "algunJefe",
                    Password = "123"
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
        public async Task LoginTests_LoginBossInCorrect_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/Login",
                Body = new
                {
                    Username = "algunJefe",
                    Password = "13"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }

        [Fact]
        public async Task LoginTests_LoginIncorrect_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/Login",
                Body = new
                {
                    Username = "alguienDeVentas",
                    Password = "sdfghj"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }

    }
}
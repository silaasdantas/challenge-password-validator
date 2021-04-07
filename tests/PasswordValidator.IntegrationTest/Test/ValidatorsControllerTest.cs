using PasswordValidator.Api;
using PasswordValidator.IntegrationTest.Fixture;
using System.Threading.Tasks;
using Xunit;

namespace PasswordValidator.IntegrationTest.Test
{
    public class ValidatorsControllerTest
    {
        private readonly IntegrationTestFixture<StartupToIntegrationTest> _integrationTest;

        public ValidatorsControllerTest()
        {
            _integrationTest = new IntegrationTestFixture<StartupToIntegrationTest>();
            _integrationTest.Setup();
        }

        [Theory]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public async Task DeveValidar_Senha_Invalida(string password)
        {
            //arrange
            var request = new
            {
                Url = "/api/v1/validators/password",
                Body = new { password }
            };
            //act
            var response = await _integrationTest.Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            //assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Contains("false", value);
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        public async Task DeveValidar_Senha_Valida(string password)
        {
            //arrange
            var request = new
            {
                Url = "/api/v1/validators/password",
                Body = new { password }
            };
            //act
            var response = await _integrationTest.Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            //assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Contains("true", value);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using PasswordValidator.Core.Interfaces;
using Xunit;

namespace PasswordValidator.UnitTest
{
    public class PasswordServiceUnitTest
    {
        private readonly IPasswordService _service;

        public PasswordServiceUnitTest(UnitTestFixture fixture)
        {
            _service = fixture.ServiceProvider.GetRequiredService<IPasswordService>();
        }

        [Theory]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public void DeveValidar_Senha_Invalida(string password)
        {
            //act
            var result = _service.IsValid(password);

            //assert
            Assert.False(result);
        }  
        
        [Theory]
        [InlineData("AbTp9!fok")]
        public void DeveValidar_Senha_Valida(string password)
        {
            //act
            var result = _service.IsValid(password);

            //assert          
            Assert.True(result);
        }
    }
}

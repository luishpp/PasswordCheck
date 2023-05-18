using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordValidator.Application.Contracts;
using PasswordValidator.Tests;

namespace PasswordValidatorTests;

public class PasswordControllerTests : IClassFixture<BaseTest>
{
    private readonly IHost _host;

    public PasswordControllerTests(BaseTest baseTest)
    {
        _host = baseTest.TestHost;
    }    

    [Theory]
    [InlineData("", false)]
    [InlineData("aa", false)]
    [InlineData("ab", false)]
    [InlineData("AAAbbbCc", false)]
    [InlineData("AbTp9!foo", false)]
    [InlineData("AbTp9!foA", false)]
    [InlineData("AbTp9 fok", false)]
    [InlineData("AbTp9!fok", true)]
    public async void IsValid_Returns_Expected_Result(string password, bool expected)
    {
        // Arrange
        var service = _host.Services.GetService<IPasswordService>();

        // Act
        var result = service != null ? await service.CheckIfIsValid(password) : false;

        // Assert
        Assert.Equal(expected, result);
    }
}
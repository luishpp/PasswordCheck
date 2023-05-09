using PasswordValidator.API.Services;

namespace PasswordValidatorTests;

public class PasswordTests //ValidityTest
{
    [Theory]
    [InlineData("", false)]
    [InlineData("aa", false)]
    [InlineData("ab", false)]
    [InlineData("AAAbbbCc", false)]
    [InlineData("AbTp9!foo", false)]
    [InlineData("AbTp9!foA", false)]
    [InlineData("AbTp9 fok", false)]
    [InlineData("AbTp9!fok", true)]
    public void IsValid_Returns_Expected_Result(string password, bool expected) //ValidPassword
    {
        // Arrange
        var service = new PasswordService();

        // Act
        var result = service.CheckIfIsValid(password);

        // Assert
        Assert.Equal(expected, result);
    }
}
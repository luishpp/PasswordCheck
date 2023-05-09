namespace PasswordValidator.API.Services;

public interface IPasswordService
{
    Task<bool> CheckIfIsValid(string password);
}
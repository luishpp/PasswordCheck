namespace PasswordValidator.API.Services;

public interface IPasswordService
{
    bool CheckIfIsValid(string password);
}
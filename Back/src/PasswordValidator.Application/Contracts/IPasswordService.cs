namespace PasswordValidator.Application.Contracts;

public interface IPasswordService
{
    Task<bool> CheckIfIsValid(string password);
}
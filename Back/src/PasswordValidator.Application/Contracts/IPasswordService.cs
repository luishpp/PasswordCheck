namespace PasswordValidator.Application.Contracts;

public interface IPasswordService
{
    Task<bool> IsPasswordValid(string password);
}
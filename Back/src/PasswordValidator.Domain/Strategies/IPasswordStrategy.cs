namespace PasswordValidator.Domain.Strategies;

public interface IPasswordStrategy
{
    Task<bool> Validate(string password);
}
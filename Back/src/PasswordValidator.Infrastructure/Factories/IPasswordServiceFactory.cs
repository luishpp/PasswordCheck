using PasswordValidator.Application.Contracts;

namespace PasswordValidator.Infrastructure.Factories;

public interface IPasswordServiceFactory
{
    IPasswordService Create();
}

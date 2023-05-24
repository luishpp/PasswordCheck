using Microsoft.Extensions.Options;
using PasswordValidator.Application.Contracts;
using PasswordValidator.Domain.Models;
using PasswordValidator.Infrastructure.Configuration;
using PasswordValidator.Infrastructure.Services;

namespace PasswordValidator.Infrastructure.Factories;

public class PasswordServiceFactory : IPasswordServiceFactory
{
    private readonly RegexRule _regexConfig;
    private readonly RetryRules _retryConfig;   

    public PasswordServiceFactory(IOptions<RegexRule> regexOptions, IOptions<RetryRules> retryOptions)
    {
        _regexConfig = regexOptions.Value;     
        _retryConfig = retryOptions.Value;
    }

    public IPasswordService Create()
    {
        string pattern = _regexConfig.Pattern?.ToString();
        var passwordValidator = new Password(pattern);
        return new PasswordService(passwordValidator, _retryConfig.MaxRetryAttempts, _retryConfig.RetryDelay);
    }
}

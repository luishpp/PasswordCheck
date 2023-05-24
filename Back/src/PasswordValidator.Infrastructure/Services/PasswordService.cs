using PasswordValidator.Application.Contracts;
using PasswordValidator.Domain.Models;

namespace PasswordValidator.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    private readonly Password _passwordValidator;
    private readonly int _maxRetryAttempts;
    private readonly TimeSpan _retryDelay; 

    public PasswordService(Password passwordValidator, int maxRetryAttempts, TimeSpan retryDelay)
    {
        _passwordValidator = passwordValidator;
        _maxRetryAttempts = maxRetryAttempts;
        _retryDelay = retryDelay;
    }

    public async Task<bool> IsPasswordValid(string password)
    {
        int retryCount = 0;
        bool isValid = false;

        while (retryCount <= _maxRetryAttempts)
        {
            try
            {
                isValid = await _passwordValidator.IsValid(password);  
                break;
            }
            catch (Exception ex)
            {
                if (retryCount < _maxRetryAttempts)
                {
                    Thread.Sleep(_retryDelay);
                }
                else
                {
                    throw new Exception(ex.Message);
                }

                retryCount++;
            }
        }

        return isValid;
    }
}

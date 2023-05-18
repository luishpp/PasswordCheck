using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using PasswordValidator.Application.Contracts;
using PasswordValidator.Infrastructure.Configuration;

namespace PasswordValidator.Application.Services;

public class PasswordService : IPasswordService
{
    private readonly RegexConfig _configuration;

    public PasswordService(IOptions<RegexConfig> options)
    {
        _configuration = options.Value;        
    }

    public async Task<bool> CheckIfIsValid(string password)
    {
        bool isValid = false;

        try
        {
            var pattern = _configuration.Pattern?.ToString();
            if (pattern != null){
                isValid = await Task.Run(() => Regex.IsMatch(password, pattern));
            }
        }
        catch (System.Exception e)
        {            
            throw new("Processing failed. Check your appsettings", e);
        }
      
        return isValid;
    }
}
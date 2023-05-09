using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using PasswordValidator.API.Configuration;

namespace PasswordValidator.API.Services;

public class PasswordService : IPasswordService
{
    private readonly RegexPatternConfiguration _configuration;

    public PasswordService(IOptions<RegexPatternConfiguration> options)
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

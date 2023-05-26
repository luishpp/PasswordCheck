using System.Text.RegularExpressions;

namespace PasswordValidator.Domain.Models;

public class Password
{
    private readonly string _pattern;
    
    public Password(string pattern)
    {
        _pattern = pattern;
    }

    public async Task<bool> IsValid(string password)
    {
        //return _validationStrategy.Validate(password);
        return await Task.Run(() => Regex.IsMatch(password, _pattern));
    }
}
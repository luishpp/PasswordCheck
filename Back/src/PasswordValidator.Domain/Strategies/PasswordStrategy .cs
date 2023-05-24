using System.Text.RegularExpressions;

namespace PasswordValidator.Domain.Strategies;

public class RegexStrategy : IPasswordStrategy
{
    private readonly string _pattern;

    public RegexStrategy(string pattern)
    {
        _pattern = pattern;
    }

    public async Task<bool> Validate(string password)
    {
        return await Task.Run(() => Regex.IsMatch(password, _pattern));
    }
}

public class FormStrategy : IPasswordStrategy
{
    private readonly string _pattern;

    public FormStrategy(string pattern)
    {
        _pattern = pattern;
    }

    public async Task<bool> Validate(string password)
    {
        return await Task.Run(() => Regex.IsMatch(password, _pattern));
    }
}
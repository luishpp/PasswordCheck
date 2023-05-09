using System.Text.RegularExpressions;

namespace PasswordValidator.API.Services;

public class PasswordService : IPasswordService
{
    public bool CheckIfIsValid(string password)
    {
        string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()-+])(?!.*\s)(?!.*(.).*\1).+$";
        bool isValid = Regex.IsMatch(password, pattern);
        
        return isValid;
    }
}

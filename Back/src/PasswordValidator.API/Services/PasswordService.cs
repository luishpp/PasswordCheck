using System.Text.RegularExpressions;

namespace PasswordValidator.API.Services;

public class PasswordService
{
    public PasswordService() { }

    public bool CheckIfIsValid(string password)
    {
        string pattern = @"^(?!.*(.)\1+)[a-zA-Z\d!@#$%^&*()\-\+]{8,}$";
        bool isValid = Regex.IsMatch(password, pattern);
        
        return isValid;
    }        
}

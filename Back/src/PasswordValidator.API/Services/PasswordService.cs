using System.Text.RegularExpressions;

namespace PasswordValidator.API.Services;

public class PasswordService
{
    public PasswordService() { }

    public bool CheckIfIsValid(string password)
    {
        Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()-+*])[A-Za-z\\d!@#$%^&*()-+*]{9,}$");
        bool isValid = regex.IsMatch(password);
        
        return isValid;
    }        
}

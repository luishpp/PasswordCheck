using Microsoft.AspNetCore.Mvc;
using PasswordValidator.API.Services;

namespace PasswordValidatorAPI.Controllers; //Validators.Password

[ApiController]
[Route("api/[controller]")]
public class PasswordController : ControllerBase //PasswordValidator
{
    [HttpGet("{password}")]
    public bool IsValid(string password)
    {
        var service = new PasswordService();
       
        return service.CheckIfIsValid(password);
    }
}

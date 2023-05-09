using Microsoft.AspNetCore.Mvc;
using PasswordValidator.API.Services;

namespace PasswordValidatorAPI.Controllers; //Validators.Password

[ApiController]
[Route("api/[controller]")]
public class PasswordController : ControllerBase //PasswordValidator
{
    private readonly PasswordService _service;
    
    public PasswordController(PasswordService service)
    {
            _service = service;
    }

    [HttpGet("{password}")]
    public bool IsValid(string password)
    {      
        return _service.CheckIfIsValid(password);
    }
}

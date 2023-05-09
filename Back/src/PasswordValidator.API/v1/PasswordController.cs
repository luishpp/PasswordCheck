using Microsoft.AspNetCore.Mvc;
using PasswordValidator.API.Services;

namespace PasswordValidatorAPI.Controllers; //Validators.Password

[ApiController]
[Route("api/v1/[controller]")]
public class PasswordController : ControllerBase //PasswordValidator
{
    private readonly IPasswordService _service;
    
    public PasswordController(IPasswordService service)
    {
            _service = service;
    }

    [HttpGet("{password}")]
    public async Task<bool> IsValid(string password)
    {      
        return await _service.CheckIfIsValid(password);
    }
}

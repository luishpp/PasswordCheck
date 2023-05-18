using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Application.Contracts;

namespace PasswordValidator.API.Controllers; 

[ApiController]
[Route("api/v1/[controller]")]
public class PasswordController : ControllerBase 
{
    private readonly IPasswordService _service;
    
    public PasswordController(IPasswordService service)
    {
            _service = service;
    }

    [HttpGet("{password}")]
    public async Task<bool> IsValid(string password)
    {   
        bool isValid = false;

        try
        {
            isValid = await _service.CheckIfIsValid(password);
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }  

        return isValid;
    }
}

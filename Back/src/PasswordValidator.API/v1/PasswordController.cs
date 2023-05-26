using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Application.Contracts;

namespace PasswordValidator.API.Controllers; 

[ApiController]
[Route("api/v1/[controller]")]
public class PasswordController : ControllerBase 
{
    private readonly IPasswordService _service;
    private readonly ILogger<PasswordController> _logger; 
    
    public PasswordController(IPasswordService service, ILogger<PasswordController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public async Task<bool> Validate([FromBody] string password)
    {   
        bool isValid = false;

        isValid = await _service.IsPasswordValid(password);
        _logger.LogInformation($"Password is: {isValid}");

        return isValid;
    }
}

using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Infrastructure.Factories;

namespace PasswordValidator.API.Controllers; 

[ApiController]
[Route("api/v1/[controller]")]
public class PasswordController : ControllerBase 
{
    private readonly IPasswordServiceFactory _serviceFactory;
    private readonly ILogger<PasswordController> _logger; 
    
    public PasswordController(IPasswordServiceFactory serviceFactory, ILogger<PasswordController> logger)
    {
        _serviceFactory = serviceFactory;
        _logger = logger;
    }

    [HttpGet("{password}")]
    public async Task<bool> Validate(string password)
    {   
        bool isValid = false;
        var passwordService = _serviceFactory.Create();  

        try
        {
            isValid = await passwordService.IsPasswordValid(password);
            _logger.LogInformation($"Password is: {isValid}");
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }  

        return isValid;
    }
}

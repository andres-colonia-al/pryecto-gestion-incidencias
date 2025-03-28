using IncidentManagement.Application.Services;
using IncidentManagement.web.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.web.Controllers;

[ApiController]
[Route("api/login")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var(isValid, role, guid)  = await _authService.ValidateUser(loginRequestDto.Email, loginRequestDto.Password);
        if (!isValid) return Unauthorized(new { message = "Credenciales Invalidas!" });
        
        return Ok(new { message = "Login successful", role,  guid});
    }
    


}
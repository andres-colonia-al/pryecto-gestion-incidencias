using IncidentManagement.Application.Services;
using IncidentManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.Web.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (user == null)
            return BadRequest("User data is required");

        await _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.IdUser }, user);
    }
}
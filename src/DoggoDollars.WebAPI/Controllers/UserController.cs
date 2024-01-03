using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoggoDollars.WebAPI.Controllers;

[ApiController]
[Route("users")]

public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] User user)
    {
        User createdUser = await _userService.CreateAsync(user);

        return Created(nameof(CreateAsync), createdUser);
    }

    [HttpGet("{id}/transactions")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(await _userService.GetAsync(id));
    }
}

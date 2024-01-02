using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;

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
}

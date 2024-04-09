using Microsoft.AspNetCore.Mvc;
using webapi_5b.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var users = await _userService.GetAsync();
    return Ok(users);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var user = await _userService.GetByIdAsync(id);
    return Ok(user);
  }
}
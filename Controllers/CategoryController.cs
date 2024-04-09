using Microsoft.AspNetCore.Mvc;
using webapi_5b.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
  private readonly ICategoryService _categoryService;

  public CategoryController(ICategoryService categoryService)
  {
    _categoryService = categoryService;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var categories = await _categoryService.GetAsync();
    return Ok(categories);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var category = await _categoryService.GetByIdAsync(id);
    return Ok(category);
  }
}
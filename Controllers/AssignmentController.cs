using Microsoft.AspNetCore.Mvc;
using webapi_5b.Exceptions;
using webapi_5b.Models;
using webapi_5b.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController : ControllerBase
{
  private readonly IAssignmentService _assignmentService;

  public AssignmentController(IAssignmentService assignmentService)
  {
    _assignmentService = assignmentService;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var assignments = await _assignmentService.GetAsync();
    return Ok(assignments);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var assignment = await _assignmentService.GetByIdAsync(id);
    return Ok(assignment);
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Assignment assignment)
  {
    var savedAssignment = await _assignmentService.SaveAsync(assignment);
    return Ok(savedAssignment);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody] Assignment assignment)
  {
    var updatedAssignment = await _assignmentService.UpdateAsync(id, assignment);
    return Ok(updatedAssignment);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await _assignmentService.DeleteAsync(id);
    return Ok();
  }

}
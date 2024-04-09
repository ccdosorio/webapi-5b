namespace webapi_5b.Services;

using System.Net;
using Microsoft.EntityFrameworkCore;
using webapi_5b;
using webapi_5b.Exceptions;
using webapi_5b.Models;


public class AssignmentService : IAssignmentService
{
  private readonly AssignmentsContext _context;
  private readonly ILogger<AssignmentService> _logger;

  public AssignmentService(AssignmentsContext context, ILogger<AssignmentService> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<IEnumerable<Assignment>> GetAsync()
  {
    _logger.LogInformation("Se ha solicitado la lista de asignaciones.");
    return await _context.Assignments.ToListAsync();
  }

  public async Task<Assignment> GetByIdAsync(Guid id)
  {
    _logger.LogInformation($"Se ha solicitado la asignación con ID: {id}.");
    var currentAssignment = await _context.Assignments.FindAsync(id);

    if (currentAssignment == null)
    {
      _logger.LogWarning($"No se encontró ninguna asignación con el ID: {id}");
      throw new NotFoundException($"No se encontró ninguna asignación con el ID: {id}", HttpStatusCode.NotFound);
    }

    return currentAssignment;
  }


  public async Task<Assignment> SaveAsync(Assignment assignment)
  {
    if (assignment == null)
    {
      _logger.LogError("Se intentó guardar una asignación con un objeto de asignación nulo.");
      throw new ArgumentNullException(nameof(assignment));
    }

    _context.Add(assignment);
    await _context.SaveChangesAsync();

    _logger.LogInformation("Asignación guardada correctamente.");

    return assignment;
  }


  public async Task<Assignment?> UpdateAsync(Guid id, Assignment assignment)
  {
    if (assignment == null)
    {
      _logger.LogError("Se intentó actualizar una asignación con un objeto de asignación nulo.");
      throw new ArgumentNullException(nameof(assignment));
    }

    var currentAssignment = await GetByIdAsync(id);

    _logger.LogInformation($"Actualizando la asignación con ID: {id}");

    currentAssignment.Title = assignment.Title;
    currentAssignment.Description = assignment.Description;
    currentAssignment.AssignmentPriority = assignment.AssignmentPriority;
    currentAssignment.Category = assignment.Category;

    await _context.SaveChangesAsync();

    _logger.LogInformation($"Asignación con ID: {id} actualizada correctamente.");

    return assignment;
  }


  public async Task<Assignment?> DeleteAsync(Guid id)
  {
    var currentAssignment = await GetByIdAsync(id);
    _logger.LogInformation($"Eliminando la asignación con ID: {id}");

    _context.Remove(currentAssignment);
    await _context.SaveChangesAsync();

    _logger.LogInformation($"Asignación con ID: {id} eliminada correctamente.");

    return currentAssignment;
  }

}

public interface IAssignmentService
{
  Task<IEnumerable<Assignment>> GetAsync();
  Task<Assignment> GetByIdAsync(Guid id);
  Task<Assignment> SaveAsync(Assignment assignment);
  Task<Assignment?> UpdateAsync(Guid id, Assignment assignment);
  Task<Assignment?> DeleteAsync(Guid id);
}
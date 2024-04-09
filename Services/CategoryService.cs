namespace webapi_5b.Services;

using System.Net;
using Microsoft.EntityFrameworkCore;
using webapi_5b;
using webapi_5b.Exceptions;
using webapi_5b.Models;

public class CategoryService : ICategoryService
{
  private readonly AssignmentsContext _context;
  private readonly ILogger<CategoryService> _logger;

  public CategoryService(AssignmentsContext context, ILogger<CategoryService> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<IEnumerable<Category>> GetAsync()
  {
    _logger.LogInformation("Se ha solicitado la lista de categorias.");
    return await _context.Categories.ToListAsync();
  }

  public async Task<Category?> GetByIdAsync(Guid id)
  {

    _logger.LogInformation($"Se ha solicitado la categoría con ID: {id}.");
    var currentCategory = await _context.Categories.FindAsync(id);

    if (currentCategory == null)
    {
      _logger.LogWarning($"No se encontró ninguna categoria con el ID: {id}");
      throw new NotFoundException($"No se encontró ninguna categoria con el ID: {id}", HttpStatusCode.NotFound);
    }

    return currentCategory;
  }
}

public interface ICategoryService
{
  Task<IEnumerable<Category>> GetAsync();
  Task<Category?> GetByIdAsync(Guid id);
}
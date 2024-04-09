namespace webapi_5b.Services;

using System.Net;
using Microsoft.EntityFrameworkCore;
using webapi_5b;
using webapi_5b.Exceptions;
using webapi_5b.Models;

public class UserService : IUserService
{
  private readonly AssignmentsContext _context;
  private readonly ILogger<UserService> _logger;

  public UserService(AssignmentsContext context, ILogger<UserService> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<IEnumerable<User>> GetAsync()
  {
    _logger.LogInformation("Se ha solicitado la lista de usuarios.");
    return await _context.Users.ToListAsync();
  }

  public async Task<User?> GetByIdAsync(Guid id)
  {
    _logger.LogInformation($"Se ha solicitado el usuario con ID: {id}.");
    var currentUser = await _context.Users.FindAsync(id);

    if (currentUser == null)
    {
      _logger.LogWarning($"No se encontró ningun usuario con el ID: {id}");
      throw new NotFoundException($"No se encontró ningun usuario con el ID: {id}", HttpStatusCode.NotFound);
    }

    return currentUser;
  }
}

public interface IUserService
{
  Task<IEnumerable<User>> GetAsync();
  Task<User?> GetByIdAsync(Guid id);
}
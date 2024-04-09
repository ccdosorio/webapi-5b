using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi_5b.Models;

public class User : BaseEntity
{
  [Required]
  public Guid UserId { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  public string Username { get; set; }

  [Required]
  public string Password { get; set; }

  [JsonIgnore]
  public virtual ICollection<Assignment> Assignments { get; set; }

}
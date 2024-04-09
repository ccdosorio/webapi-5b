namespace webapi_5b.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Category : BaseEntity
{
  [Key]
  public Guid CategoryId { get; set; }

  [Required]
  public string Name { get; set; }

  public string Description { get; set; }

  [JsonIgnore]
  public virtual ICollection<Assignment> Assignments { get; set; }
}
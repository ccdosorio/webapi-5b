namespace webapi_5b.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Assignment : BaseEntity
{
  [Key]
  public Guid AssignmentId { get; set; }

  [ForeignKey("CategoryId")]
  public Guid CategoryId { get; set; }

  [ForeignKey("UserId")]
  public Guid UserId { get; set; }

  [Required]
  public string Title { get; set; }

  public string Description { get; set; }

  public Priority AssignmentPriority { get; set; }

  [JsonIgnore]
  public virtual Category? Category { get; set; }

  [JsonIgnore]
  public virtual User? User { get; set; }
}

public enum Priority
{
  Low,
  Half,
  High,
}
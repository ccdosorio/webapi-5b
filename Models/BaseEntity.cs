namespace webapi_5b.Models;

public abstract class BaseEntity
{
  public DateTime? CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
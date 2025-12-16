using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DBSchemas;

public class Items
{
	public string Id { get; set; } = Guid.NewGuid().ToString();
	public required string ItemName { get; set; }
	public required string Category { get; set; }
	public required float Price { get; set; }

	public required string UserId { get; set; }
	public User? User { get; set; }

	public ICollection<OrderItems>? OrderItems { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

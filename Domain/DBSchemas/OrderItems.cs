using System;

namespace Domain.DBSchemas;

public class OrderItems

{

	public string Id { get; set; } = Guid.NewGuid().ToString();
	public string? OrderId { get; set; }
	public Order? Order { get; set; }

	public string? ItemId { get; set; }
	public Items? Item { get; set; }

	public int Quantity { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;

}

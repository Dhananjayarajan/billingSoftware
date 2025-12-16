using Domain.DBSchemas;
using Domain.enums;

public class Order
{
	public required string Id { get; set; }
	public float OrderValue { get; set; }
	public PaymentMethods PaymentMethod { get; set; } = PaymentMethods.NotPaid;

	public ICollection<OrderItems>? OrderItems { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

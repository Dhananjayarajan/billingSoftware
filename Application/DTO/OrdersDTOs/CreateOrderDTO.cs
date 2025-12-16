using System;
using Domain.enums;

namespace Application.DTO;

public class CreateOrderDTO
{
	public List<OrderItemDTO> Items { get; set; } = new();
	public PaymentMethods PaymentMethod { get; set; } = PaymentMethods.NotPaid;
}

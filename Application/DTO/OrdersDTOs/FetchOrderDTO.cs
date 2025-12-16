using System;
using Domain.DBSchemas;
using Domain.enums;

namespace Application.DTO.OrdersDTOs;

public class FetchOrderDTO
{

	public string? Id { get; set; }
	public float OrderValue { get; set; }
	public PaymentMethods PaymentMethod { get; set; }
	public List<OrderItems>? OrderItems { get; set; }

}

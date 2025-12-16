using System;

namespace Application.DTO;

public class OrderOutputDto
{
	public required string Id { get; set; }
	public required float OrderValue { get; set; }
}

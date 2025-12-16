using System;
using Domain.DBSchemas;

namespace Application.DTO;

public class CreateItemDTO
{

	public string? Id { get; set; }
	public required string ItemName { get; set; }
	public required string Category { get; set; }
	public required float Price { get; set; }

	public required string UserId { get; set; }
}

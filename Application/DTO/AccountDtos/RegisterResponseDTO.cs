using System;
using Domain.enums;

namespace Application.Users.Commands.DTO;

public class RegisterResponseDTO
{
	public string? Id { get; set; }
	public string? Name { get; set; }
	public string? CompanyName { get; set; }
	public string? Email { get; set; }
	public Plans? Plan { get; set; }
}

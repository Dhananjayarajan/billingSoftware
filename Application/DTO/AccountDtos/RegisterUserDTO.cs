using System;
using System.ComponentModel.DataAnnotations;
using Domain.enums;

namespace Application.Users.Commands.DTO;

public class RegisterUserDTO
{
	public string? Id { get; set; }
	[Required]
	public string Name { get; set; } = "";

	[Required]
	public string CompanyName { get; set; } = "";
	[Required]
	[EmailAddress]
	public string Email { get; set; } = "";
	[Required]
	[MinLength(8)]
	public string Password { get; set; } = "";
	public Plans? Plan { get; set; }
}

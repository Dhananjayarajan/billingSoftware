using System;

namespace Application.Users.Commands.DTO;

public class LoginDTO
{
	public required string Email { get; set; }
	public required string Password { get; set; }
}

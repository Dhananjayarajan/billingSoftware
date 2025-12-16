using System;

namespace Application.Users.Commands.DTO;

public class LoginResponseDTO
{
	public string? Email { get; set; }
	public required string Token { get; set; }
}

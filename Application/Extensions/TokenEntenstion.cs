using System;
using Persistance.Interfaces;
using Domain.DBSchemas;

namespace Application.Users.Commands.DTO.Extensions;

public static class TokenEntenstion
{

	public static LoginResponseDTO TokenExtension(this User user, ITokenService tokenService)
	{
		return new LoginResponseDTO
		{
			Email = user.Email,
			Token = tokenService.CreateToken(user)
		};
	}

}

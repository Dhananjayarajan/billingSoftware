using System;
using System.Security.Cryptography;
using System.Text;
using Application.Users.Commands.DTO;
using Application.Users.Commands.DTO.Extensions;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Interfaces;

namespace Application.Users.Commands;

public class LoginUser
{
	public class Command : IRequest<LoginResponseDTO>
	{
		public required LoginDTO loginDTO { get; set; }
	}

	public class Handler(AppDbContext context, ITokenService tokenService) : IRequestHandler<Command, LoginResponseDTO>
	{
		public async Task<LoginResponseDTO> Handle(Command request, CancellationToken cancellationToken)
		{

			var user = await context.Users
					.SingleOrDefaultAsync(x => x.Email.ToLower() == request.loginDTO.Email, cancellationToken);

			if (user == null)
				throw new Exception("Email not found");


			using var hmac = new HMACSHA512(user.PasswordSalt);
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.loginDTO.Password));

			for (var i = 0; i < computedHash.Length; i++)
			{
				if (computedHash[i] != user.PasswordHash[i])
					throw new Exception("Password not correct");
			}

			return user.TokenExtension(tokenService);
		}
	}


}

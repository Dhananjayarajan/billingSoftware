using System;
using System.Security.Cryptography;
using System.Text;
using Application.Users.Commands.DTO;
using Domain.DBSchemas;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;


namespace Application.Users.Commands;

public class RegisterUser
{
	public class Command : IRequest<RegisterResponseDTO>
	{
		public required RegisterUserDTO registerUserDTO { get; set; }
	}

	public class Handler(AppDbContext context) : IRequestHandler<Command, RegisterResponseDTO>
	{
		public async Task<RegisterResponseDTO> Handle(Command request, CancellationToken cancellationToken)
		{
			if (await EmailExists(request.registerUserDTO.Email))
			{
				throw new Exception("Email already taken");
			}
			using var hmac = new HMACSHA512();

			var user = new User
			{
				Name = request.registerUserDTO.Name,
				Company = request.registerUserDTO.CompanyName,
				Email = request.registerUserDTO.Email,
				PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.registerUserDTO.Password)),
				PasswordSalt = hmac.Key
			};

			context.Users.Add(user);
			await context.SaveChangesAsync(cancellationToken);
			return new RegisterResponseDTO
			{
				Id = user.UserId,
				Name = user.Name,
				CompanyName = user.Company,
				Email = user.Email
			};
		}


		private async Task<bool> EmailExists(string Email)
		{
			return await context.Users.AnyAsync(x => x.Email.ToLower() == Email.ToLower());
		}
	}



}

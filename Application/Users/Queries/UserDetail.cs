
using Application.Users.Commands.DTO;
using AutoMapper;
using MediatR;
using Persistance;

namespace Application.Users.Queries;

public class UserDetail
{
	public class Query : IRequest<RegisterResponseDTO>
	{
		public required string Id;
	}

	public class Handler(AppDbContext context) : IRequestHandler<Query, RegisterResponseDTO>
	{
		public async Task<RegisterResponseDTO> Handle(Query request, CancellationToken cancellationToken)
		{
			var user = await context.Users.FindAsync([request.Id], cancellationToken) ?? throw new Exception("user not found");

			return new RegisterResponseDTO
			{
				Id = user.UserId,
				Name = user.Name,
				CompanyName = user.Company,
				Email = user.Email,
				Plan = user.PlanType
			};

		}
	}
}

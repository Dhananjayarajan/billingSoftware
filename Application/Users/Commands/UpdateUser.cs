using Application.Users.Commands.DTO;
using AutoMapper;
using MediatR;
using Persistance;

namespace Application.Users.Commands;

public class UpdateUser
{
	public class Command : IRequest<RegisterResponseDTO>
	{
		public required RegisterUserDTO registerUserDTO;
	}

	public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, RegisterResponseDTO>
	{
		public async Task<RegisterResponseDTO> Handle(Command request, CancellationToken cancellationToken)
		{
			var user = await context.Users.FindAsync([request.registerUserDTO.Id], cancellationToken) ?? throw new Exception("User not found");

			mapper.Map(request.registerUserDTO, user);

			await context.SaveChangesAsync(cancellationToken);

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

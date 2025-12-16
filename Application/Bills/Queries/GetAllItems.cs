using System;
using Application.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Bills.Queries;

public class GetAllItems
{
	public class Query : IRequest<List<CreateItemDTO>>
	{
		public required string UserId;
	}

	public class Handler(AppDbContext context) : IRequestHandler<Query, List<CreateItemDTO>>
	{
		public async Task<List<CreateItemDTO>> Handle(Query request, CancellationToken cancellationToken)
		{
			var user = await context.Users.FindAsync([request.UserId], cancellationToken: cancellationToken) ?? throw new Exception("User not registered");

			return await context.Items.Where(x => x.UserId == request.UserId)
																.Select(x => new CreateItemDTO
																{
																	Id = x.Id,
																	ItemName = x.ItemName,
																	Category = x.Category,
																	Price = x.Price,
																	UserId = x.UserId
																})
																.ToListAsync(cancellationToken);

		}
	}
}

using System;
using Application.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Bills.Queries;

public class GetItem
{

	public class Query : IRequest<CreateItemDTO>
	{
		public required string ItemId;
	}

	public class Handler(AppDbContext context) : IRequestHandler<Query, CreateItemDTO>
	{
		public async Task<CreateItemDTO> Handle(Query request, CancellationToken cancellationToken)
		{

			var item = await context.Items.FindAsync([request.ItemId], cancellationToken) ?? throw new Exception("item not found");

			return new CreateItemDTO
			{
				Id = item.Id,
				ItemName = item.ItemName,
				Category = item.Category,
				Price = item.Price,
				UserId = item.UserId
			};

		}
	}

}

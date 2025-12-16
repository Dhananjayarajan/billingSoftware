using Application.DTO.OrdersDTOs;
using Domain.DBSchemas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Queries;

public class FetchOrder
{
	public class Query : IRequest<FetchOrderDTO>
	{
		public required string OrderId { get; set; }
	}

	public class Handler(AppDbContext context) : IRequestHandler<Query, FetchOrderDTO>
	{
		public async Task<FetchOrderDTO> Handle(Query request, CancellationToken cancellationToken)
		{
			var order = await context.Orders.FindAsync(request.OrderId, cancellationToken) ?? throw new Exception("Order not found for this order Id");

			List<OrderItems> orderItems = await context.OrderItems.
																									Where(x => x.OrderId == request.OrderId)
																									.ToListAsync(cancellationToken);

			return new FetchOrderDTO
			{
				Id = order.Id,
				OrderValue = order.OrderValue,
				PaymentMethod = order.PaymentMethod,
				OrderItems = orderItems
			};

		}
	}
}

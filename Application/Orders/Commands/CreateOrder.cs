
using Application.DTO;
using Domain.DBSchemas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Commands;

public class CreateOrder
{
	public class Command : IRequest<OrderOutputDto>
	{
		public required CreateOrderDTO createOrderDTO;
	}

	public class Handler(AppDbContext context) : IRequestHandler<Command, OrderOutputDto>
	{
		public async Task<OrderOutputDto> Handle(Command request, CancellationToken cancellationToken)
		{
			var orderId = Guid.NewGuid().ToString();
			float totalPayment = 0;

			foreach (var item in request.createOrderDTO.Items)
			{
				var existingItem = await context.Items.SingleOrDefaultAsync(x => x.Id == item.ItemId, cancellationToken) ?? throw new Exception("Item not found in Db");

				var price = existingItem.Price * item.Quantity;
				totalPayment += price;

				var orderItemObject = new OrderItems
				{
					OrderId = orderId,
					ItemId = item.ItemId,
					Quantity = item.Quantity
				};

				await context.OrderItems.AddAsync(orderItemObject, cancellationToken);
			}
			;

			var order = new Order
			{
				Id = orderId,
				OrderValue = totalPayment
			};

			await context.SaveChangesAsync(cancellationToken);


			return new OrderOutputDto
			{
				Id = orderId,
				OrderValue = totalPayment
			};

		}
	}
}

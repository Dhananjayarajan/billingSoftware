using System;
using Application.DTO;
using MediatR;
using Persistance;

namespace Application.Bills.Commands;

public class DeleteItem
{
	public class Command : IRequest
	{
		public required string Id { get; set; }
	}

	public class Handler(AppDbContext context) : IRequestHandler<Command>
	{
		public async Task Handle(Command request, CancellationToken cancellationToken)
		{
			var item = await context.Items.FindAsync([request.Id], cancellationToken) ?? throw new Exception("Item not found or already been deleted");

			context.Remove(item);

			await context.SaveChangesAsync(cancellationToken);

		}
	}
}

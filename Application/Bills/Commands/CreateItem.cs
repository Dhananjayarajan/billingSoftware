using Application.DTO;
using Domain.DBSchemas;
using MediatR;


namespace Application.Bills.Commands;

public class CreateItem
{

	public class Command : IRequest<CreateItemDTO>
	{
		public required CreateItemDTO createItemDTO;
	}

	public class Handler(AppDbContext context) : IRequestHandler<Command, CreateItemDTO>
	{
		public async Task<CreateItemDTO> Handle(Command request, CancellationToken cancellationToken)
		{
			_ = await context.Users.FindAsync([request.createItemDTO.UserId], cancellationToken) ?? throw new Exception("user not found please register");

			var item = new Items
			{
				ItemName = request.createItemDTO.ItemName,
				Category = request.createItemDTO.Category,
				Price = request.createItemDTO.Price,
				UserId = request.createItemDTO.UserId
			};

			context.Items.Add(item);
			await context.SaveChangesAsync(cancellationToken);

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

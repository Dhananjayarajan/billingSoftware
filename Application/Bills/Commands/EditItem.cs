using Application.DTO;
using AutoMapper;
using MediatR;


namespace Application.Bills.Commands;

public class EditItem
{
	public class Command : IRequest<CreateItemDTO>
	{
		public required CreateItemDTO createItemDTO;
	}

	public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, CreateItemDTO>
	{
		public async Task<CreateItemDTO> Handle(Command request, CancellationToken cancellationToken)
		{
			var item = await context.Items.FindAsync([request.createItemDTO.Id], cancellationToken) ?? throw new Exception("Unable to edit, Item not found");

			mapper.Map(request.createItemDTO, item);

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

using Application.DTO;
using Application.DTO.OrdersDTOs;
using Application.Orders.Commands;
using Application.Orders.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        [HttpPost("createOrder")]

        public async Task<ActionResult<OrderOutputDto>> CreateOrder(CreateOrderDTO createOrderDTO)
        {
            return await Mediator.Send(new CreateOrder.Command
            {
                createOrderDTO = createOrderDTO
            });
        }

        [HttpGet("getOrder")]

        public async Task<ActionResult<FetchOrderDTO>> GetOrder([FromQuery] string Id)
        {
            return await Mediator.Send(new FetchOrder.Query
            {
                OrderId = Id
            });
        }
    }
}

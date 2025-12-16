using Application.Bills.Commands;
using Application.Bills.Queries;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ItemController : BaseApiController
    {
        [HttpPost("createItem")]

        public async Task<ActionResult<CreateItemDTO>> CreateItem(CreateItemDTO createItemDTO)
        {
            return await Mediator.Send(new CreateItem.Command
            {
                createItemDTO = createItemDTO
            }
            );
        }

        [HttpGet("getItem")]
        public async Task<ActionResult<CreateItemDTO>> GetItem([FromQuery] string id)
        {
            return await Mediator.Send(new GetItem.Query
            {
                ItemId = id
            }
            );
        }

        [HttpGet("getAllItems")]
        public async Task<ActionResult<List<CreateItemDTO>>> GetAllItems([FromQuery] string userId)
        {
            return await Mediator.Send(new GetAllItems.Query
            {
                UserId = userId
            }
            );
        }

        [HttpPut("editItem")]
        public async Task<ActionResult<CreateItemDTO>> EditItem(CreateItemDTO createItemDTO)
        {
            return await Mediator.Send(new EditItem.Command
            {
                createItemDTO = createItemDTO
            }
            );
        }

        [HttpDelete("deleteItem")]

        public async Task<ActionResult> DeleteItem([FromQuery] string id)
        {
            await Mediator.Send(new DeleteItem.Command
            {
                Id = id
            });

            return Ok();
        }
    }
}

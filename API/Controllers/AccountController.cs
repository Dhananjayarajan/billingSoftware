using Application.Users.Commands;
using Application.Users.Commands.DTO;
using Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AccountController : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseDTO>> Register(RegisterUserDTO registerUserDTO)
        {
            return await Mediator.Send(new RegisterUser.Command
            {
                registerUserDTO = registerUserDTO
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginDTO loginDTO)
        {
            return await Mediator.Send(new LoginUser.Command
            {
                loginDTO = loginDTO
            });

        }


        [HttpGet("getuser")]
        public async Task<ActionResult<RegisterResponseDTO>> GetUser([FromQuery] string id)
        {
            return await Mediator.Send(new UserDetail.Query
            {
                Id = id
            });
        }

        [HttpPut("updateUser")]
        public async Task<ActionResult<RegisterResponseDTO>> UpdateUser(RegisterUserDTO registerUserDTO)
        {
            return await Mediator.Send(new UpdateUser.Command
            {
                registerUserDTO = registerUserDTO
            });
        }
    }
}
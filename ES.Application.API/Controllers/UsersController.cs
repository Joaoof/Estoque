using ES.Services.API.Aggregates.UsersAggregates.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ES.Application.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersAppService _usersAppService;

        public UsersController(IUsersAppService usersAppService)
        {
            _usersAppService = usersAppService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetInformationAllUsers()
        {
            var usersAll = await _usersAppService.GetInformationAllUsers();

            if (usersAll == null)
            {
                return NoContent();
            }

            return Ok(usersAll);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInformationUserId(int id)
        {
            var users = await _usersAppService.GetInformationUserId(id);

            if(users is null)
            {
                return NoContent();
            }

            return Ok(users);
        }

    }
}

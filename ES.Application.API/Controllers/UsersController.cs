using ES.Domain.API.Models;
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UsersModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateSucess = await _usersAppService.UpdateUsers(userModel);

            if(!updateSucess)
            {
                return NoContent();
            }

            return Ok(updateSucess);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateUserStatus(int id, bool isActive)
        {
            var result = await _usersAppService.UpdateUserStatus(id, isActive);

            if (!result)
            {
                return NotFound("User not found");
            }

            return NoContent();
        }

    }
}

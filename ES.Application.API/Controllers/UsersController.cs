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


    }
}

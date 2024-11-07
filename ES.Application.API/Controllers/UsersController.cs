using ES.Services.API.Aggregates.UsersAggregates.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ES.Application.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _usersAppService;

        public UsersController(IUserAppService usersAppService)
        {
            _usersAppService = usersAppService;
        }


    }
}

using ES.Domain.API.Models;
using ES.Services.API.Aggregates.AccountAggregates.AccountViewModel;
using ES.Services.API.Aggregates.AccountAggregates.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ES.Application.API.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
           _accountAppService = accountAppService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _accountAppService.RegisterUserAsync(model);


            if (result.IsCompletedSuccessfully)
            {
                return Ok("User registered successfully");
            }


            foreach (var error in result.Result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountAppService.LoginUserAsync(loginModel);
            if (result.Succeeded)
            {
                return Ok("Login successful");
            }

            return Unauthorized("Invalid login attempt");
        }

    }
}

using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.AccountAggregates.Interface;
using Microsoft.AspNetCore.Identity;

namespace ES.Services.API.Aggregates.AccountAggregates.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountAppService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IdentityResult> RegisterUserAsync(RegisterModel registerModel)
        {
            var user = new IdentityUser
            {
                UserName = registerModel.Email,
                Email = registerModel.Email,
            };

            return await _accountRepository.RegisterUserAsync(user, registerModel.Password);

        }

        public async Task<SignInResult> LoginUserAsync(LoginModel loginModel)
        {
            return await _accountRepository.LoginUserAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe);

        }

    }
}

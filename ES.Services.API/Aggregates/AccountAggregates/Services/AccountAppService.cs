using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.AccountAggregates.AccountViewModel;
using ES.Services.API.Aggregates.AccountAggregates.Interface;
using IFA.Domain.API.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ES.Services.API.Aggregates.AccountAggregates.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountAppService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IdentityResult> RegisterUserAsync(RegisterUserViewModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var register = await _accountRepository.RegisterUserAsync(user, model.Password);

            Console.WriteLine(register);

            await _unitOfWork.CommitAsync();

            return register;

        }

        public async Task<SignInResult> LoginUserAsync(LoginModel loginModel)
        {
            return await _accountRepository.LoginUserAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe);

        }

    }
}

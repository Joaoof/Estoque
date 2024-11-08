using ES.Domain.API.Models;
using ES.Services.API.Aggregates.AccountAggregates.AccountViewModel;
using Microsoft.AspNetCore.Identity;

namespace ES.Services.API.Aggregates.AccountAggregates.Interface
{
    public interface IAccountAppService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUserViewModel model);
        Task<SignInResult> LoginUserAsync(LoginModel loginModel);
    }
}

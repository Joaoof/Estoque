using ES.Domain.API.Models;
using Microsoft.AspNetCore.Identity;

namespace ES.Services.API.Aggregates.AccountAggregates.Interface
{
    public interface IAccountAppService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterModel registerModel);
        Task<SignInResult> LoginUserAsync(LoginModel loginModel);
    }
}

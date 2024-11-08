using Microsoft.AspNetCore.Identity;

namespace ES.Domain.API.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterUserAsync(IdentityUser user, string password);
        Task<SignInResult> LoginUserAsync(string email, string password, bool rememberMe);

    }
}

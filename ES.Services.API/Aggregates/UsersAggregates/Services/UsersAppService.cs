using ES.Domain.API.Interfaces.Repositories;
using ES.Services.API.Aggregates.UsersAggregates.Interface;

namespace ES.Services.API.Aggregates.UsersAggregates.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUsersRepository _usersRepository;
    }
}

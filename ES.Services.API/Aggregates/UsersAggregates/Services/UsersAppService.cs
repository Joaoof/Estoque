using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.UsersAggregates.Interface;

namespace ES.Services.API.Aggregates.UsersAggregates.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersAppService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UsersModel> GetInformationUserId(int id)
        {
            var usersAll = await _usersRepository.GetByIdAsync(id);

            return usersAll;
        }
    }
}

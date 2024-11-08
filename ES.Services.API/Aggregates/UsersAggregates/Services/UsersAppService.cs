using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.UsersAggregates.Interface;
using IFA.Domain.API.Interfaces;

namespace ES.Services.API.Aggregates.UsersAggregates.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsersAppService(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UsersModel>> GetInformationAllUsers()
        {
            var usersAll = await _usersRepository.GetAllAsync();

            return usersAll;
        }

        public async Task<UsersModel> GetInformationUserId(int id)
        {
            var user = await _usersRepository.GetByIdAsync(id);

            return user;
        }


        public async Task<bool> UpdateUser(UsersModel usersModel)
        {
            var update = await _usersRepository.UpdateAsync(usersModel);

            await _unitOfWork.CommitAsync();

            return update;
        }

        public async Task<bool> UpdateUserStatus(int id, bool isActive)
        {
            var user = await _usersRepository.GetByIdAsync(id);

            if (user is null)
            {
                return false;
            }

            user.IsActive = isActive;

            await _usersRepository.UpdateAsync(user);

            return true;
        }
    }
}

using ES.Domain.API.Models;

namespace ES.Services.API.Aggregates.UsersAggregates.Interface
{
    public interface IUsersAppService
    {
        Task<List<UsersModel>> GetInformationAllUsers();
        Task<UsersModel> GetInformationUserId(int id);

        Task<bool> UpdateUsers(UsersModel userModel);

        Task<bool> UpdateUserStatus(int id,  bool isActive); 
    }
}

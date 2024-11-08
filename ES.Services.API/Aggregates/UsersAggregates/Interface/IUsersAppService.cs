using ES.Domain.API.Models;

namespace ES.Services.API.Aggregates.UsersAggregates.Interface
{
    public interface IUsersAppService
    {
        Task<List<UsersModel>> GetInformationAllUsers();
        Task<UsersModel> GetInformationUserId(int id);
    }
}

using ES.Domain.API.Models;

namespace ES.Services.API.Aggregates.UsersAggregates.Interface
{
    public interface IUsersAppService
    {
        Task<UsersModel> GetInformationUserId(int id);
    }
}

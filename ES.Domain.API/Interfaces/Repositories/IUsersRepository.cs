using ES.Domain.API.Models;

namespace ES.Domain.API.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<UsersModel>
    {
        //Task<UsersModel> GetAllUsers();
        Task<UsersModel> GetByIdAsync(int id);

    }
}

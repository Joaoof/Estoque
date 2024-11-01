namespace IFA.Domain.API.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
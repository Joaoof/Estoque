using ES.Domain.API.Models;

namespace ES.Services.API.Aggregates.SuppliersAggregates.Interface
{
    public interface ISuppliersAppService
    {
        Task<List<SuppliersModel>> GetInformationAllSuppliers();
    }
}

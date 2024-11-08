using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.SuppliersAggregates.Interface;

namespace ES.Services.API.Aggregates.SuppliersAggregates.Services
{
    public class SuppliersAppService : ISuppliersAppService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersAppService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public async Task<List<SuppliersModel>> GetInformationAllSuppliers()
        {
            var suppliers = await _suppliersRepository.GetAllAsync();

            return suppliers;
        }
    }
}

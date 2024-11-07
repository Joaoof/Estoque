using ES.Domain.API.Interfaces.Repositories;
using ES.Services.API.Helpers.Interfaces;

namespace ES.Services.API.Helpers
{
    public class SkuGenerator : ISkuGenerator
    {
        private readonly IProductsRepository _productsRepository;

        public SkuGenerator(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<string> GenerateUniqueSkuAsync()
        {
            string newSku;
            do
            {
                newSku = GenerateSkuCode();
            } while (!await _productsRepository.IsSkuUniqueAsync(newSku));

            return newSku;
        }

        private static string GenerateSkuCode(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Range(0, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }
    }

}

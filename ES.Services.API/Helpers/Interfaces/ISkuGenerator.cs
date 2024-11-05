namespace ES.Services.API.Helpers.Interfaces
{
    public interface ISkuGenerator
    {
        Task<string> GenerateUniqueSkuAsync();
    }

}

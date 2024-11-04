using AutoMapper;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Request;

namespace ES.Services.API.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductsModel, ProductsViewModel>().ReverseMap();
        }
    }
}

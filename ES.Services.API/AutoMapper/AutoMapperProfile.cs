using AutoMapper;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Request;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Response;

namespace ES.Services.API.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductsModel, ProductsViewModel>().ReverseMap();

            CreateMap<ProductsModel, ProductsViewModelResponse>()
               .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories)); // Supondo que a propriedade Category exista em ProductsModel
        }
    }
}

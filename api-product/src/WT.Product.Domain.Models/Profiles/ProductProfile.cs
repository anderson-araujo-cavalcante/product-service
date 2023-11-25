using AutoMapper;
using WT.Product.Domain.Models.DTO;

namespace WT.Product.Domain.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Data.Entities.Product, ProductDTO>().ReverseMap();            
        }
    }
}

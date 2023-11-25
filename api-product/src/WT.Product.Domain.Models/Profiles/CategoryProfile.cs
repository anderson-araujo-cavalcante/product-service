using AutoMapper;
using WT.Product.Domain.Models.DTO;

namespace WT.Product.Domain.Models.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Data.Entities.Category, CategoryDTO>().ReverseMap();
        }
    }
}

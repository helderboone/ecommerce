using AutoMapper;
using Ecommerce.App.Features.Admin.Product.Commands;
using Ecommerce.App.Features.Admin.Product.Queries;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();

            CreateMap<Category, SelectListItem>()
                .ForMember(dest => dest.Text, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.Id));

            CreateMap<IndexProductQuery.Model.ProductModel, Product>().ReverseMap();
        }
    }
}

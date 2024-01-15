using AutoMapper;
using Business.Common;
using Business.ViewModels;

namespace Business.Mappers
{
    public class BlogMapperProfile : Profile
    {
        public BlogMapperProfile()
        {
            CreateMap<Blog,BlogCreateVm>().ReverseMap();
            CreateMap<BlogUpdateVm,BlogGetVm>().ReverseMap();
            CreateMap<Blog,BlogGetVm>().ReverseMap();
            CreateMap<Blog,BlogUpdateVm>().ReverseMap();
        }
    }
}

using AutoMapper;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<UpdateCategoriaDto, Categoria>();
            CreateMap<Categoria, UpdateCategoriaDto>();
            CreateMap<Categoria, ReadCategoriaDto>();
        }
    }
}

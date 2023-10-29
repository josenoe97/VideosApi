using AutoMapper;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}

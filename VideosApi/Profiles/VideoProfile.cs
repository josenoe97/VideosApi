using AutoMapper;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Profiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<CreateVideoDto, Video>();
            CreateMap<UpdateVideoDto, Video>();
            CreateMap<Video, UpdateVideoDto>();
            CreateMap<Video, ReadVideoDto>();
        }
    }
}

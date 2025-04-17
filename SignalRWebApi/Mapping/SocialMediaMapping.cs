using AutoMapper;
using SignalRDtoLayer.SocialMediaDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaDTO>().ReverseMap();
        }
    }
}

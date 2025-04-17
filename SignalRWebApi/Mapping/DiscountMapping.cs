using AutoMapper;
using SignalRDtoLayer.DiscountDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, ResultDiscountDTO>().ReverseMap();
            CreateMap<Discount, CreateDiscountDTO>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDTO>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDTO>().ReverseMap();
        }
    }
}

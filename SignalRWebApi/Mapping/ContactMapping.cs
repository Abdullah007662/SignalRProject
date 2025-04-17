using AutoMapper;
using SignalRDtoLayer.ContactDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, GetByIdContactDTO>().ReverseMap();
        }
    }
}

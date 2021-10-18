using AutoMapper;
using CustomerApi.BusinessLogic.Dtos;
using CustomerApi.Domain.Entities;

namespace CustomerApi.BusinessLogic.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>().ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(x => x.CellPhone, opt => opt.MapFrom(c => c.CellPhone))
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.ClientAddress, opt => opt.MapFrom(c => c.ClientAddress)).ReverseMap();

            CreateMap<ClientAddress, ClientAddressDto>().ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id)).ForMember(x => x.Description, opt => opt.MapFrom(c => c.Description)).ReverseMap();
                
        }
    }
}
